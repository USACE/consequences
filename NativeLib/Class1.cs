using System.Runtime.InteropServices;
namespace NativeLib;

public class Class1
{
  [UnmanagedCallersOnly(EntryPoint = "aotsample_add")]
  public static int Add(int a, int b)
  {
    return a + b;
  }


  [UnmanagedCallersOnly(EntryPoint = "aot_write")]
  public static int Write(IntPtr pString)
  {
    try
    {
      string str = Marshal.PtrToStringAnsi(pString);

      Console.WriteLine(str);
    }
    catch
    {
      return -1;
    }
    return 0;
  }
}
