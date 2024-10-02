using Microsoft.VisualStudio.TestPlatform.Utilities;
using USACE.HEC.Results;

namespace ConsequencesTest;
public class ConsoleWrite
{
  static ResultItem r1 = new ResultItem { ResultName = "Depth", ResultValue = 1.03f };
  static ResultItem r2 = new ResultItem { ResultName = "Velocity", ResultValue = 2.02f };
  static ResultItem r3 = new ResultItem { ResultName = "ArrivalTime2ft", ResultValue = new DateTime() };
  static ResultItem[] resultItems = { r1, r2, r3 };
  Result res = new Result(resultItems);
  [Fact]
  public void Write_PrintsHeadersOnce()
  {
    string headers = "Depth,Velocity,ArrivalTime2ft\r\n";
    string row1 = "1.03,2.02,1/1/0001 12:00:00 AM\r\n";
    // string eof = "END OF FILE\r\n";
    string output = "";
    ConsoleWriter cw = new ConsoleWriter();

    // changed the tests to test strings and not direct console output
    using (cw)
    {
      output += cw.WriteString(res);
      output += cw.WriteString(res);
    } 
    // can't test EOF here because it is written to console and not a string, but can confirm
    // it is written to console
    Assert.Equal(headers + row1 + row1, output);
  }

  [Fact]
  public void Write_InvalidRowWritten_ThrowsException()
  {
    // Result with headers that do not match res
    ResultItem[] bad = { r1, r1, r3 };
    Result invalidResult = new Result(bad);

    ConsoleWriter cw = new ConsoleWriter();
    cw.WriteString(res);

    // throw exception when adding a row with differing headers
    Assert.Throws<InvalidOperationException>(() => cw.WriteString(invalidResult));
  }
}
