using USACE.HEC.Consequences;

internal class Program
{
  private static async Task Main(string[] args)
  {
    IBBoxStreamingProcessor sp = new NSIStreamingProcessor();
    await sp.Process(null, (IConsequencesReceptor s) => {
      Console.WriteLine(((Structure)s).Name);
    });
    Console.Read();
  }
}