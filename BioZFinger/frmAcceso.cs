using BioZFinger.Utilities;
using CtrlServiceBioz.Control;
using EntServiceBioz.Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioZFinger
{
    public partial class frmAcceso : Form
    {
        CtrlUsuarios ctrlUsuarios = new CtrlUsuarios();
        CtrlEmpresa ctrlEmpresa = new CtrlEmpresa();
        public static string NombreEmpresa;
        public static int Id_Empresa;
        public frmAcceso()
        {
            InitializeComponent();
        }

        //public int Id_Empresa()
        //{
        //    int IdEmpresa = ((EntServiceBioz.Entidad.EntEmpresa)cmbEmpresa.SelectedItem).id_empresa;
        //    return IdEmpresa; 
        //}

        //public string Empresa()
        //{
        //    string Nombre = ((EntServiceBioz.Entidad.EntEmpresa)cmbEmpresa.SelectedItem).;
        //    return Nombre;
        //}

        private void lblCloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlTituloAcceso_MouseDown(object sender, MouseEventArgs e)
        {
            GeneralUtility.Form_MouseDown();
            GeneralUtility.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmAcceso_MouseDown(object sender, MouseEventArgs e)
        {
            GeneralUtility.Form_MouseDown();
            GeneralUtility.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnAccesar_Click(object sender, EventArgs e)
        {
            try
            {                
                Id_Empresa = ((EntServiceBioz.Entidad.EntEmpresa)cmbEmpresa.SelectedItem).id_empresa;
                NombreEmpresa = ((EntServiceBioz.Entidad.EntEmpresa)cmbEmpresa.SelectedItem).razon_social.ToString();
                ValidarUsuario();
            }
            catch (Exception ex)
            {
                EtiquetaMensaje("No hay conexión con la Base de Datos",false);
            }
        }

        private void ValidarUsuario()
        {
            bool AccessoAutorizado = ObtenerUsuario(txtUsuario.Text, txtContaseña.Text);
            if (AccessoAutorizado)
            {
                frmListaEmpleados listaEmpleados = new frmListaEmpleados();
                listaEmpleados.Show();
                this.Hide();
            }
            else
            {
                EtiquetaMensaje("Usuario y/o Contreña Incorrecta!", false);
            }
        }

        private bool ObtenerUsuario(string Nombre, string Contraseña)
        {
            List<EntUsuario> listaUsuarios = new List<EntUsuario>();
            listaUsuarios = ctrlUsuarios.ObtenerTodos();
            bool Acceso = false;

            foreach (var entUsuario in listaUsuarios)
            {
                if (Nombre == entUsuario.usuario && Contraseña == entUsuario.password)
                {
                    Acceso = true;
                    break;
                }
            }

            return Acceso;
        }

        private void ObtenerEmpresas()
        {
            List<EntEmpresa> listaEmpresa = new List<EntEmpresa>();
            listaEmpresa = ctrlEmpresa.ObtenerTodos();
            cmbEmpresa.DataSource = listaEmpresa;           
            cmbEmpresa.DisplayMember = "razon_social";
            cmbEmpresa.ValueMember = "id_empresa";
            cmbEmpresa.SelectedIndex = -1;
        }       

        public void EtiquetaMensaje(string message, bool type)
        {
            if (message.Trim() == string.Empty)
            {
                lblStatus.Visible = false;
                return;
            }

            lblStatus.Visible = true;
            lblStatus.Text = message;
            lblStatus.ForeColor = Color.White;

            if (type)
            {
                lblStatus.BackColor = Color.FromArgb(79, 208, 154);
            }
            else
            {
                txtUsuario.Focus();
                lblStatus.BackColor = Color.FromArgb(255, 0, 0);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtContaseña.Text = "";
            txtUsuario.Focus();
        }

        private void txtContaseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    ValidarUsuario();
                }
                catch (Exception ex)
                {
                    EtiquetaMensaje("No hay conexión con la Base de Datos", false);
                }
            }
        }

        private void frmAcceso_Load(object sender, EventArgs e)
        {            
            ObtenerEmpresas();
        }
    }
}
