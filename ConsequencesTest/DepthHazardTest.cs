using USACE.HEC.Hazards;

namespace ConsequencesTest;
public class DepthHazardTest
{
  [Fact]
  public void Test() 
  {
    DepthHazard dh = new DepthHazard(1.01f);
    bool has = dh.Has(HazardParameter.Depth);
    float depth = dh.Get<float>(HazardParameter.Depth);


  }
}
