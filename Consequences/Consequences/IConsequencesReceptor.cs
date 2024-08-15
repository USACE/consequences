using USACE.HEC.Hazards;
using USACE.HEC.Results;

namespace USACE.HEC.Consequences;
public interface IConsequencesReceptor
{
  public Result Compute(IHazard hi);
}
