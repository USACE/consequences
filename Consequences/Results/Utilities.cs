using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.Json.Serialization;
using USACE.HEC.Consequences;

namespace USACE.HEC.Results;
public class Utilities
{
  public static Result ConsequenceReceptorToResult<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(IConsequencesReceptor cr) where T: IConsequencesReceptor
  { 
    List<ResultItem> resultItems = [];

    PropertyInfo[] properties = typeof(T).GetProperties();
    foreach (PropertyInfo property in properties)
    {
      ResultItem item; 
      JsonPropertyNameAttribute jsonPropertyAttribute = property.GetCustomAttribute<JsonPropertyNameAttribute>();
      item.ResultName = jsonPropertyAttribute != null ? jsonPropertyAttribute.Name : property.Name;
      item.ResultValue = property.GetValue(cr);
      resultItems.Add(item);
    }
    Console.WriteLine("hello");
    return new Result([.. resultItems]);
  }
}
