using USACE.HEC.Results;
using USACE.HEC.Consequences;
using USACE.HEC.Hazards;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace ConsequencesTest;
public class StructureTest
{
  [Fact]
  public void Compute_SimpleDepth()
  {
    Structure s = new Structure();
    IHazard dh = new DepthHazard(4.56f);

    Result res = s.Compute(dh);
    ResultItem item1 = res.Fetch("Depth");

    Assert.Equal("Depth", item1.ResultName);
    Assert.Equal(typeof(float), item1.Result.GetType());
    Assert.Equal(4.56f, item1.Result);
  }

  [Fact]
  public void Compute_ArrayDepth_CorrectConsoleOutput()
  {
    Structure s = new Structure(); 
    DepthHazard[] depthHazardArray =
    {
      new DepthHazard(3.45f),
      new DepthHazard(6.89f),
      new DepthHazard(42.6f),
      new DepthHazard(0.001f),
      new DepthHazard(5.55f),
      new DepthHazard(100.45f),
      new DepthHazard(0.2f),
      new DepthHazard(23.23f)
    };
    string expectedConsoleOutput = "Depth\r\n";
    string actualOutput = "";
    ConsoleWriter cw = new ConsoleWriter();

    using (cw)
    {
      foreach (DepthHazard depthHazard in depthHazardArray)
      {
        Result res = s.Compute(depthHazard);

        ResultItem depthItem = res.Fetch("Depth");
        Assert.Equal("Depth", depthItem.ResultName);
        Assert.Equal(typeof(float), depthItem.Result.GetType());
        Assert.Equal(depthHazard.Get<float>(HazardParameter.Depth), depthItem.Result); 
        
        expectedConsoleOutput += depthItem.Result.ToString() + "\r\n";
        actualOutput += cw.WriteString(res);
      }
    }
    // can't test EOF here because it is written to console and not a string, but can confirm
    // it is written to console
    // expectedConsoleOutput += "END OF FILE\r\n";

    Assert.Equal(expectedConsoleOutput, actualOutput);
  }

  
  [Fact]
  public void Compute_ArrayLifeLoss_CorrectConsoleOutput()
  {
    Structure s = new Structure();
    LifeLossHazard[] lifeLossHazardArray =
    {
      new LifeLossHazard(3.45f, 52.6f, new DateTime(2024, 8, 20)),
      new LifeLossHazard(6.89f, 5.6f, new DateTime(1999, 9, 12)),
      new LifeLossHazard(42.6f, 12.2f, new DateTime(2000, 10, 3)),
      new LifeLossHazard(0.001f, 0.0002f, new DateTime(2002, 1, 18)),
      new LifeLossHazard(5.55f, 90.4f, new DateTime(1600, 3, 3)),
      new LifeLossHazard(100.45f, 1.5f, new DateTime(1492, 6, 7)),
      new LifeLossHazard(0.2f, 5.55f, new DateTime(1989, 4, 16)),
      new LifeLossHazard(23.23f, 8.88f, new DateTime(1800, 7, 25))
    };
    string expectedConsoleOutput = "Depth,Velocity,ArrivalTime2ft\r\n";
    string actualOutput = "";
    ConsoleWriter cw = new ConsoleWriter();

    using (cw)
    {
      foreach (LifeLossHazard lifeLossHazard in lifeLossHazardArray)
      {
        Result res = s.Compute(lifeLossHazard);

        ResultItem depthItem = res.Fetch("Depth");
        Assert.Equal("Depth", depthItem.ResultName);
        Assert.Equal(typeof(float), depthItem.Result.GetType());
        Assert.Equal(lifeLossHazard.Get<float>(HazardParameter.Depth), depthItem.Result);

        ResultItem velocityItem = res.Fetch("Velocity");
        Assert.Equal("Velocity", velocityItem.ResultName);
        Assert.Equal(typeof(float), velocityItem.Result.GetType());
        Assert.Equal(lifeLossHazard.Get<float>(HazardParameter.Velocity), velocityItem.Result);

        ResultItem arrivalTime2ftItem = res.Fetch("ArrivalTime2ft");
        Assert.Equal("ArrivalTime2ft", arrivalTime2ftItem.ResultName);
        Assert.Equal(typeof(DateTime), arrivalTime2ftItem.Result.GetType());
        Assert.Equal(lifeLossHazard.Get<DateTime>(HazardParameter.ArrivalTime2ft), arrivalTime2ftItem.Result);

        expectedConsoleOutput += depthItem.Result.ToString() + ',';
        expectedConsoleOutput += velocityItem.Result.ToString() + ',';
        expectedConsoleOutput += arrivalTime2ftItem.Result.ToString() + "\r\n";
        actualOutput += cw.WriteString(res);
      }
    }
    // can't test EOF here because it is written to console and not a string, but can confirm
    // it is written to console
    // expectedConsoleOutput += "END OF FILE\r\n";

    Assert.Equal(expectedConsoleOutput, actualOutput);
  }
  
}
