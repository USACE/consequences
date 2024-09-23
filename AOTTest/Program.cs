using System.Runtime.InteropServices;

internal class Program
{
  private static void Main(string[] args)
  {
    Console.WriteLine(C.X());
    Console.WriteLine(C.aotsample_add(1, 2));
  }

}

public class C
{
  [DllImport("NativeLib.dll")]
  public static extern int aotsample_add(int a, int b);
  public static int X()
  {
    return 0;
  }
}