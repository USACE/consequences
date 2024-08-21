using System.Text.Json.Serialization;
using USACE.HEC.Hazards;
using USACE.HEC.Results;

namespace USACE.HEC.Consequences;
public class Structure : IConsequencesReceptor
{
  [JsonPropertyName("fd_id")]
  public string Name { get; set; }

  [JsonPropertyName("st_damcat")]
  public string DamCat { get; set; }

  [JsonPropertyName("cbfips")]
  public string CBFips { get; set; }

  [JsonPropertyName("x")]
  public double X { get; set; }

  [JsonPropertyName("y")]
  public double Y { get; set; }

  [JsonPropertyName("ground_elv")]
  public double GroundElevation { get; set; }

  [JsonPropertyName("occtype")]
  public string Occtype { get; set; }

  [JsonPropertyName("found_type")]
  public string FoundationType { get; set; }

  [JsonPropertyName("firmzone")]
  public string FirmZone { get; set; }

  [JsonPropertyName("bldgtype")]
  public string ConstructionType { get; set; }

  [JsonPropertyName("val_struct")]
  public double StructVal { get; set; }

  [JsonPropertyName("val_cont")]
  public double ContVal { get; set; }

  [JsonPropertyName("found_ht")]
  public double FoundHt { get; set; }

  [JsonPropertyName("num_story")]
  public int NumStories { get; set; }

  [JsonPropertyName("pop2pmo65")]
  public int Popo65day { get; set; }

  [JsonPropertyName("pop2pmu65")]
  public int Popu65day { get; set; }

  [JsonPropertyName("pop2amo65")]
  public int Popo65night { get; set; }

  [JsonPropertyName("pop2amu65")]
  public int Popu65night { get; set; }

  public Result Compute(IHazard hazard) 
  {
    List<ResultItem> resultItems = new List<ResultItem>();

    if (hazard.Has(HazardParameter.Depth))
    {
      resultItems.Add(new ResultItem { 
                                       ResultName = "Depth", 
                                       Result = hazard.Get<float>(HazardParameter.Depth) 
                                     });
    }

    if (hazard.Has(HazardParameter.Velocity))
    {
      resultItems.Add(new ResultItem { 
                                       ResultName = "Velocity", 
                                       Result = hazard.Get<float>(HazardParameter.Velocity) 
                                     });
    }

    if (hazard.Has(HazardParameter.ArrivalTime))
    {
      resultItems.Add(new ResultItem { 
                                       ResultName = "ArrivalTime",                               
                                       Result = hazard.Get<DateTime>(HazardParameter.ArrivalTime) 
                                     });
    }

    if (hazard.Has(HazardParameter.ArrivalTime2ft))
    {
      resultItems.Add(new ResultItem { 
                                       ResultName = "ArrivalTime2ft",
                                       Result = hazard.Get<DateTime>(HazardParameter.ArrivalTime2ft) 
                                     });
    }

    return new Result(resultItems.ToArray());
  }
}
