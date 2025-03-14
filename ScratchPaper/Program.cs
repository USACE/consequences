using USACE.HEC.Consequences;
using USACE.HEC.Geography;
using USACE.HEC.Results;
using Geospatial.OGR;
using Geospatial.GDALHelpers;
using OSGeo.OSR;

internal class Program2
{
  private async static Task Main(string[] args)
  {
    Geospatial.OGR.Utilities.InitializeGDAL(@"C:\Users\HEC\Downloads\jack_GDAL\GDAL");

    Raster r = new("C:\\Users\\HEC\\Documents\\RAS Projects\\Berryessa 2025 Dambreak\\Terrains\\Terrain.Terrain.USGS_13_n39w122_20240313.tif");
    SpatialReference s = r.GetProjection();
    Vector v = new(@"C:\repos\consequences\EventTest\generated\layer_name.shp");
    SpatialReference s2 = v.GetProjection();
    CoordinateTransformation transformation = new CoordinateTransformation(s2, s);

    double longitude = -153722.33; 
    double latitude = 62089.46;    
    
    // Reproject the point
    double[] point = { longitude, latitude }; // {longitude, latitude, 0} (3rd value is z-coordinate)

    // Transform the point
    transformation.TransformPoint(point);
    Console.WriteLine(point[0]);
    Console.WriteLine(point[1]);




    // city blocks in Sunset District, SF
    Location upperLeft1 = new Location { X = -122.48, Y = 37.76 };
    Location lowerRight1 = new Location { X = -122.479, Y = 37.759 };
    BoundingBox boundingBox1 = new BoundingBox(upperLeft1, lowerRight1);

    Location upperLeft2 = new Location { X = -121.74, Y = 38.58 };
    Location lowerRight2 = new Location { X = -121.70, Y = 38.54 };
    BoundingBox boundingBox2 = new BoundingBox(upperLeft2, lowerRight2);

    NSIStreamingProcessor sp = new NSIStreamingProcessor();
    //string filePath = @"C:\repos\consequences\ScratchPaper\generated";
    //using SpatialWriter c = new SpatialWriter(filePath, "ESRI Shapefile", 4326, 3310, "x", "y");
    int count = 0;
    await sp.Process(boundingBox1, (IConsequencesReceptor s) => {
      Console.WriteLine(((Structure)s).Name);
      //Result res = USACE.HEC.Results.Utilities.ConsequenceReceptorToResult<Structure>(s);
      //c.Write(res);
      count++;
    });
    Console.WriteLine(count);
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