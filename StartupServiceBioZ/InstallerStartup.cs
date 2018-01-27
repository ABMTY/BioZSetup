using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace StartupServiceBioZ
{
    [RunInstaller(true)]
    public partial class InstallerStartup : System.Configuration.Install.Installer
    {
        public InstallerStartup()
        {
            InitializeComponent();
        }
        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);

            try
            {
                AddConfigurationFileDetails();
            }
            catch (Exception e)
            {
                MessageBox.Show("Falha ao atualizar o arquivo de configuração da aplicação: " + e.Message);
                base.Rollback(savedState);
            }
        }

        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
        }

        private void showParameters()
        {
            StringBuilder sb = new StringBuilder();
            StringDictionary myStringDictionary = this.Context.Parameters;
            if (this.Context.Parameters.Count > 0)
            {
                foreach (string myString in this.Context.Parameters.Keys)
                {
                    sb.AppendFormat("String={0} Value= {1}\n", myString,
                    this.Context.Parameters[myString]);
                }
            }
            MessageBox.Show(sb.ToString());
        }

        private void AddConfigurationFileDetails()
        {
            try
            {

                string[] Parametros = Context.Parameters["DB_BIOZ"].Split('/');
                string Parametro = Parametros[0];
                string[] Datos = Parametro.Split(';');     

                string HOST = Datos[0].ToString();
                string SERVER = Datos[1].ToString();
                string SERVICE = Datos[2].ToString();
                string PROTOCOL = Datos[3].ToString();
                string BD = Datos[4].ToString();
                string USER = Datos[5].ToString();
                string PASSWORD = Datos[6].ToString();

                //string CadenaConexion = "IPD=" + DEVICE_IP + "PUerto=" + DEVICE_PORT + ";Host=" + HOST + ";Server=" + SERVER + ";Service=" + SERVICE + ";Protocol=" + PROTOCOL + ";Database=" + BD + ";UID=" + USER + ";Password=" + PASSWORD;
                //MessageBox.Show("Cadena de Conexion5:" + CadenaConexion);
                Set_DateDataBase(HOST, SERVER, SERVICE, PROTOCOL, BD, USER, PASSWORD);

            }
            catch
            {
                throw;
            }
        }       

        private void Set_DateDataBase(string HOST, string SERVER, string SERVICE, string PROTOCOL, string BD, string USER, string PASSWORD)
        {
            // Get the path to the executable file that is being installed on the target computer  
            string assemblypath = Context.Parameters["assemblypath"];
            string appConfigPath = assemblypath + ".config";

            //string CadenaConexion = "Data Source ="+ IP_BD +"; Initial Catalog ="+ BD +"; Persist Security Info = True; User ID="+ USER +"; Password="+ PASSWORD;
            string CadenaConexion = "Host=" + HOST + "; Server=" + SERVER + "; Service=" + SERVICE + "; Protocol=" + PROTOCOL + "; Database=" + BD + "; UID=" + USER + "; Password=" + PASSWORD + ";";
            //MessageBox.Show("Cadena de Conexion:" + CadenaConexion);
            //updating config file
            XmlDocument XmlDoc = new XmlDocument();

            //Loading the Config file
            XmlDoc.Load(appConfigPath);
            foreach (XmlElement xElement in XmlDoc.DocumentElement)
            {

                if (xElement.Name == "connectionStrings")
                {
                    //MessageBox.Show("Cadena de Conexion:" + CadenaConexion);
                    //setting the coonection string
                    xElement.FirstChild.Attributes[1].Value = CadenaConexion;
                    //MessageBox.Show("ConecctionString:" + xElement.FirstChild.Attributes[1].Value.ToString());
                }
            }

            //writing the connection string in config file
            XmlDoc.Save(appConfigPath);
        }
    }
}
