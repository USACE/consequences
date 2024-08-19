using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USACE.HEC.Results;
public interface IResultsWriter : IDisposable
{
  public void Write(Result res);
}
