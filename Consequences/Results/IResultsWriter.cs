namespace USACE.HEC.Results;
public interface IResultsWriter : IDisposable
{
  public void Write(Result res);
}
