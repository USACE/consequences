using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USACE.HEC.Results;
public class ConsoleWriter : IResultsWriter
{
  private bool hasHeaderWritten = false;
  private List<string> headers = new List<string>();

  // check to make sure the result being written matches the headers already written
  private void CheckIfSameHeaders(Result res)
  {
    // different number of headers
    if (res.GetResultItems().Length != headers.Count)
    {
      throw new InvalidOperationException();
    }
    for (int i = 0; i < headers.Count; i++)
    {
      // headers do not match
      if (res.GetResultItems()[i].ResultName != headers[i])
      {
        throw new InvalidOperationException();
      }
    }
  }
  public void Write(Result res)
  {
    if (!hasHeaderWritten)
    {
      // write the headers to the top of the file
      for (int i = 0; i < res.GetResultItems().Length; i++)
      {
        Console.Write(res.GetResultItems()[i].ResultName);
        if (i < res.GetResultItems().Length - 1)
        {
          Console.Write(',');
        }
        headers.Add(res.GetResultItems()[i].ResultName);
      }
      Console.WriteLine();
      hasHeaderWritten = true;
    }
    CheckIfSameHeaders(res);
    foreach (string header in headers)
    {
      object val = res.Fetch(header).Result;
      Console.Write(val);
      if (header != headers.Last())
      {
        Console.Write(',');
      }
    }
    Console.WriteLine();
  }

  public void Dispose()
  {
    Console.WriteLine("END OF FILE");
  }
}
