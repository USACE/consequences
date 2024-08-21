using USACE.HEC.Hazards;

namespace ConsequencesTest;
public class LifeLossHazardTest
{
  static float depth = 1.01f;
  static float velocity = 6.03f;
  static DateTime time = new DateTime(2024, 8, 10);
  IHazard llh = new LifeLossHazard(depth, velocity, time);

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

  [Fact]
  public void TestGetCorrectValue()
  {
    Assert.Equal(depth, llh.Get<float>(HazardParameter.Depth));
    Assert.Equal(velocity, llh.Get<float>(HazardParameter.Velocity));
    Assert.Equal(time, llh.Get<DateTime>(HazardParameter.ArrivalTime2ft));
  }

  [Fact]
  public void TestGetIncorrectValue()
  {
    Assert.NotEqual(depth + 0.1f, llh.Get<float>(HazardParameter.Depth));
    Assert.NotEqual(velocity + 0.1f, llh.Get<float>(HazardParameter.Velocity));
    Assert.NotEqual(DateTime.Now, llh.Get<DateTime>(HazardParameter.ArrivalTime2ft));
  }

  [Fact]
  public void TestGetInvalidParameter()
  {
    Assert.Throws<NotSupportedException>(() => llh.Get<DateTime>(HazardParameter.ArrivalTime));
    Assert.Throws<NotSupportedException>(() => llh.Get<float>(HazardParameter.Velocity | HazardParameter.Depth));
  }

  [Fact]
  public void TestGetInvalidType()
  {
    Assert.Throws<InvalidCastException>(() => llh.Get<int>(HazardParameter.Depth));
    Assert.Throws<InvalidCastException>(() => llh.Get<string>(HazardParameter.Velocity));
  }
}

