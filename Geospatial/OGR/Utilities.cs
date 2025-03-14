using OSGeo.GDAL;
using OSGeo.OGR;
using OSGeo.OSR;

namespace Geospatial.OGR;
public class Utilities
{
  public static void InitializeGDAL()
  {
    Ogr.RegisterAll();
    Gdal.AllRegister();
  }

  public static void InitializeGDAL(string path)
  {
    string paths = path + @"\bin64\;";
    Environment.SetEnvironmentVariable("PATH", paths + Environment.GetEnvironmentVariable("PATH"));
    string dataDir = path + @"\common\data\;";
    Environment.SetEnvironmentVariable("GDAL_DATA", dataDir);
    Gdal.SetConfigOption("GDAL_DATA", dataDir);
    Environment.SetEnvironmentVariable("PROJ_LIB", dataDir);
    Gdal.SetConfigOption("PROJ_LIB", dataDir);
    Ogr.RegisterAll();
    Gdal.AllRegister();
  }
}

