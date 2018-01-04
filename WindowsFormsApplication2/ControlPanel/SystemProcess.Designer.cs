namespace ProsecInc.ControlPanel
{
    partial class SystemProcess
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
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemProcess));
            this.bunifuCircleProgressbarCPU = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.bunifuCircleProgressbarRAM = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.bunifuCircleProgressbarHHD = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.performanceCounterCPU = new System.Diagnostics.PerformanceCounter();
            this.performanceCounterRAM = new System.Diagnostics.PerformanceCounter();
            this.timerPerformance = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.performanceCounterDisk = new System.Diagnostics.PerformanceCounter();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounterCPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounterRAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounterDisk)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCircleProgressbarCPU
            // 
            this.bunifuCircleProgressbarCPU.animated = false;
            this.bunifuCircleProgressbarCPU.animationIterval = 1;
            this.bunifuCircleProgressbarCPU.animationSpeed = 100;
            this.bunifuCircleProgressbarCPU.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCircleProgressbarCPU.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCircleProgressbarCPU.BackgroundImage")));
            this.bunifuCircleProgressbarCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.bunifuCircleProgressbarCPU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.bunifuCircleProgressbarCPU.LabelVisible = true;
            this.bunifuCircleProgressbarCPU.LineProgressThickness = 8;
            this.bunifuCircleProgressbarCPU.LineThickness = 5;
            this.bunifuCircleProgressbarCPU.Location = new System.Drawing.Point(24, 113);
            this.bunifuCircleProgressbarCPU.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.bunifuCircleProgressbarCPU.MaxValue = 100;
            this.bunifuCircleProgressbarCPU.Name = "bunifuCircleProgressbarCPU";
            this.bunifuCircleProgressbarCPU.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.bunifuCircleProgressbarCPU.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.bunifuCircleProgressbarCPU.Size = new System.Drawing.Size(187, 187);
            this.bunifuCircleProgressbarCPU.TabIndex = 0;
            this.bunifuCircleProgressbarCPU.Value = 0;
            // 
            // bunifuCircleProgressbarRAM
            // 
            this.bunifuCircleProgressbarRAM.animated = false;
            this.bunifuCircleProgressbarRAM.animationIterval = 5;
            this.bunifuCircleProgressbarRAM.animationSpeed = 300;
            this.bunifuCircleProgressbarRAM.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCircleProgressbarRAM.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCircleProgressbarRAM.BackgroundImage")));
            this.bunifuCircleProgressbarRAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.bunifuCircleProgressbarRAM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(227)))), ((int)(((byte)(194)))));
            this.bunifuCircleProgressbarRAM.LabelVisible = true;
            this.bunifuCircleProgressbarRAM.LineProgressThickness = 8;
            this.bunifuCircleProgressbarRAM.LineThickness = 5;
            this.bunifuCircleProgressbarRAM.Location = new System.Drawing.Point(280, 113);
            this.bunifuCircleProgressbarRAM.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.bunifuCircleProgressbarRAM.MaxValue = 100;
            this.bunifuCircleProgressbarRAM.Name = "bunifuCircleProgressbarRAM";
            this.bunifuCircleProgressbarRAM.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.bunifuCircleProgressbarRAM.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(227)))), ((int)(((byte)(194)))));
            this.bunifuCircleProgressbarRAM.Size = new System.Drawing.Size(187, 187);
            this.bunifuCircleProgressbarRAM.TabIndex = 0;
            this.bunifuCircleProgressbarRAM.Value = 0;
            // 
            // bunifuCircleProgressbarHHD
            // 
            this.bunifuCircleProgressbarHHD.animated = false;
            this.bunifuCircleProgressbarHHD.animationIterval = 5;
            this.bunifuCircleProgressbarHHD.animationSpeed = 300;
            this.bunifuCircleProgressbarHHD.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCircleProgressbarHHD.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCircleProgressbarHHD.BackgroundImage")));
            this.bunifuCircleProgressbarHHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.bunifuCircleProgressbarHHD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(166)))), ((int)(((byte)(35)))));
            this.bunifuCircleProgressbarHHD.LabelVisible = true;
            this.bunifuCircleProgressbarHHD.LineProgressThickness = 8;
            this.bunifuCircleProgressbarHHD.LineThickness = 5;
            this.bunifuCircleProgressbarHHD.Location = new System.Drawing.Point(531, 113);
            this.bunifuCircleProgressbarHHD.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.bunifuCircleProgressbarHHD.MaxValue = 100;
            this.bunifuCircleProgressbarHHD.Name = "bunifuCircleProgressbarHHD";
            this.bunifuCircleProgressbarHHD.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.bunifuCircleProgressbarHHD.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(166)))), ((int)(((byte)(35)))));
            this.bunifuCircleProgressbarHHD.Size = new System.Drawing.Size(187, 187);
            this.bunifuCircleProgressbarHHD.TabIndex = 0;
            this.bunifuCircleProgressbarHHD.Value = 0;
            // 
            // performanceCounterCPU
            // 
            this.performanceCounterCPU.CategoryName = "Processor";
            this.performanceCounterCPU.CounterName = "% Processor Time";
            this.performanceCounterCPU.InstanceName = "_Total";
            // 
            // performanceCounterRAM
            // 
            this.performanceCounterRAM.CategoryName = "Memory";
            this.performanceCounterRAM.CounterName = "% Committed Bytes In Use";
            // 
            // timerPerformance
            // 
            this.timerPerformance.Enabled = true;
            this.timerPerformance.Interval = 1000;
            this.timerPerformance.Tick += new System.EventHandler(this.timerPerformance_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.label4.Location = new System.Drawing.Point(109, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "CPU";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(227)))), ((int)(((byte)(194)))));
            this.label5.Location = new System.Drawing.Point(361, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "RAM";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(166)))), ((int)(((byte)(35)))));
            this.label6.Location = new System.Drawing.Point(611, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "HDD";
            // 
            // performanceCounterDisk
            // 
            this.performanceCounterDisk.CategoryName = "PhysicalDisk";
            this.performanceCounterDisk.CounterName = "% Disk Time";
            this.performanceCounterDisk.InstanceName = "_Total";
            // 
            // SystemProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bunifuCircleProgressbarHHD);
            this.Controls.Add(this.bunifuCircleProgressbarRAM);
            this.Controls.Add(this.bunifuCircleProgressbarCPU);
            this.Name = "SystemProcess";
            this.Size = new System.Drawing.Size(747, 422);
            this.Load += new System.EventHandler(this.SystemProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounterCPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounterRAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounterDisk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCircleProgressbar bunifuCircleProgressbarCPU;
        private Bunifu.Framework.UI.BunifuCircleProgressbar bunifuCircleProgressbarRAM;
        private Bunifu.Framework.UI.BunifuCircleProgressbar bunifuCircleProgressbarHHD;
        private System.Diagnostics.PerformanceCounter performanceCounterCPU;
        private System.Diagnostics.PerformanceCounter performanceCounterRAM;
        private System.Windows.Forms.Timer timerPerformance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Diagnostics.PerformanceCounter performanceCounterDisk;
    }
}
