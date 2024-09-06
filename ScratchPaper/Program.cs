using USACE.HEC.Consequences;
using USACE.HEC.Geography;
using Geospatial;
using USACE.HEC.Results;
using USACE.HEC.Hazards;

internal class Program
{
  private static void Main(string[] args)
  {
    /*
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
    await sp.Process(boundingBox1, (IConsequencesReceptor s) => {
      //Console.WriteLine(((Structure)s).Name);
      count++;
    });
    watch.Stop();
    var elapsedMs = watch.ElapsedMilliseconds;

    Console.WriteLine(count);
    Console.WriteLine("Time elapsed: " + elapsedMs.ToString() + " milliseconds");
    Console.Read();
    */
    Write();
    
  }

  public static void Write()
  {
    SpatialWriter c = new SpatialWriter();
    Structure structure = new Structure();
    DepthHazard haz = new DepthHazard(0.14f);
    Result res = structure.Compute(haz);
    c.Write(res);
  }

  public static void Read()
  {
    SpatialStructureProcessor reader = new SpatialStructureProcessor();
    string path = @"C:\Data\Muncie_WS6_Solution_PART2\Muncie_WS6_Part1_Solution_PART2\Muncie_WS6_Part1_Solution\Structure Inventories\Existing_BaseSI\BaseMuncieStructsFinal.shp";
    int count = 0;
    reader.Process(path, (IConsequencesReceptor s) => {
      Console.WriteLine(((Structure)s).Name);
      count++;
    });
    Console.WriteLine(count);
  }
}