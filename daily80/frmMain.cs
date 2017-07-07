using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HearthMirror;

namespace daily80
{
	public partial class frmMain : Form
	{
		[DllImport("kernel32.dll",
			EntryPoint = "AllocConsole",
			SetLastError = true,
			CharSet = CharSet.Auto,
			CallingConvention = CallingConvention.StdCall)]
		private static extern int AllocConsole();

		public frmMain()
		{
			InitializeComponent();
			AllocConsole();
			Console.WriteLine(Reflection.GetBattleTag().Name + "#" + Reflection.GetBattleTag().Number);
		}

	    private void btnStartCreateAccs_Click(object sender, EventArgs e)
	    {


	        StreamReader fileRead = new StreamReader("mails.txt");
	        string currMail = fileRead.ReadLine();
	        string lastPartOfFile = fileRead.ReadToEnd();
	        fileRead.Close();

	        StreamWriter fileWrite = new StreamWriter("mails.txt");
	        fileWrite.Write(lastPartOfFile);
	        fileWrite.Close();



	        Process ahk = new Process
	        {
	            StartInfo = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + @"\blizzard.ahk",
	                "Max" + " " + "Max" + " " + "1" + " " +
	                "1990" + " " + currMail + " " + "questsmining228" + " " + "bmw")
	        };
	        ahk.Start();


	        StreamWriter sw = new StreamWriter("accounts.txt", true);
	        sw.WriteLine(currMail);
	        sw.Close();


	    }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(Reflection.IsInMainMenu());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
