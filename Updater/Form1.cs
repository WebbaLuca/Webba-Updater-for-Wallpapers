using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Microsoft.Win32;


namespace Updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                Process[] proc = Process.GetProcessesByName("Webba Wallpapers");

                Console.WriteLine(proc[0]);

                proc[0].Kill();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
           

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed! Webba Wallpapers will restart now.");
            progressBar1.Value = 0;

            

            
            System.Diagnostics.Process.Start(Application.StartupPath + "/Webba Wallpapers.exe");
            Environment.Exit(0);
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
                WebClient webClient = new WebClient();

                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileAsync(new Uri("https://software.webba-creative.com/wallpapers/last/Webba_Wallpapers.exe"), Application.StartupPath + @"\Webba Wallpapers.exe");
        }
        }
}
