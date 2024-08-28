using System.Text;

namespace USACE.HEC.Results;
public class ConsoleWriter : IResultsWriter
{
  private bool hasHeaderWritten = false;
  private List<string> headers = new List<string>();

  // check to make sure the result being written matches the headers already written
  // assumes headers are in the same order
  private void CheckIfSameHeaders(Result res)
  {
    // different number of headers
    if (res.ResultItems.Length != headers.Count)
    {
      throw new InvalidOperationException();
    }
    for (int i = 0; i < headers.Count; i++)
    {
      // headers do not match
      if (res.ResultItems[i].ResultName != headers[i])
      {
        throw new InvalidOperationException();
      }
    }
  }

  public string WriteString(Result res)
  {
    StringBuilder output = new();
    if (!hasHeaderWritten)
    {
      // write the headers to the top of the file
      for (int i = 0; i < res.ResultItems.Length; i++)
      {
        //sb.Append(res.GetResultItems()[i].ResultName);
        output.Append(res.ResultItems[i].ResultName);
        if (i < res.ResultItems.Length - 1)
        {
          output.Append(',');
        }
        headers.Add(res.ResultItems[i].ResultName);
      }
      output.Append("\r\n");
      hasHeaderWritten = true;
    }
    CheckIfSameHeaders(res);
    foreach (string header in headers)
    {
      object val = res.Fetch(header).Result;
      output.Append(val.ToString());
      if (header != headers.Last())
      {
        output.Append(',');
      }
    }
    output.Append("\r\n");
    return output.ToString();
  }

  public void Write(Result res)
  {
    Console.Write(WriteString(res));
  }


  public void Dispose()
  {
    Console.WriteLine("END OF FILE");
  }
}
