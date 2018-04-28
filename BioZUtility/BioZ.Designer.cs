namespace BioZUtility
{
    partial class Frm_Instalador
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_64Bits = new System.Windows.Forms.Button();
            this.btn_32Bits = new System.Windows.Forms.Button();
            this.btn_SDKInformix32Bits = new System.Windows.Forms.Button();
            this.btn_BioZ = new System.Windows.Forms.Button();
            this.btn_FrameWork = new System.Windows.Forms.Button();
            this.gBox_Utilerias = new System.Windows.Forms.GroupBox();
            this.gBox_BioZ = new System.Windows.Forms.GroupBox();
            this.gBox_Utilerias.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_64Bits
            // 
            this.btn_64Bits.Location = new System.Drawing.Point(57, 62);
            this.btn_64Bits.Name = "btn_64Bits";
            this.btn_64Bits.Size = new System.Drawing.Size(135, 23);
            this.btn_64Bits.TabIndex = 0;
            this.btn_64Bits.Text = "SDK ZKTeco x64";
            this.btn_64Bits.UseVisualStyleBackColor = true;
            this.btn_64Bits.Click += new System.EventHandler(this.btn_64Bits_Click);
            // 
            // btn_32Bits
            // 
            this.btn_32Bits.Location = new System.Drawing.Point(57, 91);
            this.btn_32Bits.Name = "btn_32Bits";
            this.btn_32Bits.Size = new System.Drawing.Size(135, 23);
            this.btn_32Bits.TabIndex = 1;
            this.btn_32Bits.Text = "SDK ZKTeco x86";
            this.btn_32Bits.UseVisualStyleBackColor = true;
            this.btn_32Bits.Click += new System.EventHandler(this.btn_32Bits_Click);
            // 
            // btn_SDKInformix32Bits
            // 
            this.btn_SDKInformix32Bits.ForeColor = System.Drawing.Color.Black;
            this.btn_SDKInformix32Bits.Location = new System.Drawing.Point(31, 107);
            this.btn_SDKInformix32Bits.Name = "btn_SDKInformix32Bits";
            this.btn_SDKInformix32Bits.Size = new System.Drawing.Size(135, 23);
            this.btn_SDKInformix32Bits.TabIndex = 2;
            this.btn_SDKInformix32Bits.Text = "SDK Client Informix";
            this.btn_SDKInformix32Bits.UseVisualStyleBackColor = true;
            this.btn_SDKInformix32Bits.Click += new System.EventHandler(this.btn_SDKInformix32Bits_Click);
            // 
            // btn_BioZ
            // 
            this.btn_BioZ.Location = new System.Drawing.Point(57, 189);
            this.btn_BioZ.Name = "btn_BioZ";
            this.btn_BioZ.Size = new System.Drawing.Size(135, 23);
            this.btn_BioZ.TabIndex = 4;
            this.btn_BioZ.Text = "Servicio BioZ";
            this.btn_BioZ.UseVisualStyleBackColor = true;
            this.btn_BioZ.Click += new System.EventHandler(this.btn_BioZ_Click);
            // 
            // btn_FrameWork
            // 
            this.btn_FrameWork.ForeColor = System.Drawing.Color.Black;
            this.btn_FrameWork.Location = new System.Drawing.Point(31, 19);
            this.btn_FrameWork.Name = "btn_FrameWork";
            this.btn_FrameWork.Size = new System.Drawing.Size(135, 23);
            this.btn_FrameWork.TabIndex = 5;
            this.btn_FrameWork.Text = "NET_FrameWork 4.5";
            this.btn_FrameWork.UseVisualStyleBackColor = true;
            this.btn_FrameWork.Click += new System.EventHandler(this.btn_FrameWork_Click);
            // 
            // gBox_Utilerias
            // 
            this.gBox_Utilerias.Controls.Add(this.btn_FrameWork);
            this.gBox_Utilerias.Controls.Add(this.btn_SDKInformix32Bits);
            this.gBox_Utilerias.ForeColor = System.Drawing.Color.White;
            this.gBox_Utilerias.Location = new System.Drawing.Point(26, 13);
            this.gBox_Utilerias.Name = "gBox_Utilerias";
            this.gBox_Utilerias.Size = new System.Drawing.Size(200, 142);
            this.gBox_Utilerias.TabIndex = 6;
            this.gBox_Utilerias.TabStop = false;
            this.gBox_Utilerias.Text = "Utilerias";
            // 
            // gBox_BioZ
            // 
            this.gBox_BioZ.ForeColor = System.Drawing.Color.White;
            this.gBox_BioZ.Location = new System.Drawing.Point(26, 167);
            this.gBox_BioZ.Name = "gBox_BioZ";
            this.gBox_BioZ.Size = new System.Drawing.Size(200, 62);
            this.gBox_BioZ.TabIndex = 7;
            this.gBox_BioZ.TabStop = false;
            this.gBox_BioZ.Text = "Instalador";
            // 
            // Frm_Instalador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(250, 244);
            this.Controls.Add(this.btn_BioZ);
            this.Controls.Add(this.btn_32Bits);
            this.Controls.Add(this.btn_64Bits);
            this.Controls.Add(this.gBox_BioZ);
            this.Controls.Add(this.gBox_Utilerias);
            this.Name = "Frm_Instalador";
            this.Text = "BioZ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gBox_Utilerias.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_64Bits;
        private System.Windows.Forms.Button btn_32Bits;
        private System.Windows.Forms.Button btn_SDKInformix32Bits;
        private System.Windows.Forms.Button btn_BioZ;
        private System.Windows.Forms.Button btn_FrameWork;
        private System.Windows.Forms.GroupBox gBox_Utilerias;
        private System.Windows.Forms.GroupBox gBox_BioZ;
    }
}

