using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USACE.HEC.Results;
using USACE.HEC.Consequences;
using USACE.HEC.Hazards;

namespace ConsequencesTest;
public class StructureTest
{
  [Fact]
  public void TestSimpleDepth()
  {
    Structure s = new Structure();
    IHazard dh = new DepthHazard(4.56f);
    Result res = s.Compute(dh);
    ResultItem item1 = res.Fetch("Depth");

    Assert.Equal("Depth", item1.ResultName);
    Assert.Equal(typeof(float), item1.Result.GetType());
    Assert.Equal(4.56f, item1.Result);
  }
}
