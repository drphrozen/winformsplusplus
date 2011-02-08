using System;
using System.Text;
using System.Windows.Forms;

namespace WinFormPlusPlus
{
  public static class Utils
  {
    public static void BeginInvokeIfRequired<T>(this T c, Action<T> action) where T : Control
    {
      if (c.InvokeRequired)
        c.BeginInvoke(new MethodInvoker(() => action(c)));
      else
        action(c);
    }

    public static string GetProperties<T>(this T o) where T : class
    {
      var sb = new StringBuilder();
      foreach (var property in o.GetType().GetProperties())
      {
        if (property.CanRead == false) continue;
        var propertyValue = property.GetGetMethod().Invoke(o, new object[0]);
        // Avoid properties that returns this object
        if(ReferenceEquals(o, propertyValue)) continue;
        sb.Append(property.Name);
        sb.AppendLine(propertyValue != null ? ": " + propertyValue : " <null>");
      }
      return sb.ToString();
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
