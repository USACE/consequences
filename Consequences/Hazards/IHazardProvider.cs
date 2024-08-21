using USACE.HEC.Geography;

namespace USACE.HEC.Hazards;

public interface IHazardProvider
{
  public BoundingBox Extent();
  public IHazard Hazard(Location location);
}
