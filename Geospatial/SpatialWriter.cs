using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxRev.Gdal.Core;

//using MaxRev.Gdal.Core;
using OSGeo.GDAL;
using OSGeo.OGR;
using OSGeo.OSR;

namespace Geospatial;
public class SpatialWriter
{
  public void WriteToOGR()
  {
    GdalBase.ConfigureAll();
    Ogr.RegisterAll();

    string outputPath = @"C:\repos\consequences\ScratchPaper\Files\example.shp";

    var driver = Ogr.GetDriverByName("ESRI Shapefile");

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

      FieldDefn fieldDefn1 = new FieldDefn("Field1", FieldType.OFTInteger);
      FieldDefn fieldDefn2 = new FieldDefn("Field2", FieldType.OFTString);
      layer.CreateField(fieldDefn1, 1);
      layer.CreateField(fieldDefn2, 1);

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
    }
    Ogr.GetDriverByName("ESRI Shapefile")?.Dispose();
  }
}
