using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USACE.HEC.Geography;
using USACE.HEC.Hazards;

namespace ConsequencesTest;
public class RandomDepthHazardProviderTest
{
  [Fact]
  public void ExtentTest()
  {
    IHazardProvider depthProvider = new RandomDepthHazardProvider(26);

    BoundingBox box = depthProvider.Extent();

    Assert.Equal(0, box.GetUpperLeft().X);
    Assert.Equal(0, box.GetUpperLeft().Y);
    Assert.Equal(0, box.GetLowerRight().X);
    Assert.Equal(0, box.GetLowerRight().Y);
  }

  [Fact]
  public void DepthTest()
  {
    // seeded randomly generated depths to ensure consistency when testing
    int seed = 26;
    IHazardProvider randomDepthProvider = new RandomDepthHazardProvider(seed);
    Location location1 = new Location { X = 100, Y = 50 };
    Location location2 = new Location { X = 0, Y = 40 };

    IHazard depthHazard1 = randomDepthProvider.Hazard(location1);
    IHazard depthHazard2 = randomDepthProvider.Hazard(location2);

    Assert.Equal(3.78371286f, depthHazard1.Get<float>(HazardParameter.Depth));
    Assert.Equal(5.01588488f, depthHazard2.Get<float>(HazardParameter.Depth));
  }
}
