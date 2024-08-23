using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using USACE.HEC.Consequences;
using USACE.HEC.Geography;
using USACE.HEC.Hazards;
using USACE.HEC.Results;

namespace ConsequencesTest;
public class NSIStreamingProcessorTest
{
  [Fact]
  public void Test()
  {
    IBBoxStreamingProcessor sp = new NSIStreamingProcessor();
    // int i = 0;
    IHazardProvider depthHazardProvider = new RandomDepthHazardProvider(25);
    IResultsWriter consoleWriter = new ConsoleWriter();

    sp.Process(depthHazardProvider.Extent, (IConsequencesReceptor s) => {
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

  [Fact]
  public void ProcessCollection()
  {;
    IBBoxStreamingProcessor sp = new NSIStreamingProcessor();
    sp.Process(null, (IConsequencesReceptor s) => {

    });
    
  }
  /*
  [Fact]
  public static async Task Ping()
  {
    // endpoint URL
    string apiUrl = "https://nsi.sec.usace.army.mil/nsiapi/structures?bbox=-81.58418,30.25165,-81.58161,30.26939,-81.55898,30.26939,-81.55281,30.24998,-81.58418,30.25165";

    using (var client = new HttpClient())
    {
      // get the json from the NSI
      string jsonResponse = await client.GetStringAsync(apiUrl);

      int count = 0;
      using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
      {
        // access the FeatureCollection
        JsonElement featureCollection = doc.RootElement.GetProperty("features");

        // iterate through the FeatureCollection
        foreach (JsonElement structure in featureCollection.EnumerateArray())
        {
          // access the properties of each structure
          JsonElement propertiesElement = structure.GetProperty("properties");

          // deserialize the properties JSON and create new Structure() object
          Structure? s = JsonSerializer.Deserialize<Structure>(propertiesElement.GetRawText());
          count++;
        }
      }
      Assert.Equal(2735, count);
    }
  }

  [Fact]
  public static async Task ProcessCollection()
  {
    // endpoint URL
    string apiUrl = "https://nsi.sec.usace.army.mil/nsiapi/structures?bbox=-81.58418,30.25165,-81.58161,30.26939,-81.55898,30.26939,-81.55281,30.24998,-81.58418,30.25165";

    using (var client = new HttpClient())
    {
      // get the json from the NSI
      string jsonResponse = await client.GetStringAsync(apiUrl);

      using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
      {
        // access the FeatureCollection
        JsonElement featureCollection = doc.RootElement.GetProperty("features");

        // iterate through the FeatureCollection
        foreach (JsonElement structure in featureCollection.EnumerateArray())
        {
          // access the properties of each structure
          JsonElement propertiesElement = structure.GetProperty("properties");

          // deserialize the properties JSON and create new Structure() object
          Structure? s = JsonSerializer.Deserialize<Structure>(propertiesElement.GetRawText());
        }
      }
    }
  }
  */
}
