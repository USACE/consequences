using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consequences;
internal interface IHazardInterface
{
  internal bool Has(HazardParameter hp);
  internal T Get<T>(HazardParameter hp);
}
