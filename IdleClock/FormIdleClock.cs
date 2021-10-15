using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        int idle = 30;
        public FormIdleClock()
        {
            InitializeComponent( );

        }

        Timer timerIdle = new Timer( );
        private void FormIdleClock_Load(object sender, EventArgs e)
        {
            timerIdle.Interval = 1000;
            timerIdle.Tick += TimerIdle_Tick;
            timerIdle.Start( );
        }

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

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }
    }
}
