using System;
using System.Windows.Forms;

namespace WinFormPlusPlus
{
  public static class Utils
  {
    public static void BeginInvokeIfRequired<T>(this T c, Action<T> action) where T : Control
    {
      if (c.InvokeRequired)
      {
        c.BeginInvoke(new MethodInvoker(() => action(c)));
      }
      else
      {
        action(c);
      }
    }

    public static readonly DateTime Epoch = new DateTime(1970, 1, 1);
    public static double MillisecondsSinceEpoch()
    {
      return MillisecondsSinceEpoch(DateTime.Now);
    }

    public static double MillisecondsSinceEpoch(DateTime dt)
    {
      return (dt - Epoch).TotalMilliseconds;
    }

    public static DateTime MillisecondsSinceEpoch(double ms)
    {
      return Epoch + TimeSpan.FromMilliseconds(ms);
    }
  }
}
