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
			//Console.WriteLine(Reflection.GetBattleTag().Name + "#" + Reflection.GetBattleTag().Number);
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

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);

            Console.WriteLine("File opened!");
        }

        private void timerData_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Saving data!");
            try
            {
                DataSet ds = new DataSet(); // создаем пока что пустой кэш данных
                DataTable dt = new DataTable(); // создаем пока что пустую таблицу данных
                dt.TableName = "Account"; // название таблицы
                dt.Columns.Add("Battle_TAG"); // название колонок
                dt.Columns.Add("Lvl");
                dt.Columns.Add("Email");
                dt.Columns.Add("daily80");
                ds.Tables.Add(dt); //в ds создается таблица, с названием и колонками, созданными выше

                foreach (DataGridViewRow r in dataGridView.Rows) // пока в dataGridView1 есть строки
                {
                    DataRow row = ds.Tables["Account"].NewRow(); // создаем новую строку в таблице, занесенной в ds
                    row["Battle_TAG"] = r.Cells[0].Value;  //в столбец этой строки заносим данные из первого столбца dataGridView
                    row["Lvl"] = r.Cells[1].Value; 
                    row["Email"] = r.Cells[2].Value;
                    row["daily80"] = r.Cells[3].Value;
                    ds.Tables["Account"].Rows.Add(row); //добавление всей этой строки в таблицу ds.
                }
                ds.WriteXml("accounts.xml");
                Console.WriteLine("XML file was successfully saved.");
            }
            catch
            {
                Console.WriteLine("Cant save XML file.");
            }
        }
    }
}
