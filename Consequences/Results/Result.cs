﻿namespace USACE.HEC.Results;
public class Result
{
  public ResultItem[] ResultItems { get; }

  public Result(ResultItem[] resultItems)
  { 
    ResultItems = resultItems;
  }

  // retrieve a ResultItem from a Result by name
  public ResultItem Fetch(string name)
  {
    for (int i = 0; i < ResultItems.Length; i++)
      if (ResultItems[i].ResultName == name)
        return ResultItems[i];
    // return empty ResultItem if not found
    return new ResultItem { ResultName = name };
  }
}
