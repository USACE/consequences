using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USACE.HEC.Geography;

namespace USACE.HEC.Consequences;
public class NSIStreamingProcessor : IBBoxStreamingProcessor
{
  public void Process(BoundingBox boundingBox, Action<IConsequencesReceptor> ConsequenceReceptorProcess)
  {
    Structure s = new Structure();
    ConsequenceReceptorProcess(s);
  }



  /*
  static async Task Test()
  {
    // Define the API endpoint
    string apiEndpoint = "https://nsi.sec.usace.army.mil/nsiapi/structures?bbox=-81.58418,30.25165,-81.58161,30.26939,-81.55898,30.26939,-81.55281,30.24998,-81.58418,30.25165";

    // Create an instance of HttpClient
    using (HttpClient client = new HttpClient())
    {
      try
      {
        // Make the GET request
        HttpResponseMessage response = await client.GetAsync(apiEndpoint);

        // Check if the request was successful
        response.EnsureSuccessStatusCode();

        // Read and process the response content
        string responseBody = await response.Content.ReadAsStringAsync();

        // Output the response content (for demonstration purposes)
        Console.WriteLine("API Response:");
        Console.WriteLine(responseBody);
      }
      catch (HttpRequestException e)
      {
        // Handle any errors that occur during the request
        Console.WriteLine($"Request error: {e.Message}");
      }
    }
  }
  */
}
