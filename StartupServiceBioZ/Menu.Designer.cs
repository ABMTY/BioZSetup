namespace CtrlServiceBioz
{
    partial class Menu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMenu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbxZkteco = new System.Windows.Forms.PictureBox();
            this.pbxDigitalPersona = new System.Windows.Forms.PictureBox();
            this.lblCloseButton = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxZkteco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDigitalPersona)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.panel1.Controls.Add(this.lblCloseButton);
            this.panel1.Controls.Add(this.lblMenu);
            this.panel1.Location = new System.Drawing.Point(-2, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 28);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.ForeColor = System.Drawing.Color.White;
            this.lblMenu.Location = new System.Drawing.Point(18, 4);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(172, 20);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "Asistente Servicio BioZ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione el dispositivo";
            // 
            // pbxZkteco
            // 
            this.pbxZkteco.ErrorImage = global::StartupServiceBioZ.Properties.Resources.digitalPersona;
            this.pbxZkteco.Image = global::StartupServiceBioZ.Properties.Resources.zkteco;
            this.pbxZkteco.InitialImage = null;
            this.pbxZkteco.Location = new System.Drawing.Point(156, 80);
            this.pbxZkteco.Name = "pbxZkteco";
            this.pbxZkteco.Size = new System.Drawing.Size(116, 139);
            this.pbxZkteco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxZkteco.TabIndex = 3;
            this.pbxZkteco.TabStop = false;
            this.pbxZkteco.Click += new System.EventHandler(this.pbxZkteco_Click);
            // 
            // pbxDigitalPersona
            // 
            this.pbxDigitalPersona.Image = global::StartupServiceBioZ.Properties.Resources.digitalPersona;
            this.pbxDigitalPersona.Location = new System.Drawing.Point(13, 80);
            this.pbxDigitalPersona.Name = "pbxDigitalPersona";
            this.pbxDigitalPersona.Size = new System.Drawing.Size(127, 139);
            this.pbxDigitalPersona.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxDigitalPersona.TabIndex = 2;
            this.pbxDigitalPersona.TabStop = false;
            this.pbxDigitalPersona.Click += new System.EventHandler(this.pbxDigitalPersona_Click);
            // 
            // lblCloseButton
            // 
            this.lblCloseButton.AutoSize = true;
            this.lblCloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCloseButton.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloseButton.ForeColor = System.Drawing.Color.White;
            this.lblCloseButton.Location = new System.Drawing.Point(256, 3);
            this.lblCloseButton.Name = "lblCloseButton";
            this.lblCloseButton.Size = new System.Drawing.Size(28, 25);
            this.lblCloseButton.TabIndex = 94;
            this.lblCloseButton.Text = "✕";
            this.lblCloseButton.Click += new System.EventHandler(this.lblCloseButton_Click);
            // 
            // Menu
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pbxZkteco);
            this.Controls.Add(this.pbxDigitalPersona);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxZkteco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDigitalPersona)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbxDigitalPersona;
        private System.Windows.Forms.PictureBox pbxZkteco;
        private System.Windows.Forms.Label lblCloseButton;
    }
}