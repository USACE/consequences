using USACE.HEC.Hazards;
using USACE.HEC.Results;

namespace USACE.HEC.Consequences;
public interface IConsequencesReceptor<T>
{
  public Result Compute(IHazard hi);
}
