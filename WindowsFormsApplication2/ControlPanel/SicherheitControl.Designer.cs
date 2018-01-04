namespace ProsecInc.ControlPanel
{
    partial class SicherheitControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SicherheitControl));
            this.panelSicherheitContainer = new System.Windows.Forms.Panel();
            this.bunifuImageButtonCloseHelp = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButtonHelp = new Bunifu.Framework.UI.BunifuImageButton();
            this.timerCheckVersion = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButtonCloseHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButtonHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSicherheitContainer
            // 
            this.panelSicherheitContainer.Location = new System.Drawing.Point(0, 64);
            this.panelSicherheitContainer.Name = "panelSicherheitContainer";
            this.panelSicherheitContainer.Size = new System.Drawing.Size(749, 403);
            this.panelSicherheitContainer.TabIndex = 0;
            // 
            // bunifuImageButtonCloseHelp
            // 
            this.bunifuImageButtonCloseHelp.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButtonCloseHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButtonCloseHelp.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButtonCloseHelp.Image")));
            this.bunifuImageButtonCloseHelp.ImageActive = null;
            this.bunifuImageButtonCloseHelp.Location = new System.Drawing.Point(694, 14);
            this.bunifuImageButtonCloseHelp.Name = "bunifuImageButtonCloseHelp";
            this.bunifuImageButtonCloseHelp.Size = new System.Drawing.Size(35, 35);
            this.bunifuImageButtonCloseHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButtonCloseHelp.TabIndex = 28;
            this.bunifuImageButtonCloseHelp.TabStop = false;
            this.bunifuImageButtonCloseHelp.Zoom = 0;
            this.bunifuImageButtonCloseHelp.Click += new System.EventHandler(this.bunifuImageButtonCloseHelp_Click);
            // 
            // bunifuImageButtonHelp
            // 
            this.bunifuImageButtonHelp.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButtonHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButtonHelp.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButtonHelp.Image")));
            this.bunifuImageButtonHelp.ImageActive = null;
            this.bunifuImageButtonHelp.Location = new System.Drawing.Point(694, 14);
            this.bunifuImageButtonHelp.Name = "bunifuImageButtonHelp";
            this.bunifuImageButtonHelp.Size = new System.Drawing.Size(35, 35);
            this.bunifuImageButtonHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButtonHelp.TabIndex = 28;
            this.bunifuImageButtonHelp.TabStop = false;
            this.bunifuImageButtonHelp.Zoom = 0;
            this.bunifuImageButtonHelp.Click += new System.EventHandler(this.bunifuImageButtonHelp_Click_1);
            // 
            // timerCheckVersion
            // 
            this.timerCheckVersion.Enabled = true;
            this.timerCheckVersion.Interval = 30000;
            this.timerCheckVersion.Tick += new System.EventHandler(this.timerCheckVersion_Tick);
            // 
            // SicherheitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.bunifuImageButtonCloseHelp);
            this.Controls.Add(this.bunifuImageButtonHelp);
            this.Controls.Add(this.panelSicherheitContainer);
            this.Name = "SicherheitControl";
            this.Size = new System.Drawing.Size(749, 467);
            this.Load += new System.EventHandler(this.SicherheitControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButtonCloseHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButtonHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSicherheitContainer;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButtonHelp;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButtonCloseHelp;
        private System.Windows.Forms.Timer timerCheckVersion;



    }
}
