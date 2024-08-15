﻿namespace USACE.HEC.Results;
public class ResultItem<T>
{
  private string resultName;
  private T result;

  public ResultItem(string name, T res)
  {
    resultName = name;
    result = res;
  }

  public string Name()
  {
    return resultName;
  }
  public T Value()
  {
    return result;
  }
}