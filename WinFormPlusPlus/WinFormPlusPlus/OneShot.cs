using System;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace WinFormPlusPlus
{
  public class OneShot : IDisposable 
  {
    private readonly Timer _timer;
    private readonly int _delay;
    
    public OneShot(Control c, Action<Control> callback, int delay)
    {
      _timer = new Timer(o => c.BeginInvokeIfRequired(callback));
      _delay = delay;
    }

    public void Reset()
    {
      _timer.Change(_delay, 0);
    }

    #region IDisposable Members

    public void Dispose()
    {
      _timer.Dispose();
    }

    #endregion
  }

}
