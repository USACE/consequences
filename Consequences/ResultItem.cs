namespace Consequences;
public class ResultItem<T>
{
  private string resultName;
  private T result;

  public string Name()
  { 
    return resultName;
  }
  public T Value() 
  {
    return result;
  }
}
