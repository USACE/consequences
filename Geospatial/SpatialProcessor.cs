using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.Json.Serialization;
using OSGeo.OGR;
using USACE.HEC.Consequences;

namespace Geospatial;

// process an OGR driver into a stream of IConsequenceReceptors and apply a consequenceReceptorProcess to each
public class SpatialProcessor : IStreamingProcessor
{
  private DataSource _dataSource;
  private Layer _layer;
  public SpatialProcessor(string filePath, int layerIndex = 0)
  {
    _dataSource = Ogr.Open(filePath, 0) ?? throw new Exception("Failed to create datasource.");
    // only one layer in the files we are dealing with
    _layer = _dataSource.GetLayerByIndex(layerIndex) ?? throw new Exception("Failed to create layer."); 
  }

  public void Process<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(Action<IConsequencesReceptor> consequenceReceptorProcess) where T : IConsequencesReceptor, new()
  {
    Feature feature;
    while ((feature = _layer.GetNextFeature()) != null)
    {
      PropertyInfo[] properties = typeof(T).GetProperties();
      // T MUST be an IConsequencesReceptor with a parameterless constructor, eg. a structure
      T consequenceReceptor = new();

      foreach (PropertyInfo property in properties)
      {
        // IConsequenceReceptors' properties must have the JsonPropertyName tag
        // JsonPropertyNames must match the corresponding field names in the driver for a given property
        JsonPropertyNameAttribute jsonPropertyAttribute = property.GetCustomAttribute<JsonPropertyNameAttribute>();
        string fieldName = jsonPropertyAttribute != null ? jsonPropertyAttribute.Name : property.Name;

        // read values from the driver into their corresponding properties in the IConsequencesReceptor
        if (property.PropertyType == typeof(int))
          property.SetValue(consequenceReceptor, feature.GetFieldAsInteger(fieldName));
        else if (property.PropertyType == typeof(long))
          property.SetValue(consequenceReceptor, feature.GetFieldAsInteger64(fieldName));
        else if (property.PropertyType == typeof(double)) 
          property.SetValue(consequenceReceptor, feature.GetFieldAsDouble(fieldName));
        else if (property.PropertyType == typeof(float))
          property.SetValue(consequenceReceptor, (float)feature.GetFieldAsDouble(fieldName));
        else if (property.PropertyType == typeof(string))
          property.SetValue(consequenceReceptor, feature.GetFieldAsString(fieldName));
      }

      consequenceReceptorProcess(consequenceReceptor);
    }
  }
}