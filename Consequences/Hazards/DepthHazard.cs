namespace USACE.HEC.Hazards;
public class DepthHazard : IHazard
{
  private float _depth;
  public DepthHazard(float depth)
  {
    _depth = depth;
  }

  public bool Has(HazardParameter hp)
  {
    return (hp & HazardParameter.Depth) == hp;
  }

  public T Get<T>(HazardParameter hp)
  {
    // return ((T?)_depth).GetValueOrDefault();
    
    if (!Has(hp)) 
      throw new NotSupportedException();

    if (typeof(T) == typeof(float))
      return (T)(object)_depth;
    else
      throw new InvalidCastException();
      
  }
}
