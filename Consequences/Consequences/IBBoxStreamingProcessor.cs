using USACE.HEC.Geography;

namespace USACE.HEC.Consequences;
public interface IBBoxStreamingProcessor
{
  public void Process(BoundingBox boundingBox, Action<IConsequencesReceptor> consequenceReceptorProcess);
}
