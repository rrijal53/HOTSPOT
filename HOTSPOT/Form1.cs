using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOTSPOT
{
    public partial class Form1 : Form

    {
        Process p = new Process();
        public Form1()
        {
            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = Convert.ToString(txtName.Text);
            String password = Convert.ToString(txtPassword.Text);
            var proc1 = new ProcessStartInfo();
            string command = "netsh wlan set hostednetwork mode=allow ssid="+name +" key="+password+" && netsh wlan start hostednetwork";
            proc1.UseShellExecute = true;

            proc1.WorkingDirectory = @"C:\Windows\System32";

            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " +command;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var proc1 = new ProcessStartInfo();
            string command =  "netsh wlan stop hostednetwork";
            proc1.UseShellExecute = true;

            proc1.WorkingDirectory = @"C:\Windows\System32";

            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " + command;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);
            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
