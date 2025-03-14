using OSGeo.OGR;
using OSGeo.OSR;
using USACE.HEC.Geography;

namespace Geospatial.GDALHelpers;
public class Vector
{
  public string FileName { get; set; }
  private readonly DataSource datasource;
  private readonly Layer layer;

  public Vector(string fileName)
  {
    FileName = fileName;
    datasource = Ogr.Open(fileName, 0);
    layer = datasource.GetLayerByIndex(0);
  }

  public SpatialReference GetProjection()
  {
    return layer.GetSpatialRef();
  }

  public Location[] ToPoints()
  {
    List<Location> points = new();
    Feature feature;
    while ((feature = layer.GetNextFeature()) != null)
    {
      Geometry geometry = feature.GetGeometryRef();
      if (geometry.GetGeometryType() == wkbGeometryType.wkbPoint)
      {
        Location pt = new();
        pt.X = geometry.GetX(0);
        pt.Y = geometry.GetY(0);
        points.Add(pt);
      }
    }
    return points.ToArray();
  }
}
