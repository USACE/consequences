namespace USACE.HEC.Results;
public struct Result<T>
{
  private ResultItem<T>[] results;

  // retrieve a ResultItem from a Result by name
  public ResultItem<T> Fetch(string name)
  {
    for (int i = 0; i < results.Length; i++)
      if (results[i].Name() == name)
        return results[i];
    return null;
  }
}
