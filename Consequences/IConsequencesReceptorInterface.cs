namespace Consequences;
public interface IConsequencesReceptor<T>
{
  public Result<T> Compute(IHazard hi);
}
