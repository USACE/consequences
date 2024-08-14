namespace Consequences;
public interface IHazard
{
  public bool Has(HazardParameter hp);
  public T Get<T>(HazardParameter hp);
}
