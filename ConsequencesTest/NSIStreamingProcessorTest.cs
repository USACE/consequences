using System.Text.Json;
using USACE.HEC.Consequences;
using USACE.HEC.Geography;
using USACE.HEC.Hazards;
using USACE.HEC.Results;

namespace ConsequencesTest;

public class NSIStreamingProcessorTest
{
  [Fact]
  public async Task Test()
  {
    IBBoxStreamingProcessor sp = new NSIStreamingProcessor();
    IHazardProvider depthHazardProvider = new RandomDepthHazardProvider(25);
    Location upperLeft1 = new Location { X = -122.475275, Y = 37.752394 };
    Location lowerRight1 = new Location { X = -122.473523, Y = 37.750642 };
    depthHazardProvider.Extent = new BoundingBox(upperLeft1, lowerRight1);
    IResultsWriter consoleWriter = new ConsoleWriter();

    await sp.Process(depthHazardProvider.Extent, (IConsequencesReceptor s) => {
      Result r = s.Compute(depthHazardProvider.Hazard(s.GetLocation()));
      consoleWriter.Write(r);
    });
  }

  [Fact]
  public void JSON_Deserialize()
  {
    string jsonString = """{"type": "Feature","geometry": {"type": "Point","coordinates": [-81.563689, 30.265468]},"properties":{"fd_id":498054345,"bid":"862W7C8P+5GM-0-0-0-0","occtype":"RES1-1SNB","st_damcat":"RES","bldgtype":"M","found_type":"S","cbfips":"120310159233002","pop2amu65":2,"pop2amo65":0,"pop2pmu65":1,"pop2pmo65":0,"sqft":1195,"num_story":1,"ftprntid":"none_242828","ftprntsrc":null,"students":0,"found_ht":0.5,"val_struct":124643.72,"val_cont":62321.8604,"val_vehic":27000,"source":"P","med_yr_blt":2004,"firmzone":null,"o65disable":0.26,"u65disable":0.05,"x":-81.56368862,"y":30.265468241,"ground_elv":27.445583771209716,"ground_elv_m":8.365413665771484}}""";
    Structure? s = new Structure();
    using (JsonDocument doc = JsonDocument.Parse(jsonString))
    {
      // Extract the "properties" section
      JsonElement root = doc.RootElement;
      JsonElement propertiesElement = root.GetProperty("properties");

      // Convert the "properties" section to a JSON string
      string propertiesJson = propertiesElement.GetRawText();

      // Deserialize the "properties" section into the Properties class
      s = JsonSerializer.Deserialize<Structure>(propertiesJson);

    }
    Assert.Equal(498054345, s?.Name);
  }
}
