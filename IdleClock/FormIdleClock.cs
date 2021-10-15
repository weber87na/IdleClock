using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdleClock
{
    public partial class FormIdleClock : Form
    {
        //目前的時間 (有點總數的味道)
        int currentIdle = 0;

        //最後一次的閒置時間
        int lastIdle = 0;

        //counter 供給每秒遞增判斷
        int counter = 0;

        //預設閒置秒數
        //int idle = 30;
        int idle = 30;
        public FormIdleClock()
        {
            InitializeComponent( );
        }

        //點選 Exit 時關閉程式
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Environment.Exit( 0 );
        }

        private void ToolStripMenuItemShow_Click(object sender, EventArgs e)
        {
            //this.Show( );
            this.WindowState = FormWindowState.Normal;
            this.Activate( );
        }

        //閒置時間
        Timer timerIdle = new Timer( );
        private void FormIdleClock_Load(object sender, EventArgs e)
        {
            notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            toolStripMenuItemShow.Click += ToolStripMenuItemShow_Click;
            toolStripMenuItemExit.Click += ToolStripMenuItemExit_Click;

            //設定閒置時間
            timerIdle.Interval = 1000;
            timerIdle.Tick += TimerIdle_Tick;
            timerIdle.Start( );

            this.FormClosing += FormIdleClock_FormClosing;
            this.Resize += FormIdleClock_Resize;
        }


        //當觸發視窗變為 normal or mini 時切換摸魚圖示的顯示
        private void FormIdleClock_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                notifyIcon.Visible = false;
            else
                notifyIcon.Visible = true;
        }

        //設定表單按下關閉時不要真的關掉而是縮小到右下角
        private void FormIdleClock_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                notifyIcon.BalloonTipText = "混水摸魚";
                notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon.BalloonTipTitle = "注意!";
                notifyIcon.ShowBalloonTip( 1500 );

                e.Cancel = true;
                //this.Hide( );
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }

        //核心計算閒置時間功能
        private void TimerIdle_Tick(object sender, EventArgs e)
        {
            //每秒 counter 遞增供給非閒置時候進行判斷
            counter++;

            //假設超過 30 秒的話就算是耍廢
            var sec = InputTimer.GetInputIdleTime( ).Seconds;
            if (sec >= idle)
            {
                lastIdle = InputTimer.GetInputIdleTime( ).Seconds;
                labelIdle.Text = $"耍廢時數 : {currentIdle + lastIdle} 秒";
                var icon = new Icon( "fish-pink.ico" );
                notifyIcon.Icon = icon;
                this.Icon = icon;
            }
            else
            {
                //因為每秒都會計算 , 所以用個 counter 判斷秒數是否小於閒置時間
                if (counter >= idle)
                {
                    //回復操作了把最後一次的時間加上去
                    currentIdle = currentIdle + lastIdle;

                    //已經加過了所以設定為 0
                    lastIdle = 0;
                    counter = 0;
                }
            }
        }

        //設定點選右下角摸魚圖示時還原整個視窗
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            this.ShowInTaskbar = true;
            //this.Show( );
            this.Activate( );

        }
    }
}
