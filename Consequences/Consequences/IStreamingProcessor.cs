using USACE.HEC.Geography;

namespace USACE.HEC.Consequences;
public interface IStreamingProcessor
{
  public void Process(Action<IConsequencesReceptor> consequenceReceptorProcess);
}
