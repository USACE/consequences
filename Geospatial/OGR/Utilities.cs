using OSGeo.GDAL;
using OSGeo.OGR;
using OSGeo.OSR;

namespace Geospatial.OGR;
public class Utilities
{
  public static void InitializeGDAL()
  {
    //GDALAssist.GDALSetup.InitializeMultiplatform($"C:\\GDAL");
    Ogr.RegisterAll();
    Gdal.AllRegister();
  }
}

