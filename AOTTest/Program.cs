using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

internal class Program
{
  private static void Main(string[] args)
  {
    Console.WriteLine("===========================TESTING ARBITRARY NATIVE LIBRARY=================================");
    Console.WriteLine(FirstTest.aotsample_add(1,2));
    IntPtr ptr = Marshal.StringToCoTaskMemAnsi("hi");
    FirstTest.aot_write(ptr);

    Console.WriteLine("===========================TESTING GEOCONSEQUENCES NATIVE LIBRARY===========================\r\n");
    SecondTest.InitializeGDAL();

    Console.WriteLine("===========================READING A SHAPEFILE==============================================");
    SecondTest.ReadFile();

    Console.WriteLine("===========================READING FROM THE NSI AND WRITING RESULTS TO SHAPEFILE============");
    SecondTest.ReadNSI();
  }
}

public class FirstTest
{
  [DllImport("NativeLib.dll")]
  public static extern int aotsample_add(int a, int b);

  [DllImport("NativeLib.dll")]
  public static extern int aot_write(IntPtr pString);
}


public class SecondTest
{
  [DllImport("GeoConsequences.dll")]
  public static extern int ReadNSI();

  [DllImport("GeoConsequences.dll")]
  public static extern int ReadFile();

  [DllImport("GeoConsequences.dll")]
  public static extern int InitializeGDAL();
}
