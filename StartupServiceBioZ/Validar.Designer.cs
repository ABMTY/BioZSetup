namespace Enrollment {
    partial class Validar {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label StatusLabel;
            System.Windows.Forms.Label PromptLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Validar));
            this.CloseButton = new System.Windows.Forms.Button();
            this.StatusLine = new System.Windows.Forms.Label();
            this.StatusText = new System.Windows.Forms.TextBox();
            this.Prompt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCloseButton = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDispositivos = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHoraFecha = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pcbCamara = new System.Windows.Forms.PictureBox();
            this.Picture = new System.Windows.Forms.PictureBox();
            StatusLabel = new System.Windows.Forms.Label();
            PromptLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCamara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new System.Drawing.Point(100, 444);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new System.Drawing.Size(42, 13);
            StatusLabel.TabIndex = 79;
            StatusLabel.Text = "Status:";
            StatusLabel.Visible = false;
            // 
            // PromptLabel
            // 
            PromptLabel.AutoSize = true;
            PromptLabel.Location = new System.Drawing.Point(15, 444);
            PromptLabel.Name = "PromptLabel";
            PromptLabel.Size = new System.Drawing.Size(47, 13);
            PromptLabel.TabIndex = 77;
            PromptLabel.Text = "Prompt:";
            PromptLabel.Visible = false;
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(15, 407);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 82;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Visible = false;
            // 
            // StatusLine
            // 
            this.StatusLine.Location = new System.Drawing.Point(12, 394);
            this.StatusLine.Name = "StatusLine";
            this.StatusLine.Size = new System.Drawing.Size(479, 39);
            this.StatusLine.TabIndex = 81;
            this.StatusLine.Text = "[Status line]";
            this.StatusLine.Visible = false;
            // 
            // StatusText
            // 
            this.StatusText.BackColor = System.Drawing.SystemColors.Window;
            this.StatusText.Location = new System.Drawing.Point(100, 460);
            this.StatusText.Multiline = true;
            this.StatusText.Name = "StatusText";
            this.StatusText.ReadOnly = true;
            this.StatusText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StatusText.Size = new System.Drawing.Size(79, 23);
            this.StatusText.TabIndex = 80;
            this.StatusText.Visible = false;
            // 
            // Prompt
            // 
            this.Prompt.Location = new System.Drawing.Point(15, 460);
            this.Prompt.Name = "Prompt";
            this.Prompt.ReadOnly = true;
            this.Prompt.Size = new System.Drawing.Size(79, 22);
            this.Prompt.TabIndex = 78;
            this.Prompt.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.panel1.Controls.Add(this.lblCloseButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(-1, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 38);
            this.panel1.TabIndex = 90;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // lblCloseButton
            // 
            this.lblCloseButton.AutoSize = true;
            this.lblCloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCloseButton.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloseButton.ForeColor = System.Drawing.Color.White;
            this.lblCloseButton.Location = new System.Drawing.Point(483, 6);
            this.lblCloseButton.Name = "lblCloseButton";
            this.lblCloseButton.Size = new System.Drawing.Size(28, 25);
            this.lblCloseButton.TabIndex = 92;
            this.lblCloseButton.Text = "✕";
            this.lblCloseButton.Click += new System.EventHandler(this.lblCloseButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(2, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(342, 25);
            this.label3.TabIndex = 91;
            this.label3.Text = "Registro de Asistencia, escanee su huella";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(235, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 21);
            this.label2.TabIndex = 97;
            this.label2.Text = "Dispositivos de Video del Sistema";
            this.label2.Visible = false;
            // 
            // cmbDispositivos
            // 
            this.cmbDispositivos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDispositivos.FormattingEnabled = true;
            this.cmbDispositivos.Location = new System.Drawing.Point(239, 435);
            this.cmbDispositivos.Name = "cmbDispositivos";
            this.cmbDispositivos.Size = new System.Drawing.Size(219, 29);
            this.cmbDispositivos.TabIndex = 96;
            this.cmbDispositivos.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.lblHoraFecha);
            this.panel2.Location = new System.Drawing.Point(-1, 313);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 32);
            this.panel2.TabIndex = 99;
            // 
            // lblHoraFecha
            // 
            this.lblHoraFecha.AutoSize = true;
            this.lblHoraFecha.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblHoraFecha.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraFecha.ForeColor = System.Drawing.Color.White;
            this.lblHoraFecha.Location = new System.Drawing.Point(100, 1);
            this.lblHoraFecha.Name = "lblHoraFecha";
            this.lblHoraFecha.Size = new System.Drawing.Size(90, 28);
            this.lblHoraFecha.TabIndex = 99;
            this.lblHoraFecha.Text = "label1";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(0, 350);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(510, 29);
            this.lblStatus.TabIndex = 100;
            this.lblStatus.Text = "label1";
            // 
            // pcbCamara
            // 
            this.pcbCamara.Image = global::StartupServiceBioZ.Properties.Resources.computer;
            this.pcbCamara.Location = new System.Drawing.Point(269, 50);
            this.pcbCamara.Name = "pcbCamara";
            this.pcbCamara.Size = new System.Drawing.Size(232, 254);
            this.pcbCamara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbCamara.TabIndex = 94;
            this.pcbCamara.TabStop = false;
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.Color.White;
            this.Picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Picture.Location = new System.Drawing.Point(3, 47);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(260, 257);
            this.Picture.TabIndex = 76;
            this.Picture.TabStop = false;
            // 
            // Validar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(511, 383);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDispositivos);
            this.Controls.Add(this.pcbCamara);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.StatusLine);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(StatusLabel);
            this.Controls.Add(this.Prompt);
            this.Controls.Add(PromptLabel);
            this.Controls.Add(this.Picture);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Validar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sistema de Control de Visitas v0.1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Validar_FormClosed);
            this.Load += new System.EventHandler(this.Validar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCamara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label StatusLine;
        private System.Windows.Forms.TextBox StatusText;
        private System.Windows.Forms.TextBox Prompt;
        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pcbCamara;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDispositivos;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHoraFecha;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCloseButton;
    }
}