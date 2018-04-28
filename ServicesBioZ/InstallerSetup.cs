using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;
using System.Web.Configuration;

namespace ServicesBioZ
{
    [RunInstaller(true)]
    public partial class InstallerSetup : System.Configuration.Install.Installer
    {
        public InstallerSetup()
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

                string[] Parametros = Context.Parameters["DISPOSITIVO"].Split('/');
                string Parametro = Parametros[0];
                string[] Datos = Parametro.Split(';');

                string DEVICE_IP = Datos[0].ToString();
                string DEVICE_PORT = Datos[1].ToString();
                string DEVICE_NUMBER = Datos[2].ToString();

                Set_DateDivice(DEVICE_IP, DEVICE_PORT, DEVICE_NUMBER);

                       
                string HOST = Datos[3].ToString();
                string SERVER = Datos[4].ToString();
                string SERVICE = Datos[5].ToString();
                string PROTOCOL = Datos[6].ToString();
                string BD = Datos[7].ToString();
                string USER = Datos[8].ToString();
                string PASSWORD = Datos[9].ToString();

                //string CadenaConexion = "IPD=" + DEVICE_IP + "PUerto=" + DEVICE_PORT + ";Host=" + HOST + ";Server=" + SERVER + ";Service=" + SERVICE + ";Protocol=" + PROTOCOL + ";Database=" + BD + ";UID=" + USER + ";Password=" + PASSWORD;
                //MessageBox.Show("Cadena de Conexion5:" + CadenaConexion);
                Set_DateDataBase(HOST,SERVER,SERVICE,PROTOCOL,BD,USER,PASSWORD);

            }
            catch
            {
                throw;
            }
        }

        private void Set_DateDivice(string DEVICE_IP, string DEVICE_PORT, string DEVICE_NUMBER)
        {
            // Get the path to the executable file that is being installed on the target computer  
            string assemblypath = Context.Parameters["assemblypath"];
            string appConfigPath = assemblypath + ".config";

            // Write the path to the app.config file  
            XmlDocument doc = new XmlDocument();
            doc.Load(appConfigPath);

            XmlNode configuration = null;
            foreach (XmlNode node in doc.ChildNodes)
                if (node.Name == "configuration")
                    configuration = node;

            if (configuration != null)
            {
                //MessageBox.Show("configuration != null");  
                // Get the ‘appSettings’ node  
                XmlNode settingNode = null;
                foreach (XmlNode node in configuration.ChildNodes)
                {
                    if (node.Name == "appSettings")
                        settingNode = node;
                }

                if (settingNode != null)
                {
                    //MessageBox.Show("settingNode != null");  
                    //Reassign values in the config file  
                    foreach (XmlNode node in settingNode.ChildNodes)
                    {
                        //MessageBox.Show("node.Value = " + node.Value);  
                        if (node.Attributes == null)
                            continue;
                        XmlAttribute attribute = node.Attributes["value"];
                        //MessageBox.Show("attribute != null ");  
                        //MessageBox.Show("node.Attributes['value'] = " + node.Attributes["value"].Value);  
                        if (node.Attributes["key"] != null)
                        {
                            //MessageBox.Show("node.Attributes['key'] = " + node.Attributes["key"].Value);

                            switch (node.Attributes["key"].Value)
                            {
                                case "device_ip":
                                    {
                                        attribute.Value = DEVICE_IP;
                                        //MessageBox.Show("node.Attributes['Value'] = " + DEVICE_IP);
                                    }
                                    break;
                                case "device_port":
                                    {
                                        attribute.Value = DEVICE_PORT;
                                        //MessageBox.Show("node.Attributes['Value'] = " + DEVICE_PORT);
                                    }
                                    break;
                                case "device_number":
                                    {
                                        attribute.Value = DEVICE_NUMBER;
                                        //MessageBox.Show("node.Attributes['Value'] = " + DEVICE_NUMBER);
                                    }
                                    break;
                            }
                        }
                    }
                }
                doc.Save(appConfigPath);
            }

        }

        private void Set_DateDataBase(string HOST, string SERVER, string SERVICE, string PROTOCOL, string BD, string USER, string PASSWORD)
        {
            // Get the path to the executable file that is being installed on the target computer  
            string assemblypath = Context.Parameters["assemblypath"];
            string appConfigPath = assemblypath + ".config";
            
            //string CadenaConexion = "Data Source ="+ IP_BD +"; Initial Catalog ="+ BD +"; Persist Security Info = True; User ID="+ USER +"; Password="+ PASSWORD;
            string CadenaConexion = "Host="+ HOST + "; Server="+ SERVER + "; Service="+ SERVICE + "; Protocol="+ PROTOCOL + "; Database="+ BD + "; UID="+ USER + "; Password=" + PASSWORD+";";
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
