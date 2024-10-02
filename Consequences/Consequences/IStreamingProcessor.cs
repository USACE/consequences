using System.Diagnostics.CodeAnalysis;
using USACE.HEC.Geography;

namespace USACE.HEC.Consequences;
public interface IStreamingProcessor
{
  public void Process<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(Action<IConsequencesReceptor> consequenceReceptorProcess) where T : IConsequencesReceptor, new();
}
