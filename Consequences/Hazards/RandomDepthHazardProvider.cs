using USACE.HEC.Geography;

namespace USACE.HEC.Hazards;
public class RandomDepthHazardProvider : IHazardProvider
{
  private BoundingBox _bbox;

  private Random _rng;

  public RandomDepthHazardProvider(int seed)
  {
    _rng = new Random(seed);
  }

  public BoundingBox Extent
  {
    get { return _bbox; }
    set { _bbox = value; }
  }

  public IHazard Hazard(Location location)
  {
    // generate random depth float between 1 and 10
    double depth = 1.0 + (_rng.NextDouble() * 9.0);
    return new DepthHazard((float)depth);
  }
}
