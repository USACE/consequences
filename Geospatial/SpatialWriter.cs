using OSGeo.OGR;
using OSGeo.OSR;
using USACE.HEC.Results;

namespace Geospatial;


public class SpatialWriter : IResultsWriter
{
  private string _outputPath;
  private Layer? _layer;
  private DataSource? _dataSource;
  private SpatialReference? _srs;
  private SpatialReference? _dst;
  private bool _headersWritten;
  public delegate void FieldTypeDelegate(Feature layer, string fieldName, object value);
  private FieldTypeDelegate? _fieldTypeDelegate;

  public SpatialWriter(string outputPath, string driverName, int projection, FieldTypeDelegate fieldTypeDelegate)
  {
    GDALAssist.GDALSetup.InitializeMultiplatform();
    _outputPath = outputPath;
    _dataSource = Ogr.GetDriverByName(driverName).CreateDataSource(_outputPath, null);
    if (_dataSource == null) throw new Exception("Failed to create data source.");
    _srs = new SpatialReference("");
    _srs.SetWellKnownGeogCS("WGS84");
    if (_srs == null) throw new Exception("Failed to create SpatialReference.");
    _dst = new SpatialReference("");
    _dst.ImportFromEPSG(projection);
    if (_dst == null) throw new Exception("Failed to create SpatialReference.");

    _layer = _dataSource.CreateLayer("layer_name", _dst, wkbGeometryType.wkbPoint, null);
    if (_layer == null) throw new Exception("Failed to create layer.");

    _headersWritten = false;
    _fieldTypeDelegate = fieldTypeDelegate;
  }

  public void Write(Result res)
  {
    if (_layer == null || _fieldTypeDelegate == null)
    {
      return;
    }
    if (!_headersWritten)
    {
      InitializeFields(_layer, res);
      _headersWritten= true;
    }

    using Feature feature = new Feature(_layer.GetLayerDefn());
    using Geometry geometry = new Geometry(wkbGeometryType.wkbPoint);
    double x = (double)res.Fetch("x").Result;
    double y = (double)res.Fetch("y").Result;
    geometry.AddPoint(y, x, 0); 
    // transform the coordinates according to the specified projection
    CoordinateTransformation ct = new CoordinateTransformation(_srs, _dst);
    geometry.Transform(ct);
    feature.SetGeometry(geometry);

    for (int i = 0; i < _layer.GetLayerDefn().GetFieldCount(); i++)
    {
      string fieldName = _layer.GetLayerDefn().GetFieldDefn(i).GetName();
      object val = res.Fetch(fieldName).Result;
      // assign value to field according to the result's field type mappings defined in _fieldTypeDelegate
      _fieldTypeDelegate(feature, fieldName, val);
    }
    _layer.CreateFeature(feature);
  }


  // create fields of the appropriate types
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
