using USACE.HEC.Consequences;
using USACE.HEC.Geography;
using USACE.HEC.Results;
using Geospatial.OGR;

internal class Program2
{
  private async static Task Main(string[] args)
  {
    
    Geospatial.OGR.Utilities.InitializeGDAL();


    
    // city blocks in Sunset District, SF
    Location upperLeft1 = new Location { X = -122.48, Y = 37.76 };
    Location lowerRight1 = new Location { X = -122.479, Y = 37.759 };
    BoundingBox boundingBox1 = new BoundingBox(upperLeft1, lowerRight1);


    Location upperLeft2 = new Location { X = -121.74, Y = 38.58 };
    Location lowerRight2 = new Location { X = -121.70, Y = 38.54 };
    BoundingBox boundingBox2 = new BoundingBox(upperLeft2, lowerRight2);

    NSIStreamingProcessor sp = new NSIStreamingProcessor();
    string filePath = @"C:\repos\consequences\ScratchPaper\generated";

    using SpatialWriter c = new SpatialWriter(filePath, "ESRI Shapefile", 3310, "x", "y");
    
    int count = 0;

    
    await sp.Process(boundingBox1, (IConsequencesReceptor s) => {
      //Console.WriteLine(((Structure)s).Name);
      Result res = USACE.HEC.Results.Utilities.ConsequenceReceptorToResult<Structure>(s);
      c.Write(res);
      count++;
    });
    Console.WriteLine(count);
    Console.Read();
    
    /*
    Structure s = new();
    s.Name = 123;
    Result res = USACE.HEC.Results.Utilities.ConsequenceReceptorToResult<Structure>(s);
    c.Write(res);
    


    Read();
    */
  }

  public static void Read()
  {
    
    string path = @"C:\Data\Muncie_WS6_Solution_PART2\Muncie_WS6_Part1_Solution_PART2\Muncie_WS6_Part1_Solution\Structure Inventories\Existing_BaseSI\BaseMuncieStructsFinal.shp";
    int count = 0;
    SpatialProcessor reader = new SpatialProcessor(path);
    reader.Process<Structure>((IConsequencesReceptor s) => {
      Console.WriteLine($"Structure {count}:");
      Console.WriteLine($"  fd_id: {((Structure)s).Name}");
      Console.WriteLine($"  cbfips: {((Structure)s).CBFips}");
      count++;
    });
  }
} 