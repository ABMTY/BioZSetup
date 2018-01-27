using Enrollment;
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

namespace StartupServiceBioZ
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();            
        }

        private void pbxDigitalPersona_Click(object sender, EventArgs e)
        {
            Validar validar = new Validar();
            validar.Show(this);
            this.Hide(); 
                       
        }  

        private void pbxZkteco_Click(object sender, EventArgs e)
        {
            Bioz bio = new Bioz();
            bio.Show();
            Hide();
        }

        private void lblCloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Menu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
