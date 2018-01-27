using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

namespace StartupServiceBioZ
{
    public partial class Bioz : Form
    {
        public Bioz()
        {
            InitializeComponent();
            timer1.Enabled = true;
            string nombreServicio = "Servicio Bio Z";
            ServiceController sc = new ServiceController(nombreServicio);
            if (sc != null && sc.Status == ServiceControllerStatus.Running)         
                HabiliarBotones(false);         
            else            
                HabiliarBotones(true);
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            string nombreServicio = "Servicio Bio Z";
            ServiceController sc = new ServiceController(nombreServicio);            
            try

            {
                if (sc != null && sc.Status == ServiceControllerStatus.Stopped)
                {
                    sc.Start();
                    HabiliarBotones(false);
                }
                sc.WaitForStatus(ServiceControllerStatus.Running);
                sc.Close();
            }

            catch (Exception)

            {

            }
        }

        private void HabiliarBotones(bool flat)
        {
            btn_iniciar.Enabled = flat;
            btn_reiniciar.Enabled = !flat;
            btn_detener.Enabled = !flat;
        }

        private void btn_detener_Click(object sender, EventArgs e)
        {
            string serviceName = "Servicio Bio Z";
            ServiceController sc = new ServiceController(serviceName);           
            try

            {
                if (sc != null && sc.Status == ServiceControllerStatus.Running)
                {
                    sc.Stop();
                    HabiliarBotones(true);
                }
                sc.WaitForStatus(ServiceControllerStatus.Stopped);
                sc.Close();
            }

            catch (Exception)

            {

            }
        }

        private void btn_reiniciar_Click(object sender, EventArgs e)
        {
            string serviceName = "Servicio Bio Z";
            ServiceController sc = new ServiceController(serviceName);
            try

            {
                if (sc != null && sc.Status == ServiceControllerStatus.Running)
                {
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped);
                    sc.Start();
                }
                sc.WaitForStatus(ServiceControllerStatus.Running);
                sc.Close();
            }

            catch (Exception)

            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString();
        }

        private void lblCloseButton_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Visible = true;
            this.Close();
   
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Bioz_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
