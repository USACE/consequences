using USACE.HEC.Hazards;
using Xunit.Sdk;

namespace ConsequencesTest;
public class LifeLossHazardTest
{
  [Fact]
  public void TestHas()
  {
    IHazard dh = new LifeLossHazard(1.01f, 1.01f, DateTime.Now);

    Assert.True(dh.Has(HazardParameter.Depth));
    Assert.True(dh.Has(HazardParameter.Velocity));
    Assert.True(dh.Has(HazardParameter.ArrivalTime2ft));

  }
}

