using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

internal class Program
{
  private static void Main(string[] args)
  {
    Console.WriteLine("===========================TESTING GEOCONSEQUENCES NATIVE LIBRARY===========================");
    TestImport.InitializeGDAL();

    Console.WriteLine("===========================READING FROM THE NSI=============================================");
    TestImport.ReadNSI(-122.48, 37.76, -122.479, 37.759, 0);

    Console.WriteLine("===========================READING FROM THE NSI AND WRITING TO SHAPEFILE====================");
    IntPtr path = Marshal.StringToHGlobalAnsi(@"C:\repos\consequences\AOTTest\generated");
    IntPtr driver = Marshal.StringToHGlobalAnsi("ESRI Shapefile");
    int projection = 3310;
    IntPtr x = Marshal.StringToHGlobalAnsi("x");
    IntPtr y = Marshal.StringToHGlobalAnsi("y");
    TestImport.WriteNSIToShapefile(path, driver, projection, x, y, -122.48, 37.76, -122.479, 37.759);
  }
}

public class TestImport
{
  [DllImport("GeoConsequences.dll")]
  public static extern int ReadNSI(double ulX, double ulY, double lrX, double lrY, int actionIndex);

  [DllImport("GeoConsequences.dll")]
  public static extern int InitializeGDAL();

  [DllImport("GeoConsequences.dll")]
  public static extern int WriteNSIToShapefile(IntPtr outputPath, IntPtr driverName, int projection, IntPtr xField, IntPtr yField, double ulX, double ulY, double lrX, double lrY);

}
