using System.Runtime.InteropServices;
using Geospatial.OGR;
using USACE.HEC.Consequences;

namespace Geospatial.Externalmethods;
internal class OGR
{
  [UnmanagedCallersOnly(EntryPoint = "InitializeGDAL")]
  public static int Init()
  {
    Console.WriteLine("Setting up GDAL...");
    Utilities.InitializeGDAL();
    return 0;
  }

  [UnmanagedCallersOnly(EntryPoint = "ReadFile")]
  public static int Read()
  {
    string path = @"C:\Data\Muncie_WS6_Solution_PART2\Muncie_WS6_Part1_Solution_PART2\Muncie_WS6_Part1_Solution\Structure Inventories\Existing_BaseSI\BaseMuncieStructsFinal.shp";
    int count = 0;
    var reader = new SpatialProcessor(path);
    reader.Process<Structure>((s) =>
    {
      Console.WriteLine($"Structure {count}:");
      Console.WriteLine($"  fd_id: {((Structure)s).Name}");
      Console.WriteLine($"  cbfips: {((Structure)s).CBFips}");
      count++;
    });
    return 0;
  }
}
