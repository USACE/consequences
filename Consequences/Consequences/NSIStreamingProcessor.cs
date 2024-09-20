using System.Text;
using System.Text.Json;
using USACE.HEC.Geography;

namespace USACE.HEC.Consequences;

public class NSIStreamingProcessor : IBBoxStreamingProcessor
{
  public async Task Process(BoundingBox boundingBox, Action<IConsequencesReceptor> ConsequenceReceptorProcess)
  {
    await ProcessStream(boundingBox, ConsequenceReceptorProcess);
  }

  private static string ConstructURL(BoundingBox boundingBox, string directive)
  {
    StringBuilder url = new();

    url.Append("https://nsi.sec.usace.army.mil/nsiapi/structures?bbox=");
    url.Append(boundingBox.NSIFormat());

    // directive to specify collection or stream
    url.Append(directive);

    return url.ToString();
  }


  // this method processes an entire batch from the NSI at once rather than streaming them one by one
  // was tested against ProcessStream and took used significantly more memory with similar times, so we opted to use ProcessStream instead
  private static async Task ProcessCollection(BoundingBox boundingBox, Action<IConsequencesReceptor> ConsequenceReceptorProcess)
  {
    string apiUrl = ConstructURL(boundingBox, "&fmt=fc");

    using HttpClient client = new();
    try
    {
      string jsonResponse = await client.GetStringAsync(apiUrl);

      using JsonDocument doc = JsonDocument.Parse(jsonResponse);

      JsonElement featureCollection = doc.RootElement.GetProperty("features");
      foreach (JsonElement structure in featureCollection.EnumerateArray())
      {
        // access the properties of each structure
        JsonElement propertiesElement = structure.GetProperty("properties");

        Structure s = JsonSerializer.Deserialize(propertiesElement.GetRawText(), SourceGenerationContext.Default.Structure);
        // apply the action to the deserialized structure
        ConsequenceReceptorProcess(s);
      }
    }
    catch (Exception e)
    {
      Console.WriteLine($"Request error: {e.Message}");
    }
  }

  // processes a stream of JSONs from the NSI one by one as opposed to loading in the entire batch
  private static async Task ProcessStream(BoundingBox boundingBox, Action<IConsequencesReceptor> ConsequenceReceptorProcess)
  {
    string apiURL = ConstructURL(boundingBox, "&fmt=fs");

    using HttpClient httpClient = new();
    try
    {
      HttpResponseMessage response = await httpClient.GetAsync(apiURL);
      response.EnsureSuccessStatusCode();

      using StreamReader reader = new(await response.Content.ReadAsStreamAsync());

      // read in a line from the stream on by one
      // each individual structure JSON is contained in one line
      string line;
      while ((line = await reader.ReadLineAsync()) != null)
      {
        using JsonDocument structure = JsonDocument.Parse(line);
        JsonElement propertiesElement = structure.RootElement.GetProperty("properties");
        Structure s = JsonSerializer.Deserialize(propertiesElement.GetRawText(), SourceGenerationContext.Default.Structure);
        // apply the action to the deserialized structure
        ConsequenceReceptorProcess(s);
      }
    }
    catch (Exception e)
    {
      Console.WriteLine($"Request error: {e.Message}");
    }
  }
}
