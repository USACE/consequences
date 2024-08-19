using USACE.HEC.Hazards;
using Xunit.Sdk;

namespace ConsequencesTest;
public class LifeLossHazardTest
{
  IHazard llh = new LifeLossHazard(1.01f, 1.01f, DateTime.Now);

  [Fact]
  public void TestHasCorrectParameter()
  {
    Assert.True(llh.Has(HazardParameter.Depth));
    Assert.True(llh.Has(HazardParameter.Velocity));
    Assert.True(llh.Has(HazardParameter.ArrivalTime2ft));
    // compound parameter, must have all individual parameters to pass
    Assert.True(llh.Has(HazardParameter.Depth | HazardParameter.Velocity));
  }

  [Fact]
  public void TestHasIncorrectParameter()
  {
    Assert.False(llh.Has(HazardParameter.ArrivalTime));
    // compound parameter, must have all individual parameters to pass
    Assert.False(llh.Has(HazardParameter.ArrivalTime | HazardParameter.Depth));
  }
}

