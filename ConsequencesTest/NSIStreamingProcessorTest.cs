using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using USACE.HEC.Consequences;
using USACE.HEC.Geography;
using USACE.HEC.Hazards;
using USACE.HEC.Results;

namespace ConsequencesTest;
public class NSIStreamingProcessorTest
{
  [Fact]
  public void Test()
  {
    IBBoxStreamingProcessor sp = new NSIStreamingProcessor();
    // int i = 0;
    Location upperLeft = new Location { X = -40, Y = 50 };
    IHazardProvider depthHazardProvider = new RandomDepthHazardProvider(25);
    IResultsWriter consoleWriter = new ConsoleWriter();

    sp.Process(depthHazardProvider.Extent(), (IConsequencesReceptor s) => {
      Result r = s.Compute(depthHazardProvider.Hazard(upperLeft));
      consoleWriter.Write(r);
    });
  }
}
