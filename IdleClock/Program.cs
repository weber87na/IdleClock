using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdleClock
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault( false );

            Mutex m = new Mutex(true, "混水摸魚計時器", out bool created);

            //程式的沒開的話才跑進來
            if (created != true)
            {
                //找這個 window 的指標 (instance)
                var findWindow = FindWindow(null, "混水摸魚計時器");
                if (findWindow != IntPtr.Zero)
                {
                    //這邊要加上 ShowWindowAsync 這樣子如果縮小成右下角的 Notify Icon 才會有顯示的效果
                    //https://dotblogs.com.tw/chou/2009/06/30/9049
                    ShowWindowAsync( findWindow, WS_SHOWNORMAL );

                    //設定到前景
                    SetForegroundWindow(findWindow);
                }
                Environment.Exit(0);
            }

            Application.Run( new FormIdleClock( ) );
        }


        [DllImport( "user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindow( string lpClassName, string lpWindowName );

        [DllImport("User32.dll" , CharSet = CharSet.Unicode)]   
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);   

        [DllImport("User32.dll" , CharSet = CharSet.Unicode)]   
        private static extern bool SetForegroundWindow(IntPtr hWnd);   
        private const int WS_SHOWNORMAL = 1;  

    }
}
