using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioZUtility
{
    public partial class Frm_Instalador : Form
    {
        public Frm_Instalador()
        {
            InitializeComponent();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            //if (IntPtr.Size == 8)
            //{
            //    // Máquina con procesador de 64 bits
            //    btn_64Bits.Enabled = true;
                
            //}
            //else if (IntPtr.Size == 4)
            //{
            //    // Máquina con procesador de 32 bits
            //    btn_32Bits.Enabled = true;
            //}
        }

        private void btn_FrameWork_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            string fullimagepath = Path.Combine(Application.StartupPath, "NET_FrameWork4-5");
            info.UseShellExecute = true;
            info.FileName = "dotNetFx45_Full_setup.exe";
            info.WorkingDirectory = fullimagepath;
            Process.Start(info);
        }

        private void btn_64Bits_Click(object sender, EventArgs e)
        {


            string fullimagepath = Path.Combine(Application.StartupPath, "SDK_ZKTeco");
            string fileName = "commpro.dll";
            string sourcePath = fullimagepath;
            string targetPath = @"C:\Windows\SysWOW64";

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);

            // To copy all the files in one directory to another directory.
            // Get the files in the source folder. (To recursively iterate through
            // all subfolders under the current directory, see
            // "How to: Iterate Through a Directory Tree.")
            // Note: Check for target path was performed previously
            //       in this code example.
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }

            string command = "regsvr32 zkemkeeper.dll";
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = @"C:\Windows\SysWOW64";
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/user:Administrator \"cmd /K " + command + "\"";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void btn_32Bits_Click(object sender, EventArgs e)
        {
            string fullimagepath = Path.Combine(Application.StartupPath, "SDK_ZKTeco");
            string fileName = "commpro.dll";
            string sourcePath = fullimagepath;
            string targetPath = @"C:\Windows\System32";

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);

            // To copy all the files in one directory to another directory.
            // Get the files in the source folder. (To recursively iterate through
            // all subfolders under the current directory, see
            // "How to: Iterate Through a Directory Tree.")
            // Note: Check for target path was performed previously
            //       in this code example.
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }


            string command = "regsvr32 zkemkeeper.dll";
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = @"C:\Windows\System32";
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/user:Administrator \"cmd /K " + command + "\"";
            process.StartInfo = startInfo;
            process.Start();
            process.CloseMainWindow();

        }

        private void btn_SDKInformix32Bits_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            string fullimagepath = Path.Combine(Application.StartupPath, "SDK_Informix");
            info.UseShellExecute = true;
            info.FileName = "installclientsdk.exe";
            info.WorkingDirectory = fullimagepath;
            Process.Start(info);
        }

        private void btn_SDKDigitalPersona_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            string fullimagepath = Path.Combine(Application.StartupPath, "SDK_DigitalPersonal");
            info.UseShellExecute = true;
            info.FileName = "Setup.exe";
            info.WorkingDirectory = fullimagepath;
            Process.Start(info);

        }

        private void btn_BioZ_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            string fullimagepath = Path.Combine(Application.StartupPath, "BioZ");
            info.UseShellExecute = true;
            info.FileName = "setup.exe";
            info.WorkingDirectory = fullimagepath;
            Process.Start(info);
        }

        
    }
}
