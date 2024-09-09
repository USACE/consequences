using System.Text.Json.Serialization;
using USACE.HEC.Geography;
using USACE.HEC.Hazards;
using USACE.HEC.Results;

namespace USACE.HEC.Consequences;
public class Structure : IConsequencesReceptor
{
  [JsonPropertyName("fd_id")]
  public int Name { get; set; }

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

  public Location GetLocation()
  {
    return new Location { X = X, Y = Y };
  }

  public Result Compute(IHazard hazard) 
  {
    List<ResultItem> resultItems = [];

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

    return new Result([.. resultItems]);
  }

  public Result ToResult()
  {
    List<ResultItem> resultItems = [];
    resultItems.Add(new ResultItem { ResultName = "fd_id", Result = Name });
    resultItems.Add(new ResultItem { ResultName = "occtype", Result = Occtype });
    resultItems.Add(new ResultItem { ResultName = "st_damcat", Result = DamCat });
    resultItems.Add(new ResultItem { ResultName = "bldgtype", Result = ConstructionType });
    resultItems.Add(new ResultItem { ResultName = "found_type", Result = FoundationType });
    resultItems.Add(new ResultItem { ResultName = "cbfips", Result = CBFips });
    resultItems.Add(new ResultItem { ResultName = "pop2amu65", Result = Popu65night });
    resultItems.Add(new ResultItem { ResultName = "pop2amo65", Result = Popo65night });
    resultItems.Add(new ResultItem { ResultName = "pop2pmu65", Result = Popu65day });
    resultItems.Add(new ResultItem { ResultName = "pop2pmo65", Result = Popo65day });
    resultItems.Add(new ResultItem { ResultName = "num_story", Result = NumStories });
    resultItems.Add(new ResultItem { ResultName = "found_ht", Result = FoundHt });
    resultItems.Add(new ResultItem { ResultName = "val_struct", Result = StructVal });
    resultItems.Add(new ResultItem { ResultName = "val_cont", Result = ContVal });
    resultItems.Add(new ResultItem { ResultName = "firmzone", Result = FirmZone });
    resultItems.Add(new ResultItem { ResultName = "x", Result = X });
    resultItems.Add(new ResultItem { ResultName = "y", Result = Y });
    resultItems.Add(new ResultItem { ResultName = "ground_elv", Result = GroundElevation });
    return new Result([.. resultItems]);
  }
}
