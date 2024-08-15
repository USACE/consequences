namespace USACE.HEC.Results;
public class Result
{
  private ResultItem[] _results;

  public Result(ResultItem[] results)
  { 
    _results = results;
  }

  // retrieve a ResultItem from a Result by name
  public ResultItem Fetch(string name)
  {
    for (int i = 0; i < _results.Length; i++)
      if (_results[i].ResultName == name)
        return _results[i];
    // return empty ResultItem if not found
    ResultItem item = new ResultItem();
    item.ResultName = name;
    return item;
  }
}
