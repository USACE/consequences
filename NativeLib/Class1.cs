using System.Runtime.InteropServices;
namespace NativeLib;

public class Class1
{
  [UnmanagedCallersOnly(EntryPoint = "aotsample_add")]
  public static int Add(int a, int b)
  {
    return a + b;
  }
}
