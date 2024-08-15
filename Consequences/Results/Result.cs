namespace USACE.HEC.Results;
public class Result
{
  private ResultItem[] results;

  // retrieve a ResultItem from a Result by name
  public ResultItem Fetch(string name)
  {
    for (int i = 0; i < results.Length; i++)
      if (results[i].ResultName == name)
        return results[i];
    throw new Exception("Name not found.");
  }
}
