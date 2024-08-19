namespace USACE.HEC.Hazards;
public class LifeLossHazard : IHazard
{
  private float _depth;
  private float _velocity;
  private DateTime _time;

  public LifeLossHazard(float depth, float velocity, DateTime time)
  {
    _depth = depth;
    _velocity = velocity;
    _time = time;
  }

  public bool Has(HazardParameter hp)
  {
    // compound HazardParameter representing all three parameters
    HazardParameter llh = HazardParameter.Depth |
                          HazardParameter.Velocity |
                          HazardParameter.ArrivalTime2ft;
    return (hp & llh) == hp;
  }

  public T Get<T>(HazardParameter hp)
  {
    // assumes get will always ask for a single parameter
    // passing in a compound HazardParameter will throw an exception
    if (typeof(T) == typeof(float))
    {
      // check for valid float-typed parameters
      if (hp == HazardParameter.Depth)
      {
        return (T)(object)_depth;
      }
      else if (hp == HazardParameter.Velocity) 
      { 
        return (T)(object)_velocity; 
      }
      else
      {
        throw new NotSupportedException();
      }
    }
    else if (typeof(T) == typeof(DateTime)) 
    {
      // check for valid DateTime-typed parameters
      if (hp == HazardParameter.ArrivalTime2ft)
      {
        return (T)(object)_time;
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
