using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USACE.HEC.Hazards;
using USACE.HEC.Results;

namespace USACE.HEC.Consequences;
public class Structure : IConsequencesReceptor
{
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
