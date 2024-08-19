using System.Diagnostics;
using System.Security.Cryptography;
using USACE.HEC.Hazards;
using USACE.HEC.Results;
using Xunit.Abstractions;
namespace ConsequencesTest;
public class ConsoleWrite
{
  static ResultItem r1 = new ResultItem { ResultName = "Depth", Result = 1.03f };
  static ResultItem r2 = new ResultItem { ResultName = "Velocity", Result = 2.02f };
  static ResultItem r3 = new ResultItem { ResultName = "ArrivalTime2ft", Result = new DateTime() };

  static ResultItem[] resultItems = { r1, r2, r3 };
  Result res = new Result(resultItems);
  [Fact]
  public void TestHeaders()
  {
    var stringWriter = new StringWriter();
    string headers = "Depth,Velocity,ArrivalTime2ft\r\n";
    string row1 = "1.03,2.02,1/1/0001 12:00:00 AM\r\n";
    string eof = "END OF FILE\r\n";

    Console.SetOut(stringWriter);
    using (IResultsWriter cw = new ConsoleWriter())
    {
      // check empty console at first
      Assert.Equal("", stringWriter.ToString());
      cw.Write(res);
      // check for header and row1
      Assert.Equal(headers + row1, stringWriter.ToString());
      cw.Write(res);
      // check for header and then two row1s, and that the header is only written once
      Assert.Equal(headers + row1 + row1, stringWriter.ToString());
    }
    Console.SetOut(Console.Out);
    // check for end of file, confirms that cw was disposed  
    Assert.Equal(headers + row1 + row1 + eof, stringWriter.ToString());
  }

  [Fact]
  public void TestInvalidResult()
  {
    // Result with headers that do not match res
    ResultItem[] bad = { r1, r1, r3 };
    Result invalidResult = new Result(bad);

    IResultsWriter cw = new ConsoleWriter();
    cw.Write(res);

    // throw exception when adding a row with differing headers
    Assert.Throws<InvalidOperationException>(() => cw.Write(invalidResult));
  }
}
