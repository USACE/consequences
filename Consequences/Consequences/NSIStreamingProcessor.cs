using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using USACE.HEC.Geography;


namespace USACE.HEC.Consequences;
public class NSIStreamingProcessor : IBBoxStreamingProcessor
{
  public async Task Process(BoundingBox boundingBox, Action<IConsequencesReceptor> ConsequenceReceptorProcess)
  {
    await ProcessStream(boundingBox, ConsequenceReceptorProcess);
    //await ProcessCollection(boundingBox, ConsequenceReceptorProcess);
  }

  private static async Task ProcessCollection(BoundingBox boundingBox, Action<IConsequencesReceptor> ConsequenceReceptorProcess)
  {
    // endpoint URL
    string apiUrl = "https://nsi.sec.usace.army.mil/nsiapi/structures?bbox=-81.58418,30.25165,-81.58161,30.26939,-81.55898,30.26939,-81.55281,30.24998,-81.58418,30.25165";

    using (HttpClient client = new HttpClient())
    {
      try
      {
        // send HTTP GET request, read in the entire json into a string
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
            Structure s = JsonSerializer.Deserialize<Structure>(propertiesElement.GetRawText());

            // apply the action to the deserialized structure
            ConsequenceReceptorProcess(s);
          }
        }
      }
      catch (Exception e)
      {
        Console.WriteLine($"Request error: {e.Message}");
      }
    }
  }

  private static async Task ProcessStream(BoundingBox boundingBox, Action<IConsequencesReceptor> ConsequenceReceptorProcess)
  {
    // endpoint URL
    string apiURL = "https://nsi.sec.usace.army.mil/nsiapi/structures?bbox=-81.58418,30.25165,-81.58161,30.26939,-81.55898,30.26939,-81.55281,30.24998,-81.58418,30.25165&fmt=fs";
    using (HttpClient httpClient = new HttpClient())
    {
      try
      {
        // send HTTP GET request
        HttpResponseMessage response = await httpClient.GetAsync(apiURL);
        response.EnsureSuccessStatusCode();

        using (StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync()))
        {
          string line;
          while ((line = reader.ReadLine()) != null)
          {
            //Console.WriteLine(line);
            //Console.WriteLine("********************");
            using (JsonDocument structure = JsonDocument.Parse(line))
            {
              JsonElement propertiesElement = structure.RootElement.GetProperty("properties");
              // deserialize the properties JSON and create new Structure() object
              Structure s = JsonSerializer.Deserialize<Structure>(propertiesElement.GetRawText());

              // apply the action to the deserialized structure
              ConsequenceReceptorProcess(s);
            }
          }
        }
      }
      catch (Exception e)
      {
        Console.WriteLine($"Request error: {e.Message}");
      }
    }
  }
}
