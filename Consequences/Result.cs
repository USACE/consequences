namespace Consequences;
public struct Result
{
  private ResultItem<object>[] results;

  public ResultItem<object> Fetch(string name)
  {
    for (int i = 0; i < results.Length; i++)
    {
      if (results[i].Name() == name) 
      { 
        return results[i];
      }
    }
    return null;
  }
}
