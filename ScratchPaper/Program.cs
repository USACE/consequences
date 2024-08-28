using USACE.HEC.Consequences;
using USACE.HEC.Geography;

internal class Program
{
  private static async Task Main(string[] args)
  {
    // city block in Sunset District, SF
    Location upperLeft1 = new Location { X = -122.475275, Y = 37.752394 };
    Location lowerRight1 = new Location { X = -122.473523, Y = 37.750642 };
    BoundingBox boundingBox1 = new BoundingBox(upperLeft1, lowerRight1);


    Location upperLeft2 = new Location { X = -122.5, Y = 37.8 };
    Location lowerRight2 = new Location { X = -122, Y = 37.3 };
    BoundingBox boundingBox2 = new BoundingBox(upperLeft2, lowerRight2);

    IBBoxStreamingProcessor sp = new NSIStreamingProcessor();

    int count = 0;
    var watch = System.Diagnostics.Stopwatch.StartNew();
    await sp.Process(boundingBox2, (IConsequencesReceptor s) => {
      //Console.WriteLine(((Structure)s).Name);
      count++;
    });
    watch.Stop();
    var elapsedMs = watch.ElapsedMilliseconds;

    Console.WriteLine(count);
    Console.WriteLine("Time elapsed: " + elapsedMs.ToString() + " milliseconds");
    Console.Read(); 
  }
}