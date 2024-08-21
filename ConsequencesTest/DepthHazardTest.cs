using USACE.HEC.Hazards;

namespace ConsequencesTest;
public class DepthHazardTest
{
  static float input = 1.01f;
  IHazard dh = new DepthHazard(input);
  
  [Fact]
  public void TestHasCorrectParameter() 
  {
    Assert.True(dh.Has(HazardParameter.Depth));
  }

  [Fact]
  public void TestHasIncorrectParameter()
  {
    Assert.False(dh.Has(HazardParameter.Velocity));
    Assert.False(dh.Has(HazardParameter.ArrivalTime));
    Assert.False(dh.Has(HazardParameter.ArrivalTime2ft));
    // compound parameter, must have all individual parameters to pass
    Assert.False(dh.Has(HazardParameter.ArrivalTime | HazardParameter.Depth));
  }

  [Fact]
  public void TestGetCorrectValue()
  {
    Assert.Equal(input, dh.Get<float>(HazardParameter.Depth));
  }

  [Fact]
  public void TestGetIncorrectValue()
  {
    Assert.NotEqual(input + 0.1f, dh.Get<float>(HazardParameter.Depth));
    Assert.NotEqual(input * 1.23f, dh.Get<float>(HazardParameter.Depth));
  }

  [Fact]
  public void TestGetInvalidParameter()
  {
    Assert.Throws<NotSupportedException>(() => dh.Get<float>(HazardParameter.ArrivalTime));
    Assert.Throws<NotSupportedException>(() => dh.Get<float>(HazardParameter.Velocity));

  }

  [Fact]
  public void TestGetInvalidType()
  {
    Assert.Throws<InvalidCastException>(() => dh.Get<int>(HazardParameter.Depth));
    Assert.Throws<InvalidCastException>(() => dh.Get<string>(HazardParameter.Depth));
  }
}
