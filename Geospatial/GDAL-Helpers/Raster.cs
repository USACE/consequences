using OSGeo.GDAL;
using OSGeo.OSR;

namespace Geospatial.GDALHelpers;
public class Raster
{
  public string FileName { get; set; }
  private readonly Dataset dataset;

  public Raster(string fileName)
  {
    FileName = fileName;
    dataset = Gdal.Open(fileName, Access.GA_ReadOnly);
    Console.WriteLine(dataset.RasterCount);
  }

  public SpatialReference GetProjection()
  {
    string wkt = dataset.GetProjectionRef();
    SpatialReference spatialRef = new(null);
    int res = spatialRef.ImportFromWkt(ref wkt);
    if (res == 0)
    {
      return spatialRef;
    } else
    {
      throw new Exception("Failed to get spatial reference");
    }
  }
}
