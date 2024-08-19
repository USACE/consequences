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
      resultItems.Add(new ResultItem { ResultName = "Depth", Result = hazard.Get<float>(HazardParameter.Depth) });
    }

    return new Result(resultItems.ToArray());
  }
}
