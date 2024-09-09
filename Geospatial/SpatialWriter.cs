using OSGeo.OGR;
using OSGeo.OSR;
using USACE.HEC.Results;

namespace Geospatial;


public class SpatialWriter : IResultsWriter
{
  private Layer? _layer;
  private DataSource? _dataSource;
  private SpatialReference? _srs;
  private SpatialReference? _dst;
  private bool _headersWritten;

  public SpatialWriter(string driverName, int projection)
  {
    GDALAssist.GDALSetup.InitializeMultiplatform();
    string outputPath = @"C:\repos\consequences\ScratchPaper\Files\example.shp";
    _dataSource = Ogr.GetDriverByName(driverName).CreateDataSource(outputPath, null);
    if (_dataSource == null) { Console.WriteLine("Failed to create data source."); return; }

    _srs = new SpatialReference("");
    _srs.SetWellKnownGeogCS("WGS84");
    if (_srs == null) { Console.WriteLine("Failed to create source SpatialReference."); return; }
    _dst = new SpatialReference("");
    _dst.ImportFromEPSG(projection);
    if (_dst == null) { Console.WriteLine("Failed to create destination SpatialReference."); return; }

    _layer = _dataSource.CreateLayer("layer_name", _dst, wkbGeometryType.wkbPoint, null);
    if (_layer == null) { Console.WriteLine("Failed to create layer."); return; }

    _headersWritten = false;
  }

  public void Write(Result res)
  {
    if (_layer == null)
    {
      return;
    }

    if (!_headersWritten)
    {
      InitializeFields(_layer, res);

      _headersWritten= true;
    }

    Feature feature = new Feature(_layer.GetLayerDefn());

    // Set geometry for the feature (e.g., a point)
    Geometry geometry = new Geometry(wkbGeometryType.wkbPoint);
    geometry.AddPoint(38.5, -121.7, 0);  // Add coordinates
    CoordinateTransformation ct = new CoordinateTransformation(_srs, _dst);
    geometry.Transform(ct);
    feature.SetGeometry(geometry);

    // initialize all fields
    for (int i = 0; i < _layer.GetLayerDefn().GetFieldCount(); i++)
    {
      string fieldName = _layer.GetLayerDefn().GetFieldDefn(i).GetName();
      feature.SetField(fieldName, "hi");
    }

    
    _layer.CreateFeature(feature);
    feature.Dispose();
    geometry.Dispose();
  }

  private static void InitializeFields(Layer layer, Result res)
  {
    foreach (ResultItem item in res.ResultItems)
    {
      switch (item.Result)
      {
        case int _:
          layer.CreateField(new FieldDefn(item.ResultName, FieldType.OFTInteger), 1);
          break;
        case long _:
          layer.CreateField(new FieldDefn(item.ResultName, FieldType.OFTInteger64), 1);
          break;
        case double _ or float _:
          layer.CreateField(new FieldDefn(item.ResultName, FieldType.OFTReal), 1);
          break;
        case string _:
          layer.CreateField(new FieldDefn(item.ResultName, FieldType.OFTString), 1);
          break;
        case DateOnly _:
          layer.CreateField(new FieldDefn(item.ResultName, FieldType.OFTDate), 1);
          break;
        case TimeOnly _:
          layer.CreateField(new FieldDefn(item.ResultName, FieldType.OFTTime), 1);
          break;
        case DateTime _:
          layer.CreateField(new FieldDefn(item.ResultName, FieldType.OFTDateTime), 1);
          break;
        default:
          // for case of a null string
          layer.CreateField(new FieldDefn(item.ResultName, FieldType.OFTString), 1);
          break;
      }
    }
  }

  public void Dispose()
  {

  }
}
