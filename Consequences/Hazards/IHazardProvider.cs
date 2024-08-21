using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USACE.HEC.Geography;

namespace USACE.HEC.Hazards;

public  interface IHazardProvider
{
  public BoundingBox Extent();
  public IHazard Hazard(Location location);
}
