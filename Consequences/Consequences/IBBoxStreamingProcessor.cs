using USACE.HEC.Geography;

namespace USACE.HEC.Consequences;
public interface IBBoxStreamingProcessor
{
  public Task Process(BoundingBox boundingBox, Action<IConsequencesReceptor> consequenceReceptorProcess);
}
