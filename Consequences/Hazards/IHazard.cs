namespace USACE.HEC.Hazards;
public interface IHazard
{
  public bool Has(HazardParameter hp);
  public T Get<T>(HazardParameter hp);
}
   