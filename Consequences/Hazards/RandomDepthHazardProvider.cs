using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USACE.HEC.Geography;

namespace USACE.HEC.Hazards;
public class RandomDepthHazardProvider : IHazardProvider
{
  private Random _rng;

  public RandomDepthHazardProvider(int seed)
  {
    _rng = new Random(seed);
  }

  public BoundingBox Extent()
  {
    Location upperLeft  = new Location { X = 0, Y = 0 };
    Location lowerRight = new Location { X = 0, Y = 0 };
    return new BoundingBox(upperLeft, lowerRight);
  }

  public IHazard Hazard(Location location)
  {
    // generate random depth float between 1 and 10
    double depth = 1.0 + (_rng.NextDouble() * 9.0);
    return new DepthHazard((float)depth);
  }
}
