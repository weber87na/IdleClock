
namespace IdleClock
{
    partial class FormIdleClock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelIdle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelIdle
            // 
            this.labelIdle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelIdle.Font = new System.Drawing.Font("Microsoft JhengHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelIdle.Location = new System.Drawing.Point(0, 0);
            this.labelIdle.Name = "labelIdle";
            this.labelIdle.Size = new System.Drawing.Size(484, 61);
            this.labelIdle.TabIndex = 0;
            this.labelIdle.Text = "耍廢時數 : 0 秒";
            this.labelIdle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormIdleClock
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 61);
            this.Controls.Add(this.labelIdle);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormIdleClock";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "混水摸魚計時器";
            this.Load += new System.EventHandler(this.FormIdleClock_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelIdle;
    }
}

