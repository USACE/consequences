using OSGeo.OGR;
using OSGeo.OSR;
using USACE.HEC.Results;

namespace Geospatial;


public class SpatialWriter : IResultsWriter
{
  public void Write(Result res)
  {
    GDALAssist.GDALSetup.InitializeMultiplatform(@"C:\Users\HEC\Downloads\GDAL\GDAL");

    string outputPath = @"C:\repos\consequences\ScratchPaper\Files\example.shp"; 

    using Driver driver = Ogr.GetDriverByName("ESRI Shapefile");

    using (DataSource dataSource = driver.CreateDataSource(outputPath, null))
    {
      if (dataSource == null)
      {
        Console.WriteLine("Failed to create data source.");
        return;
      }

      // Define the spatial reference (WGS84)
      SpatialReference srs = new SpatialReference("");
      srs.SetWellKnownGeogCS("WGS84");
      SpatialReference dst = new SpatialReference("");
      dst.ImportFromEPSG(3310);

      // Create a new layer with the specified spatial reference
      Layer layer = dataSource.CreateLayer("layer_name", dst, wkbGeometryType.wkbPoint, null);
      if (layer == null)
      {
        Console.WriteLine("Failed to create layer.");
        return;
      }
      foreach (ResultItem item in res.ResultItems)
      {
        FieldDefn fieldDefn;
        switch (item.Result)
        {
          case int:
            fieldDefn = new FieldDefn(item.ResultName, FieldType.OFTInteger);
            break;
          default:
            break;
        }
        
        layer.CreateField(fieldDefn, 1);
      }


      // Create a new feature
      Feature feature = new Feature(layer.GetLayerDefn());

      // Set geometry for the feature (e.g., a point)
      Geometry geometry = new Geometry(wkbGeometryType.wkbPoint);
      geometry.AddPoint(38.5, -121.7, 0);  // Add coordinates
      
      CoordinateTransformation ct = new CoordinateTransformation(srs, dst);
      geometry.Transform(ct);
      feature.SetGeometry(geometry);

      feature.SetField("Field1", 12);
      feature.SetField("Field2", "Hello");

      layer.CreateFeature(feature);
      feature.Dispose();
      geometry.Dispose();

      // Create a new feature
      Feature feature2 = new Feature(layer.GetLayerDefn());

      // Set geometry for the feature (e.g., a point)
      Geometry geometry2 = new Geometry(wkbGeometryType.wkbPoint);
      geometry2.AddPoint(38.554, -121.7, 0);  // Add coordinates

      CoordinateTransformation ct2 = new CoordinateTransformation(srs, dst);
      geometry2.Transform(ct2);
      feature2.SetGeometry(geometry);

      feature2.SetField("Field1", 12);
      feature2.SetField("Field2", "Hello");

      layer.CreateFeature(feature2);
      feature2.Dispose();
      geometry2.Dispose();
    }
  }

  public void Dispose()
  {

  }
}
