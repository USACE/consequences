using USACE.HEC.Geography;

namespace USACE.HEC.Consequences;
public interface IStreamingProcessor
{
  public void Process<T>(Action<IConsequencesReceptor> consequenceReceptorProcess) where T : IConsequencesReceptor, new();
}
