namespace ProsecInc
{
    partial class frmProSec
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProSec));
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelBtnSicherheit = new System.Windows.Forms.Panel();
            this.panelBtnSystem = new System.Windows.Forms.Panel();
            this.panelBtnKontakt = new System.Windows.Forms.Panel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.bunBtnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.lbProSecLogo1 = new System.Windows.Forms.Label();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsProsec = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ntfProsec = new System.Windows.Forms.NotifyIcon(this.components);
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunBtnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            this.cmsProsec.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.Transparent;
            this.panelContainer.ForeColor = System.Drawing.Color.Transparent;
            this.panelContainer.Location = new System.Drawing.Point(1, 233);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(749, 467);
            this.panelContainer.TabIndex = 9;
            // 
            // panelBtnSicherheit
            // 
            //this.panelBtnSicherheit.BackgroundImage = global::ProsecInc.Properties.Resources.head01_active;
            this.panelBtnSicherheit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBtnSicherheit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBtnSicherheit.Location = new System.Drawing.Point(0, 53);
            this.panelBtnSicherheit.Name = "panelBtnSicherheit";
            this.panelBtnSicherheit.Size = new System.Drawing.Size(250, 180);
            this.panelBtnSicherheit.TabIndex = 6;
            this.panelBtnSicherheit.Click += new System.EventHandler(this.panelBtnSicherheit_Click);
            // 
            // panelBtnSystem
            // 
            //this.panelBtnSystem.BackgroundImage = global::ProsecInc.Properties.Resources.head02;
            this.panelBtnSystem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBtnSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBtnSystem.Location = new System.Drawing.Point(250, 53);
            this.panelBtnSystem.Name = "panelBtnSystem";
            this.panelBtnSystem.Size = new System.Drawing.Size(250, 180);
            this.panelBtnSystem.TabIndex = 7;
            this.panelBtnSystem.Click += new System.EventHandler(this.panelBtnSystem_Click);
            // 
            // panelBtnKontakt
            // 
            //this.panelBtnKontakt.BackgroundImage = global::ProsecInc.Properties.Resources.head03;
            this.panelBtnKontakt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBtnKontakt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBtnKontakt.Location = new System.Drawing.Point(499, 53);
            this.panelBtnKontakt.Name = "panelBtnKontakt";
            this.panelBtnKontakt.Size = new System.Drawing.Size(250, 180);
            this.panelBtnKontakt.TabIndex = 8;
            this.panelBtnKontakt.Click += new System.EventHandler(this.panelBtnKontakt_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelTitle.BackgroundImage")));
            this.panelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTitle.Controls.Add(this.bunBtnClose);
            this.panelTitle.Controls.Add(this.lbProSecLogo1);
            this.panelTitle.Controls.Add(this.bunifuImageButton2);
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(750, 56);
            this.panelTitle.TabIndex = 5;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            this.panelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseMove);
            this.panelTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseUp);
            // 
            // bunBtnClose
            // 
            this.bunBtnClose.BackColor = System.Drawing.Color.Transparent;
            this.bunBtnClose.Image = ((System.Drawing.Image)(resources.GetObject("bunBtnClose.Image")));
            this.bunBtnClose.ImageActive = null;
            this.bunBtnClose.Location = new System.Drawing.Point(707, 18);
            this.bunBtnClose.Name = "bunBtnClose";
            this.bunBtnClose.Size = new System.Drawing.Size(22, 19);
            this.bunBtnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunBtnClose.TabIndex = 1;
            this.bunBtnClose.TabStop = false;
            this.bunBtnClose.Zoom = 10;
            this.bunBtnClose.Click += new System.EventHandler(this.bunBtnClose_Click);
            // 
            // lbProSecLogo1
            // 
            this.lbProSecLogo1.AutoSize = true;
            this.lbProSecLogo1.BackColor = System.Drawing.Color.Transparent;
            this.lbProSecLogo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProSecLogo1.ForeColor = System.Drawing.Color.White;
            this.lbProSecLogo1.Location = new System.Drawing.Point(61, 15);
            this.lbProSecLogo1.Name = "lbProSecLogo1";
            this.lbProSecLogo1.Size = new System.Drawing.Size(213, 22);
            this.lbProSecLogo1.TabIndex = 2;
            this.lbProSecLogo1.Text = "ProSec EKTEROS Agent";
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton2.Image")));
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(2, 9);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(61, 34);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 1;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 0;
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // cmsProsec
            // 
            this.cmsProsec.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.cmsProsec.Name = "cmsProsec";
            this.cmsProsec.Size = new System.Drawing.Size(104, 48);
            // 
            // ntfProsec
            // 
            this.ntfProsec.ContextMenuStrip = this.cmsProsec;
            this.ntfProsec.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfProsec.Icon")));
            this.ntfProsec.Visible = true;
            this.ntfProsec.DoubleClick += new System.EventHandler(this.TraySystem_ClickNotifyIcon);
            // 
            // frmProSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(750, 701);
            this.Controls.Add(this.panelBtnSicherheit);
            this.Controls.Add(this.panelBtnSystem);
            this.Controls.Add(this.panelBtnKontakt);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProSec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmProSec";
            this.Load += new System.EventHandler(this.frmProSec_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunBtnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            this.cmsProsec.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBtnSicherheit;
        private System.Windows.Forms.Panel panelBtnSystem;
        private System.Windows.Forms.Panel panelBtnKontakt;
        private Bunifu.Framework.UI.BunifuImageButton bunBtnClose;
        private System.Windows.Forms.Label lbProSecLogo1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsProsec;
        internal System.Windows.Forms.NotifyIcon ntfProsec;


    }
}