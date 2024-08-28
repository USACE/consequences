using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
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

  public async Task TestProcessStream(BoundingBox boundingBox, Action<IConsequencesReceptor> ConsequenceReceptorProcess)
  {
    await ProcessStream(boundingBox, ConsequenceReceptorProcess);
  }

  public async Task TestProcessCollection(BoundingBox boundingBox, Action<IConsequencesReceptor> ConsequenceReceptorProcess)
  {
    await ProcessCollection(boundingBox, ConsequenceReceptorProcess);
  }

  private string ConstructURL(BoundingBox boundingBox, string directive)
  {
    StringBuilder url = new StringBuilder();

    url.Append("https://nsi.sec.usace.army.mil/nsiapi/structures?bbox=");
    url.Append(boundingBox.NSIFormat());

    // directive to specify collection or stream
    url.Append(directive);

    return url.ToString();
  }

  private async Task ProcessCollection(BoundingBox boundingBox, Action<IConsequencesReceptor> ConsequenceReceptorProcess)
  {
    // endpoint URL
    string apiUrl = ConstructURL(boundingBox, "&fmt=fc");

    // Create an instance of HttpClient
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

  private async Task ProcessStream(BoundingBox boundingBox, Action<IConsequencesReceptor> ConsequenceReceptorProcess)
  {
    // endpoint URL
    string apiURL = ConstructURL(boundingBox, "&fmt=fs");

    using (HttpClient httpClient = new HttpClient())
    {
      try
      {
        // send HTTP GET request
        HttpResponseMessage response = await httpClient.GetAsync(apiURL);
        response.EnsureSuccessStatusCode();

        using (StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync()))
        {
          // read in a line from the stream on by one
          // each individual structure JSON is contained in one line
          string line;
          while ((line = await reader.ReadLineAsync()) != null)
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
        // Handle any errors that occur during the request
        Console.WriteLine($"Request error: {e.Message}");
      }
    }
  }
}
