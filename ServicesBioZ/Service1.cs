using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.IO;
using zkemkeeper;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using ServicesBioZ.Model;
using System.Net;
using IBM.Data.Informix;

namespace ServicesBioZ
{
    public partial class Service1 : ServiceBase
    {
        // private System.Timers.Timer timer1 = null;
        string filePath = ConfigurationManager.AppSettings["file_log"];
        bool connSatus = false;
        CZKEM objCZKEM;
        string ip = string.Empty;
        string port = string.Empty;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {           
           
            ip = ConfigurationManager.AppSettings["device_ip"];
            port = ConfigurationManager.AppSettings["device_port"];

            Thread createComAndMessagePumpThread = new Thread(() =>
            {
                objCZKEM = new CZKEM();
                
                connSatus = Connect_Net(ip, int.Parse(port));
                if (connSatus)
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine("Machine is connected on" + "Date :" + objCZKEM.MachineNumber.ToString());
                        writer.WriteLine("Machine is connected on" + "Date :" + DateTime.Now.ToString() + "status" + connSatus);                        
                        writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                        EventLog.WriteEntry("Machine is connected on" + "Date :" + DateTime.Now.ToString() + "Status: " + connSatus);
                    }
                // Ping a Dispositivo

                bool isValidIpA = ValidateIP(ip);
                if (!isValidIpA)
                    EventLog.WriteEntry("The Device IP is invalid !!");
                else
                    EventLog.WriteEntry("The Device IP is valid !!");


                Application.Run();

            });
            createComAndMessagePumpThread.SetApartmentState(ApartmentState.STA);

            createComAndMessagePumpThread.Start();

            EventLog.WriteEntry("Service BioZ started.");
        }
        private bool Connect_Net(string IPAdd, int Port)
        {
            if (objCZKEM.Connect_Net(IPAdd, Port))
            {
                //65535, 32767
                if (objCZKEM.RegEvent(1, 32767))
                {
                    // [ Register your events here ]
                    // [ Go through the _IZKEMEvents_Event class for a complete list of events
                    objCZKEM.OnAttTransactionEx += new _IZKEMEvents_OnAttTransactionExEventHandler(zkemClient_OnAttTransactionEx);
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine("finger print Event is registered... ");
                        writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    }                    
                }
                return true;
            }
            return false;
        }

        private void zkemClient_OnAttTransactionEx(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DBInformix"].ConnectionString;
            ip = ConfigurationManager.AppSettings["device_ip"];

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(" OnAttTrasactionEx Has been Triggered,Verified OK on" + "Date :" + "Enrollnumber" + EnrollNumber +"|"+ DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
                PerInformixDB per = new PerInformixDB();
                try
                {
                    checkinout entidad = new checkinout();
                    entidad.anio = Year;
                    entidad.mes = Month;
                    entidad.dia = Day;
                    entidad.hora = Hour;
                    entidad.minuto = Minute;
                    entidad.segundo = Second;
                    entidad.numeroCredencial = int.Parse(EnrollNumber);
                    entidad.Device = ip;          

                    per.AbrirConexion();
                    EventLog.WriteEntry("Connection Open");

                    var sql = "insert into checkinout (enrollnumber,date,hour,checkinout,device) values (?,?,?,?,?);";

                    using (var cmd = new IfxCommand(sql, per.Conexion))
                    {
                        cmd.Parameters.Add(new IfxParameter()).Value= entidad.numeroCredencial;
                        cmd.Parameters.Add(new IfxParameter()).Value = entidad.pFecha;
                        cmd.Parameters.Add(new IfxParameter()).Value = entidad.pHora;
                        cmd.Parameters.Add(new IfxParameter()).Value = entidad.Ckecked;
                        cmd.Parameters.Add(new IfxParameter()).Value = entidad.Device;
                        cmd.ExecuteNonQuery();
                    }
                    
                   EventLog.WriteEntry("Insert EnrollNumber: " + EnrollNumber);
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("Error:"+ex.Message);
                }
                finally
                {
                    per.CerrarConexion();
                }
        }
        public static bool ValidateIP(string addrString)
        {
            IPAddress address;
            if (IPAddress.TryParse(addrString, out address))
                return true;
            else
                return false;
        }
        public bool ClearGLog(CZKEM objZkeeper, int machineNumber)
        {
            return objCZKEM.ClearGLog(machineNumber);
        }

        protected override void OnStop()
        {
            // timer1.Enabled = false;
            this.objCZKEM.OnAttTransactionEx -= new _IZKEMEvents_OnAttTransactionExEventHandler(zkemClient_OnAttTransactionEx);
            objCZKEM.Disconnect();

        }

       
    }    
}
