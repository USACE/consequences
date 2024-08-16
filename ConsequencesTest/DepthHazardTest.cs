using USACE.HEC.Hazards;
using Xunit.Sdk;

namespace ConsequencesTest;
public class DepthHazardTest
{
  [Fact]
  public void TestInterfaceImplementation() 
  {
    float input = 1.01f;
    IHazard dh = new DepthHazard(input);
    bool has = dh.Has(HazardParameter.Depth);
    if (has)
    {
      float depth = dh.Get<float>(HazardParameter.Depth);
      Assert.Equal(input, depth);
    } else
    {
      throw new Exception("Failed to find appropriate parameter");
    }

  }

  [Fact]
  public void TestGetWrongParameter()
  {
    IHazard dh = new DepthHazard(1.01f);
    Assert.Throws<NotSupportedException>(() => dh.Get<float>(HazardParameter.ArrivalTime));

  }
}
