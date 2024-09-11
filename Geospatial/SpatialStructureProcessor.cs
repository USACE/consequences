using System.Reflection;
using System.Text.Json.Serialization;
using OSGeo.OGR;
using USACE.HEC.Consequences;

namespace Geospatial;

// process an OGR driver into a stream of structures and apply a process to the structure
public class SpatialStructureProcessor : IFileStreamingProcessor
{
  public void Process(string filePath, Action<IConsequencesReceptor> consequenceReceptorProcess)
  {
    GDALAssist.GDALSetup.InitializeMultiplatform();

    using DataSource ds = Ogr.Open(filePath, 0) ?? throw new Exception("Failed to create datasource.");
    Layer layer = ds.GetLayerByIndex(0) ?? throw new Exception("Failed to create layer.");

    Feature structure;
    while ((structure = layer.GetNextFeature()) != null)
    {
      PropertyInfo[] properties = typeof(Structure).GetProperties();
      Structure s = new();

      foreach (PropertyInfo property in properties)
      {
        JsonPropertyNameAttribute? jsonPropertyAttribute = property.GetCustomAttribute<JsonPropertyNameAttribute>();

        // check if the property has a JsonPropertyName (jsonPropertyAttribute not null) 
        // we know that all strucuture properties have one but the compiler does not?
        string jsonPropertyName = jsonPropertyAttribute != null ? jsonPropertyAttribute.Name : property.Name;

        if (property.PropertyType == typeof(int))
          property.SetValue(s, structure.GetFieldAsInteger(jsonPropertyName));
        else if (property.PropertyType == typeof(double)) 
          property.SetValue(s, structure.GetFieldAsDouble(jsonPropertyName));
        else if (property.PropertyType == typeof(float))
          property.SetValue(s, (float)structure.GetFieldAsDouble(jsonPropertyName));
        else // field is a string
          property.SetValue(s, structure.GetFieldAsString(jsonPropertyName));
      }

      consequenceReceptorProcess(s);
    }
  }
}