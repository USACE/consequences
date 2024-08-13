using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consequences;
public interface IHazardInterface
{
  public bool Has(HazardParameter hp);
  public T Get<T>(HazardParameter hp);
}
