using USACE.HEC.Consequences;
using USACE.HEC.Geography;
using Geospatial;
using USACE.HEC.Results;

internal class Program
{
  private async static Task Main(string[] args)
  {
    Geospatial.Utilities.InitializeGDAL();


    // city blocks in Sunset District, SF
    Location upperLeft1 = new Location { X = -122.48, Y = 37.76 };
    Location lowerRight1 = new Location { X = -122.47, Y = 37.75 };
    BoundingBox boundingBox1 = new BoundingBox(upperLeft1, lowerRight1);


    Location upperLeft2 = new Location { X = -121.74, Y = 38.58 };
    Location lowerRight2 = new Location { X = -121.70, Y = 38.54 };
    BoundingBox boundingBox2 = new BoundingBox(upperLeft2, lowerRight2);

    NSIStreamingProcessor sp = new NSIStreamingProcessor();
    string filePath = @"C:\repos\consequences\ScratchPaper\generated";

    using SpatialWriter c = new SpatialWriter(filePath, "ESRI Shapefile", 3310, Geospatial.Utilities.StructureFieldTypes);
    int count = 0;

    await sp.Process(boundingBox2, (IConsequencesReceptor s) => {
      //Console.WriteLine(((Structure)s).Name);
      Result res = USACE.HEC.Results.Utilities.ConsequenceReceptorToResult<Structure>(s);
      c.Write(res);
      count++;
    });
    Console.WriteLine(count);
    Console.Read();
    
    //Read();
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