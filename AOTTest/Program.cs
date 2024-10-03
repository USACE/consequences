using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

internal class Program
{
  private static void Main(string[] args)
  {
    Console.WriteLine("===========================TESTING GEOCONSEQUENCES NATIVE LIBRARY===========================\r\n");
    SecondTest.InitializeGDAL();

    Console.WriteLine("===========================READING A SHAPEFILE==============================================");
    SecondTest.ReadFile();

    Console.WriteLine("===========================READING FROM THE NSI=============================================");
    SecondTest.ReadNSI(-122.48, 37.76, -122.479, 37.759, 0);
  }
}

public class SecondTest
{
  [DllImport("GeoConsequences.dll")]
  public static extern int ReadNSI(double ulX, double ulY, double lrX, double lrY, int actionIndex);

  [DllImport("GeoConsequences.dll")]
  public static extern int ReadFile();

  [DllImport("GeoConsequences.dll")]
  public static extern int InitializeGDAL();
}
