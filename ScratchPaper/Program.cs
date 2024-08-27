using USACE.HEC.Consequences;
using USACE.HEC.Geography;

internal class Program
{
  private static async Task Main(string[] args)
  {
    // small city block in Sunset District, SF
    Location upperLeft = new Location { X = -122.475275, Y = 37.752394 };
    Location lowerRight = new Location { X = -122.473523, Y = 37.750642 };
    BoundingBox boundingBox = new BoundingBox(upperLeft, lowerRight);

    IBBoxStreamingProcessor sp = new NSIStreamingProcessor();

    int index = 0;
    await sp.Process(boundingBox, (IConsequencesReceptor s) => {
      Console.WriteLine(((Structure)s).StructVal);
      index++;
    });

    Console.Read(); 
  }
}