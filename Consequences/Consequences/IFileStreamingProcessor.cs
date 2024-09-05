using USACE.HEC.Geography;

namespace USACE.HEC.Consequences;
public interface IFileStreamingProcessor
{
  public void Process(string filePath, Action<IConsequencesReceptor> consequenceReceptorProcess);
}
