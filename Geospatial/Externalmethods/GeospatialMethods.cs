using System.Runtime.InteropServices;
using Geospatial.OGR;
using USACE.HEC.Consequences;
using USACE.HEC.Geography;
using USACE.HEC.Results;


namespace Geospatial.Externalmethods;
public class GeospatialMethods
{
  [UnmanagedCallersOnly(EntryPoint = "InitializeGDAL")]
  public static int Init()
  {
    Console.WriteLine("Setting up GDAL...");
    OGR.Utilities.InitializeGDAL();
    return 0;
  }

  [UnmanagedCallersOnly(EntryPoint = "WriteNSIToShapefile")]
  public static int Write(IntPtr outputPath, IntPtr driverName, int projection, IntPtr xField, IntPtr yField, double ulX, double ulY, double lrX, double lrY)
  {
    string path = Marshal.PtrToStringAnsi(outputPath);
    string driver = Marshal.PtrToStringAnsi(driverName);
    string x  = Marshal.PtrToStringAnsi(xField);
    string y = Marshal.PtrToStringAnsi(yField);
    SpatialWriter sw = new SpatialWriter(path, driver, 4326, projection, x, y);

    Location upperLeft = new Location { X = ulX, Y = ulY };
    Location lowerRight = new Location { X = lrX, Y = lrY };
    BoundingBox boundingBox = new BoundingBox(upperLeft, lowerRight);
    NSIStreamingProcessor sp = new NSIStreamingProcessor();

    Task task = sp.Process(boundingBox, (IConsequencesReceptor s) => {
      Result res = USACE.HEC.Results.Utilities.ConsequenceReceptorToResult<Structure>(s);
      sw.Write(res);
    });
    task.Wait();

    return 0;
  }
}
