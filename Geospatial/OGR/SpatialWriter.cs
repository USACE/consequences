using OSGeo.OGR;
using OSGeo.OSR;
using USACE.HEC.Results;

namespace Geospatial.OGR;


public class SpatialWriter : IResultsWriter
{
  private Layer _layer;
  private DataSource _dataSource;
  private SpatialReference _srs;
  private SpatialReference _dst;
  private bool _headersWritten;
  private string _xField;
  private string _yField;

  /// <summary>
  /// SpatialWriter writes spatial results data. X and Y Fields are the ResultItem names of the x and y coordinates. 
  /// </summary>
  public SpatialWriter(string outputPath, string driverName, int projection, string xField, string yField)
  {
    _dataSource = Ogr.GetDriverByName(driverName).CreateDataSource(outputPath, null) ?? throw new Exception("Failed to create data source.");
    _srs = new SpatialReference("");
    _srs.ImportFromEPSG(4326); // WGS84
    if (_srs == null) throw new Exception("Failed to create SpatialReference.");
    _dst = new SpatialReference("");
    _dst.ImportFromEPSG(projection);
    if (_dst == null) throw new Exception("Failed to create SpatialReference.");

    _layer = _dataSource.CreateLayer("layer_name", _dst, wkbGeometryType.wkbPoint, null) ?? throw new Exception("Failed to create layer.");

    _headersWritten = false;

    _xField = xField;
    _yField = yField;
  }

  public void Write(Result res)
  {
    if (!_headersWritten)
    {
      InitializeFields(res);
      _headersWritten = true;
    }

    using var feature = new Feature(_layer.GetLayerDefn());
    using var geometry = new Geometry(wkbGeometryType.wkbPoint);
    double x = (double)res.Fetch(_xField).ResultValue;
    double y = (double)res.Fetch(_yField).ResultValue;
    geometry.AddPoint(y, x, 0);
    // transform the coordinates according to the specified projection
    var ct = new CoordinateTransformation(_srs, _dst);
    geometry.Transform(ct);
    feature.SetGeometry(geometry);

    for (int i = 0; i < _layer.GetLayerDefn().GetFieldCount(); i++)
    {
      string fieldName = _layer.GetLayerDefn().GetFieldDefn(i).GetName();
      object val = res.Fetch(fieldName).ResultValue;
      SetField(feature, fieldName, val);
    }
    _layer.CreateFeature(feature);
  }


  // create fields of the appropriate types
  private void InitializeFields(Result res)
  {
    foreach (ResultItem item in res.ResultItems)
      switch (item.ResultValue)
      {
        case int _:
          _layer.CreateField(new FieldDefn(item.ResultName, FieldType.OFTInteger), 1);
          break;
        case long _:
          _layer.CreateField(new FieldDefn(item.ResultName, FieldType.OFTInteger64), 1);
          break;
        case double _ or float _:
          _layer.CreateField(new FieldDefn(item.ResultName, FieldType.OFTReal), 1);
          break;
        case string _:
          _layer.CreateField(new FieldDefn(item.ResultName, FieldType.OFTString), 1);
          break;
        case DateOnly _:
          _layer.CreateField(new FieldDefn(item.ResultName, FieldType.OFTDate), 1);
          break;
        case TimeOnly _:
          _layer.CreateField(new FieldDefn(item.ResultName, FieldType.OFTTime), 1);
          break;
        case DateTime _:
          _layer.CreateField(new FieldDefn(item.ResultName, FieldType.OFTDateTime), 1);
          break;
        default:
          // for case of a null string
          _layer.CreateField(new FieldDefn(item.ResultName, FieldType.OFTString), 1);
          break;
      }
  }

  private static void SetField(Feature feature, string fieldName, object val)
  {
    switch (val)
    {
      case int _:
        feature.SetField(fieldName, (int)val);
        break;
      case long _:
        feature.SetField(fieldName, (long)val);
        break;
      case double _:
        feature.SetField(fieldName, (double)val);
        break;
      case float _:
        feature.SetField(fieldName, (float)val);
        break;
      case string _:
        feature.SetField(fieldName, (string)val);
        break;
      case null:
        feature.SetField(fieldName, null);
        break;
      default:
        throw new NotSupportedException($"{val.GetType()} not implemented");
    }
  }

  public void Dispose()
  {

  }
}
