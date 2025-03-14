using Geospatial.GDALAssist;

namespace Geospatial;
public class Utilities
{
  public static void InitializeGDAL()
  {
    GDALSetup.InitializeMultiplatform();
  }
}

