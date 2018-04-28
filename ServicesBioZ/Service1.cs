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
        string device_number = string.Empty;

        private System.Timers.Timer _timer;
        private DateTime _lastRun = DateTime.Now.AddDays(-1);

        public Service1()
        {
            InitializeComponent();

           
        }

        protected override void OnStart(string[] args)
        {
            //if (args.GetLength(0) > 0 && args[0].Equals("DEBUG"))
            //    System.Diagnostics.Debugger.Launch(); 


            ip = ConfigurationManager.AppSettings["device_ip"];
            port = ConfigurationManager.AppSettings["device_port"];
            device_number = ConfigurationManager.AppSettings["device_number"];



            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(Environment.NewLine + "--BioZ SERVICIO INICIADO------------------------------------------------------" + Environment.NewLine);
                writer.WriteLine("Fecha: " + DateTime.Now + "");
            }
            EventLog.WriteEntry("BioZ SERVICIO INICIADO");
            //if (Conexion_BaseDatos())
            //{
            //    using (StreamWriter writer = new StreamWriter(filePath, true))
            //    {
            //        writer.WriteLine(Environment.NewLine + "--Conexión Exitosa de la Base de Datos------------------------------------------------------" + Environment.NewLine);                    
            //    }
            //}


            Thread createComAndMessagePumpThread = new Thread(() =>
            {
                if (Conexion_BaseDatos())
                {     
                    objCZKEM = new CZKEM();
                    //connSatus = Connect_Net(ip, int.Parse(port));
                    //Mensaje_Conexion_Dispositivo(connSatus);

                    _timer = new System.Timers.Timer(5 * 60 * 1000); // every 1 hour
                    _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                    _timer.Start();
                    Application.Run();
                   
                }

            });
            createComAndMessagePumpThread.SetApartmentState(ApartmentState.STA);

            createComAndMessagePumpThread.Start();

          

            EventLog.WriteEntry("Service BioZ started.");
        }

        public void Start()
        {
            OnStart(new string[0]);
        }
        void timer_Elapsed(object sender, EventArgs e)
        {
            _timer.Stop();

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {                
                writer.WriteLine(Environment.NewLine + "--Inicio de Inserción de Datos-------------------------------------------------" + Environment.NewLine);                
            }

             GetLogDataDevice(int.Parse(device_number));           
            
            _timer.Start();
        }

        private bool Conexion_BaseDatos()
        {
            bool bandera = true;
            var connectionString = ConfigurationManager.ConnectionStrings["DBInformix"].ConnectionString;
            PerInformixDB per = new PerInformixDB();
            try
            {
                per.AbrirConexion();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Error:" + ex.Message);
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(Environment.NewLine + "--Error de Conexión de Base de Datos-----------------------------------------" + Environment.NewLine);
                    writer.WriteLine("Fecha de Error: " + DateTime.Now + "");
                    writer.WriteLine("Error: " + ex.Message.ToString() + "");
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }

                bandera = false;
            }

            return bandera;
        }

        private void Mensaje_Conexion_Dispositivo(bool connSatus)
        {
            if (connSatus)
            {
                EventLog.WriteEntry("Dispositivo Conectado!!");
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(Environment.NewLine + "--Dispositivo Conectado------------------------------------------------------" + Environment.NewLine);
                    writer.WriteLine("IP: " + ip + Environment.NewLine);
                    writer.WriteLine("Puerto: " + port + Environment.NewLine);
                    writer.WriteLine("Número de Equipo: " + device_number.ToString());
                    writer.WriteLine(Environment.NewLine + "-------------------------------------------------------------------------------" + Environment.NewLine);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(Environment.NewLine + "--Error de Conexión con Dispositivo---------------------------------------------" + Environment.NewLine);
                    writer.WriteLine("Fecha: " + DateTime.Now + Environment.NewLine);
                    writer.WriteLine("IP: " + ip + Environment.NewLine);
                    writer.WriteLine("Puerto: " + port + Environment.NewLine);
                    writer.WriteLine("Número de Equipo: " + device_number.ToString());
                    writer.WriteLine(Environment.NewLine + "--------------------------------------------------------------------------------" + Environment.NewLine);
                }
            }

            // Ping a Dispositivo
            bool isValidIpA = ValidateIP(ip);
            if (!isValidIpA)
                EventLog.WriteEntry("The Device IP is invalid !!");
            else
                EventLog.WriteEntry("The Device IP is valid !!");

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
                   // objCZKEM.OnAttTransactionEx += new _IZKEMEvents_OnAttTransactionExEventHandler(zkemClient_OnAttTransactionEx);
                    
                }             

                return true;
            }
            return false;
        }

        //private void zkemClient_OnAttTransactionEx(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        //{
        //    var connectionString = ConfigurationManager.ConnectionStrings["DBInformix"].ConnectionString;
        //    ip = ConfigurationManager.AppSettings["device_ip"];

        //    string Finger_Empleado = GetFingerEmpleado(int.Parse(id_dispositivo), int.Parse(EnrollNumber));
        //    int Id_Empleado = GetIdEmpleado(int.Parse(id_dispositivo), int.Parse(EnrollNumber));

        //    using (StreamWriter writer = new StreamWriter(filePath, true))
        //    {
        //        writer.WriteLine(" OnAttTrasactionEx Has been Triggered,Verified OK on" + "Date :" + "Enrollnumber: " + EnrollNumber +"|"+ DateTime.Now.ToString());
        //        writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
        //        writer.WriteLine("Huella: " + Id_Empleado + Finger_Empleado.ToString());
        //    }                       
        //    //---------------------------------------------
        //    PerInformixDB per = new PerInformixDB();
        //        try
        //        {
        //            EmpleadoHuella entidad = new EmpleadoHuella();

        //            entidad.id_empleado = Id_Empleado;
        //            entidad.enrollnumber = EnrollNumber;
        //            entidad.huella = Finger_Empleado;
        //            entidad.b64huella = null;

        //        EventLog.WriteEntry("Huella Registrado: " + entidad.id_empleado +"-"+ entidad.enrollnumber +"-"+ entidad.huella);

        //        per.AbrirConexion();
        //        EventLog.WriteEntry("Connection Open");

        //        var sql = "insert into empleado_huella (id_empleado,b64huella,huella,enrollnumber) values (?,?,?,?);";

        //        using (var cmd = new IfxCommand(sql, per.Conexion))
        //        {
        //            cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_empleado;
        //            cmd.Parameters.Add(new IfxParameter()).Value = entidad.b64huella;
        //            cmd.Parameters.Add(new IfxParameter()).Value = entidad.huella;
        //            cmd.Parameters.Add(new IfxParameter()).Value = entidad.enrollnumber;
        //            cmd.ExecuteNonQuery();
        //        }

        //        EventLog.WriteEntry("Huella Registrado: " + entidad.id_empleado);
        //        }
        //        catch (Exception ex)
        //        {
        //            EventLog.WriteEntry("Error:"+ex.Message);
        //        }
        //        finally
        //        {
        //            per.CerrarConexion();
        //        }
        //}

        public void GetLogDataDevice(int device_number)
        {

            string dwEnrollNumber1 = "";            
            int dwVerifyMode = 0;
            int dwInOutMode = 0;
            int dwYear = 0;
            int dwMonth = 0;
            int dwDay = 0;
            int dwHour = 0;
            int dwMinute = 0;
            int dwSecond = 0;
            int dwWorkCode = 0;

            string sName = string.Empty, sId_Empleado = string.Empty;
            int sPrivilegio = 0;
            bool sActivo;
            List<checkinout> ListaEmpleadoEnrrolados = new List<checkinout>();
            EventLog.WriteEntry("Obteniendo Datos del Dispositivo!!");
            connSatus = Connect_Net(ip, int.Parse(port));
            Mensaje_Conexion_Dispositivo(connSatus);

            if (connSatus)
            {
                objCZKEM.ReadAllGLogData(device_number);

                while (objCZKEM.SSR_GetGeneralLogData(device_number, out dwEnrollNumber1, out dwVerifyMode, out dwInOutMode, out dwYear, out dwMonth, out dwDay, out dwHour, out dwMinute, out dwSecond, ref dwWorkCode))
                {

                    string inputDate = new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond).ToString();
                    //Obtener IDEMPLEADO
                    if (objCZKEM.ReadAllUserID(device_number))
                    {
                        bool result = objCZKEM.SSR_GetUserInfo(device_number, dwEnrollNumber1, out sName, out sId_Empleado, out sPrivilegio, out sActivo);

                        checkinout entCheck = new checkinout();
                        entCheck.anio = dwYear;
                        entCheck.mes = dwMonth;
                        entCheck.dia = dwDay;
                        entCheck.hora = dwHour;
                        entCheck.minuto = dwMinute;
                        entCheck.segundo = dwSecond;
                        entCheck.numeroCredencial = int.Parse(dwEnrollNumber1);
                        entCheck.Device = ip;
                        entCheck.id_dispositivo = device_number;
                        entCheck.id_empleado = int.Parse(sId_Empleado);
                        ListaEmpleadoEnrrolados.Add(entCheck);
                    }
                }

                if (ListaEmpleadoEnrrolados.Count() > 0)
                {
                    Insertar_Enrrolamiento_BD(ListaEmpleadoEnrrolados);

                    //ELIMINA LOS REGISTRO DEL DISPOSITIVO DEL RELOJ
                    objCZKEM.ClearGLog(device_number);
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine(Environment.NewLine + "---Se eliminaron todas las asitencia del Dispositivo-----------------------------------" + Environment.NewLine);
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine(Environment.NewLine + "---No hay Datos de Asistencia en el Dispositivo-----------------------------------" + Environment.NewLine);
                    }
                }

            }
          
        }

        public void Insertar_Enrrolamiento_BD(List<checkinout> ListaEmpleadoEnrrolamiento)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DBInformix"].ConnectionString;            
            PerInformixDB per = new PerInformixDB();
            try
            {             

                per.AbrirConexion();
                EventLog.WriteEntry("Insercion de Datos a la Base de Datos");

                foreach (checkinout entidad in ListaEmpleadoEnrrolamiento)
                {
                    var sql = "insert into checkinout (enrollnumber,date,hour,checkinout,device,id_dispositivo,id_empleado) values (?,?,?,?,?,?,?);";

                    using (var cmd = new IfxCommand(sql, per.Conexion))
                    {
                        cmd.Parameters.Add(new IfxParameter()).Value = entidad.numeroCredencial;
                        cmd.Parameters.Add(new IfxParameter()).Value = entidad.pFecha;
                        cmd.Parameters.Add(new IfxParameter()).Value = entidad.pHora;
                        cmd.Parameters.Add(new IfxParameter()).Value = entidad.Ckecked;
                        cmd.Parameters.Add(new IfxParameter()).Value = entidad.Device;
                        cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_dispositivo;
                        cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_empleado;
                        cmd.ExecuteNonQuery();
                    }

                    string filePath = ConfigurationManager.AppSettings["file_log"];
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine(Environment.NewLine + "---Inserción de Asistencia a la Base de Datos Exitosamente!!-------------------------------" + Environment.NewLine);
                        writer.WriteLine("ID Empleado: " + entidad.id_empleado.ToString() + Environment.NewLine);
                        writer.WriteLine("Número de Enrolamiento: " + entidad.numeroCredencial.ToString());                                                                      
                        writer.WriteLine(Environment.NewLine + "-------------------------------------------------------------------------------------------" + Environment.NewLine);                        
                    }
                }
                
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Error:" + ex.Message);
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(Environment.NewLine + "--Error de Conexión de Base de Datos-----------------------------------------" + Environment.NewLine);
                    writer.WriteLine("Hora de Error: " + DateTime.Now + "");
                    writer.WriteLine("Error: " + ex.Message.ToString() + "");
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
            }
            finally
            {
                per.CerrarConexion();
            }
        }

        //public string GetFingerEmpleado(int machineNumber, int EnrollNumber)
        //{
        //    string sdwEnrollNumber = string.Empty, sName = string.Empty, sPassword = string.Empty, sTmpData = string.Empty;
        //    int iTmpLength = 0, iFlag = 0, idwFingerIndex;

        //    string Finger = string.Empty;
        //    objCZKEM.ReadAllUserID(1);
        //    objCZKEM.ReadAllTemplate(1);

        //    for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
        //    {

        //        objCZKEM.GetUserTmpExStr(1, EnrollNumber.ToString(), idwFingerIndex, out iFlag, out sTmpData, out iTmpLength);
        //        Finger = sTmpData;
        //    }

        //    return Finger;
        //}


        //public int GetIdEmpleado(int machineNumber, int EnrollNumber)
        //{
        //    int Id_Empleado = 0, sPrivilegio = 0;
        //    string sName = string.Empty, sPassword = string.Empty;
        //    bool sEnabled;

        //    objCZKEM.SSR_GetUserInfo(machineNumber, EnrollNumber.ToString(), out sName, out sPassword, out sPrivilegio, out sEnabled);
        //    Id_Empleado = int.Parse(sPassword);
        //    return Id_Empleado;
        //}


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
            //this.objCZKEM.OnAttTransactionEx -= new _IZKEMEvents_OnAttTransactionExEventHandler(zkemClient_OnAttTransactionEx);
            objCZKEM.Disconnect();

        }

       
    }    
}
