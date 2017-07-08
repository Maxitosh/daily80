using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daily80
{
    class BattleNet
    {

        string _installDir = @"D:\Games\Blizzard App\Battle.net.exe";

        public string InstallDir
        {
            get { return _installDir; }
            set { _installDir = value; }
        }

        public bool IsBnetRunning()
        {
            Process[] pname = Process.GetProcessesByName("Battle.net.exe");
            if (pname.Length == 0)
                return false;
            else
                return true;
        }

        public void KillBnet()
        {
            Process[] proc = Process.GetProcessesByName("Battle.net.exe");
            proc[0].Kill();
        }

        public bool LoginBnet(string email, string password)
        {
            if (!IsBnetRunning())
            {
                LogoutBnet();
            }
            Process ahk = new Process { StartInfo = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + @"\Bnet.ahk", email + " " + password) };
            ahk.Start();
            return true;
        }

        public bool StartBnetAccount(string email, string password)
        {
            LoginBnet(email, password);

            return false;
        }

        public bool LogoutBnet()
        {
            //Process.Start(installDir, " --exec = \"logout\"");

            if (File.Exists(_installDir))
            {
                Process proc = Process.Start(Environment.SystemDirectory + @"\cmd.exe", "cmd /k \"\"" + InstallDir + "\" \"--exec=\"logout\"\"\" && exit");
                if (proc != null)
                {
                    proc.StartInfo.CreateNoWindow = true;
                    proc.Start();
                }

                return true;
            }
            return false;

        }
    }
}
