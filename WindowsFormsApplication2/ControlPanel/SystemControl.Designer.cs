namespace ProsecInc.ControlPanel
{
    partial class SystemControl
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
            this.btnSystemSYSTEM = new System.Windows.Forms.Button();
            this.btnSystemNETZWERK = new System.Windows.Forms.Button();
            this.panelSystemContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnSystemSYSTEM
            // 
            this.btnSystemSYSTEM.BackColor = System.Drawing.Color.Transparent;
            this.btnSystemSYSTEM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSystemSYSTEM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSystemSYSTEM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystemSYSTEM.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSystemSYSTEM.Location = new System.Drawing.Point(375, 430);
            this.btnSystemSYSTEM.Name = "btnSystemSYSTEM";
            this.btnSystemSYSTEM.Size = new System.Drawing.Size(137, 30);
            this.btnSystemSYSTEM.TabIndex = 6;
            this.btnSystemSYSTEM.Text = "SYSTEM";
            this.btnSystemSYSTEM.UseVisualStyleBackColor = false;
            this.btnSystemSYSTEM.Click += new System.EventHandler(this.btnSystemSYSTEM_Click);
            // 
            // btnSystemNETZWERK
            // 
            this.btnSystemNETZWERK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnSystemNETZWERK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnSystemNETZWERK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSystemNETZWERK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSystemNETZWERK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystemNETZWERK.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSystemNETZWERK.Location = new System.Drawing.Point(240, 430);
            this.btnSystemNETZWERK.Name = "btnSystemNETZWERK";
            this.btnSystemNETZWERK.Size = new System.Drawing.Size(137, 30);
            this.btnSystemNETZWERK.TabIndex = 7;
            this.btnSystemNETZWERK.Text = "NETZWERK";
            this.btnSystemNETZWERK.UseVisualStyleBackColor = false;
            this.btnSystemNETZWERK.Click += new System.EventHandler(this.btnSystemNETZWERK_Click);
            // 
            // panelSystemContainer
            // 
            this.panelSystemContainer.Location = new System.Drawing.Point(1, 1);
            this.panelSystemContainer.Name = "panelSystemContainer";
            this.panelSystemContainer.Size = new System.Drawing.Size(747, 422);
            this.panelSystemContainer.TabIndex = 8;
            // 
            // SystemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.panelSystemContainer);
            this.Controls.Add(this.btnSystemSYSTEM);
            this.Controls.Add(this.btnSystemNETZWERK);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "SystemControl";
            this.Size = new System.Drawing.Size(749, 467);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSystemSYSTEM;
        private System.Windows.Forms.Button btnSystemNETZWERK;
        private System.Windows.Forms.Panel panelSystemContainer;

    }
}
