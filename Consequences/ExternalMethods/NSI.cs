using System.Runtime.InteropServices;
using USACE.HEC.Consequences;
using USACE.HEC.Geography;

namespace USACE.HEC.ExternalMethods;

public class NSI
{
  [UnmanagedCallersOnly(EntryPoint = "ReadNSI")]
  public static int Read()
  {
    // city blocks in Sunset District, SF
    Location upperLeft1 = new Location { X = -122.48, Y = 37.76 };
    Location lowerRight1 = new Location { X = -122.479, Y = 37.759 };
    BoundingBox boundingBox1 = new BoundingBox(upperLeft1, lowerRight1);

    NSIStreamingProcessor sp = new NSIStreamingProcessor();

    int count = 0;

    Task task = sp.Process(boundingBox1, (IConsequencesReceptor s) => {
      Console.WriteLine(((Structure)s).Name);
      count++;
    });

    task.Wait();

    return count;
  }
}
