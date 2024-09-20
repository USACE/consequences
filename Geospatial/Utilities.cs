using OSGeo.OGR;
using OSGeo.OSR;

namespace Geospatial;
public class Utilities
{
  public static void InitializeGDAL()
  {
    GDALAssist.GDALSetup.InitializeMultiplatform();
  }
}

