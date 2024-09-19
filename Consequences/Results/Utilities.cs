using System.Reflection;
using System.Text.Json.Serialization;
using USACE.HEC.Consequences;

namespace USACE.HEC.Results;
public class Utilities
{
  public static Result ConsequenceReceptorToResult<T>(IConsequencesReceptor cr) where T: IConsequencesReceptor
  { 
    List<ResultItem> resultItems = [];

    PropertyInfo[] properties = typeof(T).GetProperties();
    foreach (PropertyInfo property in properties)
    {
      ResultItem item; 
      JsonPropertyNameAttribute jsonPropertyAttribute = property.GetCustomAttribute<JsonPropertyNameAttribute>();
      item.ResultName = jsonPropertyAttribute != null ? jsonPropertyAttribute.Name : property.Name;
      item.Result = property.GetValue(cr);
      resultItems.Add(item);
    }

    return new Result([.. resultItems]);
  }
}
