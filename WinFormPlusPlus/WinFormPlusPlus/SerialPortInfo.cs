using System;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;

namespace WinFormPlusPlus
{
  public class SerialPortInfo
  {
    [DllImport("kernel32.dll")]
    private static extern uint QueryDosDevice(string lpDeviceName, StringBuilder lpTargetPath, int ucchMax);

    public string Name { get; private set; }
    public string Info { get; private set; }

    public SerialPortInfo(string name)
    {
      Name = name;
      var portInfo = new StringBuilder(byte.MaxValue);
      var result = QueryDosDevice(name, portInfo, portInfo.Capacity);
      Info = (result != 0 ? portInfo.ToString().Replace(@"\Device\", "") : "N/A " + Marshal.GetLastWin32Error());
    }

    public override string ToString()
    {
      return Name + " (" + Info + ")";
    }

    public static SerialPortInfo[] GetSerialPorts()
    {
      return Array.ConvertAll(SerialPort.GetPortNames(), portName => new SerialPortInfo(portName));
    }
  }
}

