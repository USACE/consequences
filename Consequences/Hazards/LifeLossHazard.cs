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
    // compound integer representing all three parameters
    HazardParameter llh = HazardParameter.Depth |
                          HazardParameter.Velocity |
                          HazardParameter.ArrivalTime2ft;
    return (hp & llh) == hp;
  }

  public T Get<T>(HazardParameter hp)
  {
    // placeholder
    return (T)(object)_depth;
  }
}
