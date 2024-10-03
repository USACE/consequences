using System.Runtime.InteropServices;
using USACE.HEC.Consequences;
using USACE.HEC.Geography;

namespace USACE.HEC.ExternalMethods;

public class NSI
{
  /// <summary>
  /// Specify (x,y) coordinates for upper left and lower right corners of the bounding box, as well
  /// as an index corresponding to a specific action from a preset list of actions that we define,
  /// to be performed on each structure that gets read (TODO)
  /// </summary>
  [UnmanagedCallersOnly(EntryPoint = "ReadNSI")]
  public static int Read(double ulX, double ulY, double lrX, double lrY, int actionIndex)
  {
    Location upperLeft = new Location { X = ulX, Y = ulY };
    Location lowerRight = new Location { X = lrX, Y = lrY };
    BoundingBox boundingBox = new BoundingBox(upperLeft, lowerRight);

    NSIStreamingProcessor sp = new NSIStreamingProcessor();

    // going forward a user will be able to specify an action on the structures
    int count = 0;
    Task task = sp.Process(boundingBox, (IConsequencesReceptor s) => {
      Console.WriteLine(((Structure)s).Name);
      count++;
    });

    task.Wait();

    return count;
  }
}
