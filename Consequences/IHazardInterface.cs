namespace Consequences;
public interface IHazardInterface
{
  public bool Has(HazardParameter hp);
  public T Get<T>(HazardParameter hp);
}
