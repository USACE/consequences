using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
