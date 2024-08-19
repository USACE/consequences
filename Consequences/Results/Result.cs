namespace USACE.HEC.Results;
public class Result
{
  private ResultItem[] _resultItems;

  public Result(ResultItem[] resultItems)
  { 
    _resultItems = resultItems;
  }

  public ResultItem[] GetResultItems()
  {
    return _resultItems;
  }

  // retrieve a ResultItem from a Result by name
  public ResultItem Fetch(string name)
  {
    for (int i = 0; i < _resultItems.Length; i++)
      if (_resultItems[i].ResultName == name)
        return _resultItems[i];
    // return empty ResultItem if not found
    ResultItem item = new ResultItem();
    item.ResultName = name;
    return item;
  }
}
