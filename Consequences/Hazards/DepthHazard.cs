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
    // assumes get will always ask for a single parameter
    // passing in a compound HazardParameter will throw an exception
    if (typeof(T) == typeof(float))
    {
      if (hp == HazardParameter.Depth)
      {
        // compiler cannot prove T is float at compile time
        return (T)(object)_depth;
      }
      else
      {
        throw new NotSupportedException();
      }
    }
    else
    {
      throw new InvalidCastException();
    }
  }
}
