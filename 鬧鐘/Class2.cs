using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Interop;
//using System.Runtime.InteropServices;
namespace 鬧鐘
{
    public class dll
    {
        private Process p=Process.GetCurrentProcess();
        const int VOLUME_MUTE = 0x80000;
        const int VOLUME_DOWN = 0x90000;
        const int VOLUME_UP = 0xA0000;
        //private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        //private const int APPCOMMAND_VOLUME_UP = 0x0a0000;
        //private const int APPCOMMAND_VOLUME_DOWN = 0x090000;
        private const int WM_APPCOMMAND = 0x319;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        public void SetVol()
        {
            
                SendMessageW(p.Handle, WM_APPCOMMAND, p.Handle, (IntPtr)VOLUME_UP);
            
        }
        public void SetVol_dowon()
        {
            
                SendMessageW(p.Handle, WM_APPCOMMAND, p.Handle, (IntPtr)VOLUME_DOWN);
        }

    }
}
