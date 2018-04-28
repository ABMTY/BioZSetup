///
///    Experimented By : Ozesh Thapa
///    Email: dablackscarlet@gmail.com
///
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using CtrlServiceBioz.Control;
using EntServiceBioz.Entidad;

namespace DeviceBioZCore
{
    public partial class Master : Form
    {
        DeviceManipulator manipulator = new DeviceManipulator();
        public ZkemClient objZkeeper;
        private bool isDeviceConnected = false;
        CtrlDispositivos ctrlDispositivo = new CtrlDispositivos();

        public string Id_Empleado, Nombre_Empleado, NombreEmpresa;
        public int Id_Empresa, id_device;
        public string ip, puerto, numeroequipo;

        public bool IsDeviceConnected
        {
            get { return isDeviceConnected; }
            set
            {
                isDeviceConnected = value;
                if (isDeviceConnected)
                {
                    ShowStatusBar("El dispositivo esta conectado !!", true);
                    btnConnect.Text = "Desconectar";
                    ToggleControls(true);
                }
                else
                {
                    ShowStatusBar("El dispositivo esta desconectado !!", true);
                    objZkeeper.Disconnect();
                    btnConnect.Text = "Conectar";
                    ToggleControls(false);
                }
            }
        }


        private void ToggleControls(bool value)
        {
            btnBeep.Enabled = value;
            btnDownloadFingerPrint.Enabled = value;
            btnPullData.Enabled = value;
            btnPowerOff.Enabled = value;
            btnRestartDevice.Enabled = value;
            btnGetDeviceTime.Enabled = value;
            btnEnableDevice.Enabled = value;
            btnDisableDevice.Enabled = value;
            btnGetAllUserID.Enabled = value;
            btnUploadUserInfo.Enabled = value;
            cmbDispositivo.Enabled = !value;
        }

        public Master()
        {
            InitializeComponent();
            ToggleControls(false);
            ShowStatusBar(string.Empty, true);
            DisplayEmpty();
        }


        /// <summary>
        /// Your Events will reach here if implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="actionType"></param>
        private void RaiseDeviceEvent(object sender, string actionType)
        {
            switch (actionType)
            {
                case UniversalStatic.acx_Disconnect:
                    {
                        ShowStatusBar("El dispositivo está apagado !!", true);
                        DisplayEmpty();
                        btnConnect.Text = "Conectar";
                        ToggleControls(false);
                        break;
                    }

                default:
                    break;
            }

        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //id_device = ((EntServiceBioz.Entidad.EntDispositivo)cmbDispositivo.SelectedItem).id_dispositivo;

                if(cmbDispositivo.SelectedIndex == -1)
                    throw new Exception("Seleccione un dispositivo !!");

                EntDispositivo entidadDisp = ctrlDispositivo.Obtener(((EntServiceBioz.Entidad.EntDispositivo)cmbDispositivo.SelectedItem).id_dispositivo);

                ip = entidadDisp.ip_dispositivo;
                puerto = entidadDisp.puerto;
                numeroequipo = entidadDisp.numeroequipo.ToString();

                this.Cursor = Cursors.WaitCursor;
                ShowStatusBar(string.Empty, true);

                if (IsDeviceConnected)
                {
                    IsDeviceConnected = false;
                    this.Cursor = Cursors.Default;

                    return;
                }

                
                string ipAddress = entidadDisp.ip_dispositivo.ToString().Trim();
                
                string port = entidadDisp.puerto.ToString().Trim();
                if (ipAddress == string.Empty || port == string.Empty)
                    throw new Exception("La dirección IP y el puerto del dispositivo son obligatorio !!");

                int portNumber = int.Parse(entidadDisp.puerto);
                if (!int.TryParse(port, out portNumber))
                    throw new Exception("El puerto del dispositivo es incorrecto !!");

                bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
                if (!isValidIpA)
                    throw new Exception("La ip del dispositivo es incorrecto !!");

                isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
                if (!isValidIpA)
                    throw new Exception("La ip y puerto " + ipAddress + ":" + port + " no responden!!");

                objZkeeper = new ZkemClient(RaiseDeviceEvent);   
                IsDeviceConnected = objZkeeper.Connect_Net(ipAddress, portNumber);

                if (IsDeviceConnected)
                {
                    string deviceInfo = manipulator.FetchDeviceInfo(objZkeeper, entidadDisp.numeroequipo);
                    lblDeviceInfo.Text = deviceInfo;
                }

            }
            catch (Exception ex)
            {
                ShowStatusBar(ex.Message, false);
            }
            this.Cursor = Cursors.Default;

        }


        public void ShowStatusBar(string message, bool type)
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
                lblStatus.BackColor = Color.FromArgb(79, 208, 154);
            else
                lblStatus.BackColor = Color.FromArgb(230, 112, 134);
        }


        private void btnPingDevice_Click(object sender, EventArgs e)
        {
            ShowStatusBar(string.Empty, true);

            string ipAddress = ip.ToString().Trim();

            bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
            if (!isValidIpA)
                throw new Exception("La ip del dispositivo es incorrecto !!");

            isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
            if (isValidIpA)
                ShowStatusBar("El dispositivo esta activo !!", true);
            else
                ShowStatusBar("El dispositivo no responde !!", false);
        }

        private void btnGetAllUserID_Click(object sender, EventArgs e)
        {
            try
            {
                ICollection<UserIDInfo> lstUserIDInfo = manipulator.GetAllUserID(objZkeeper, int.Parse(numeroequipo));

                if (lstUserIDInfo != null && lstUserIDInfo.Count > 0)
                {
                    BindToGridView(lstUserIDInfo);
                    ShowStatusBar(lstUserIDInfo.Count + " registros encontrados !!", true);
                }
                else
                {
                    DisplayEmpty();
                    DisplayListOutput("No existe registros !!");
                }

            }
            catch (Exception ex)
            {
                DisplayListOutput(ex.Message);
            }

        }

        private void btnBeep_Click(object sender, EventArgs e)
        {
            objZkeeper.Beep(100);
        }

        private void btnDownloadFingerPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ShowStatusBar(string.Empty, true);

                ICollection<UserInfo> lstFingerPrintTemplates = manipulator.GetAllUserInfo(objZkeeper, int.Parse(numeroequipo));
                if (lstFingerPrintTemplates != null && lstFingerPrintTemplates.Count > 0)
                {
                    BindToGridView(lstFingerPrintTemplates);
                    ShowStatusBar(lstFingerPrintTemplates.Count + " registros encontrados !!", true);
                }
                else
                    DisplayListOutput("No existe registros !!");
            }
            catch (Exception ex)
            {
                DisplayListOutput(ex.Message);
            }

        }


        private void btnPullData_Click(object sender, EventArgs e)
        {
            try
            {
                ShowStatusBar(string.Empty, true);

                ICollection<MachineInfo> lstMachineInfo = manipulator.GetLogData(objZkeeper, int.Parse(numeroequipo));

                if (lstMachineInfo != null && lstMachineInfo.Count > 0)
                {
                    BindToGridView(lstMachineInfo);
                    ShowStatusBar(lstMachineInfo.Count + " registros encontrados !!", true);
                }
                else
                    DisplayListOutput("No existe registros !!");
            }
            catch (Exception ex)
            {
                DisplayListOutput(ex.Message);
            }

        }


        private void ClearGrid()
        {
            if (dgvRecords.Controls.Count > 2)
            { dgvRecords.Controls.RemoveAt(2); }


            dgvRecords.DataSource = null;
            dgvRecords.Controls.Clear();
            dgvRecords.Rows.Clear();
            dgvRecords.Columns.Clear();
        }
        private void BindToGridView(object list)
        {
            ClearGrid();
            dgvRecords.DataSource = list;
            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UniversalStatic.ChangeGridProperties(dgvRecords);
        }



        private void DisplayListOutput(string message)
        {
            if (dgvRecords.Controls.Count > 2)
            { dgvRecords.Controls.RemoveAt(2); }

            ShowStatusBar(message, false);
        }

        private void DisplayEmpty()
        {
            ClearGrid();
            dgvRecords.Controls.Add(new DataEmpty());
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        { UniversalStatic.DrawLineInFooter(pnlHeader, Color.FromArgb(204, 204, 204), 2); }



        private void btnPowerOff_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            var resultDia = DialogResult.None;
            resultDia = MessageBox.Show("Esta seguro de apagar el dispositivo ??", "Apagar Dispositivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDia == DialogResult.Yes)
            {
                bool deviceOff = objZkeeper.PowerOffDevice(int.Parse(numeroequipo));

            }

            this.Cursor = Cursors.Default;
        }

        private void btnRestartDevice_Click(object sender, EventArgs e)
        {

            DialogResult rslt = MessageBox.Show("Esta seguro de reiniciar el dispositivo ??", "Reiniciar Dispositivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rslt == DialogResult.Yes)
            {
                if (objZkeeper.RestartDevice(int.Parse(numeroequipo)))
                    ShowStatusBar("El dispositivo esta iniciando para su reinicio, Espere por favor...", true);
                else
                    ShowStatusBar("Fallo la operación, por favor intentelo de nuevo", false);
            }

        }

        private void btnGetDeviceTime_Click(object sender, EventArgs e)
        {
            int machineNumber = int.Parse(numeroequipo);
            int dwYear = 0;
            int dwMonth = 0;
            int dwDay = 0;
            int dwHour = 0;
            int dwMinute = 0;
            int dwSecond = 0;

            bool result = objZkeeper.GetDeviceTime(machineNumber, ref dwYear, ref dwMonth, ref dwDay, ref dwHour, ref dwMinute, ref dwSecond);

            string deviceTime = new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond).ToString();
            List<DeviceTimeInfo> lstDeviceInfo = new List<DeviceTimeInfo>();
            lstDeviceInfo.Add(new DeviceTimeInfo() { DeviceTime = deviceTime });
            BindToGridView(lstDeviceInfo);
        }


        private void btnEnableDevice_Click(object sender, EventArgs e)
        {
            // This is of no use since i implemented zkemKeeper the other way
            bool deviceEnabled = objZkeeper.EnableDevice(int.Parse(numeroequipo), true);

        }



        private void btnDisableDevice_Click(object sender, EventArgs e)
        {
            // This is of no use since i implemented zkemKeeper the other way
            bool deviceDisabled = objZkeeper.DisableDeviceWithTimeOut(int.Parse(numeroequipo), 3000);
        }

        //private void tbxPort_TextChanged(object sender, EventArgs e)
        //{ UniversalStatic.ValidateInteger(puerto); }

        //private void tbxMachineNumber_TextChanged(object sender, EventArgs e)
        //{ UniversalStatic.ValidateInteger(tbxMachineNumber); }

        private void Master_Load(object sender, EventArgs e)
        {
            ObtenerDispositivos();
            lblTituloEmpresa.Text = frmAcceso.NombreEmpresa;
        }

        private void btnUploadUserInfo_Click(object sender, EventArgs e)
        {
            //Add you new UserInfo Here and  uncomment the below code
            List<UserInfo> lstUserInfo = new List<UserInfo>();
            manipulator.ClearGLog(objZkeeper, int.Parse(numeroequipo));
            //manipulator.UploadFTPTemplate(objZkeeper, int.Parse(numeroequipo), lstUserInfo);
        }

       
        private void ObtenerDispositivos()
        {
            List<EntDispositivo> ListaDispositivos = new List<EntDispositivo>();
            ListaDispositivos = ctrlDispositivo.ObtenerPorEmpresa(frmAcceso.Id_Empresa);
            cmbDispositivo.DataSource = ListaDispositivos;
            cmbDispositivo.DisplayMember = "dispositivo_sucursal";
            cmbDispositivo.ValueMember = "id_dispositivo";
            cmbDispositivo.SelectedIndex = -1;
        }
    }
}
