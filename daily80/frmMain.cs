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
using System.Xml;
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

        /*
        Classes
        */

        BattleNet btNet = new BattleNet();

        Account account = new Account();

        Log log = new Log();

        /*
        BOOLEANS
        */
        bool canWriteToXML = true; // it is for good work between load btn and timer saver

        private bool canReadDataGrid = true;

        /*
         STRINGS
         */
         
        ////////////////////////////

        public frmMain()
        {
            InitializeComponent();
            AllocConsole();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

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

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // getting selected file
            string filename = openFileDialog.FileName;

            log.LogMessage("File opened!", MessageType.Normal);

            StreamReader fileRead = new StreamReader(filename);
            // count of uniq accs added to data
            int count = 0;
            while (!fileRead.EndOfStream)
            {
                string acc = fileRead.ReadLine();

                // adding to dataGrid with checking of unic accs
                bool b = addToDataGrid(acc);
                if (b)
                    count++;
            }
            // perform work to this thread

            if (!canWriteToXML && count != 0)
            {
                canWriteToXML = false;
                addToXml();
            }
            canWriteToXML = true;
            // closing opened file
            fileRead.Close();
            log.LogMessage("Added " + count + " new accs", MessageType.Normal);
        }

        private bool addToDataGrid(string acc)
        {
            bool isInData = false;
            bool success = false;
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                var formattedValue = dataGridView.Rows[i].Cells[2].FormattedValue;
                if (acc != null && (formattedValue != null && formattedValue.Equals(acc)))
                {
                    isInData = true;
                }
            }
            if (!isInData)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView.Rows[0].Clone();
                row.Cells[0].Value = "";
                row.Cells[1].Value = "";
                row.Cells[2].Value = acc;
                row.Cells[3].Value = "false";
                dataGridView.Rows.Add(row);
                success = true;
            }
            return success;
        }

        private void addToXml()
        {
            log.LogMessage("Autosaving data!", MessageType.Normal);
            try
            {
                DataSet ds = new DataSet(); // создаем пока что пустой кэш данных
                ds.DataSetName = "ACCOUNTS";
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
                log.LogMessage("XML file was successfully saved.", MessageType.Normal);
            }
            catch (Exception ex)
            {
                log.LogMessage("Cant save XML file.", MessageType.Error);
                log.LogMessage(ex.Message, MessageType.Error);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            initDataGrid();
        }

        private void initDataGrid()
        {
            try
            {
                /*
                XmlReader xmlFile;
	            xmlFile = XmlReader.Create("accounts.xml", new XmlReaderSettings());
	            DataSet ds = new DataSet();
	            ds.ReadXml(xmlFile);
	            dataGridView.DataSource = ds.Tables[0];
                */

                XmlDataDocument xmldoc = new XmlDataDocument();
                XmlNodeList xmlnode;
                int i = 0;
                string str = null;
                FileStream fs = new FileStream("accounts.xml", FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName("Account");
                for (i = 0; i < xmlnode.Count - 1; i++)
                {
                    //xmlnode[i].ChildNodes.Item(0).InnerText.Trim();

                    DataGridViewRow row = (DataGridViewRow)dataGridView.Rows[0].Clone();
                    row.Cells[0].Value = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    row.Cells[1].Value = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                    row.Cells[2].Value = xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
                    row.Cells[3].Value = xmlnode[i].ChildNodes.Item(3).InnerText.Trim();
                    dataGridView.Rows.Add(row);
                }
                fs.Close();
                log.LogMessage("Successfully loaded data from XML to dataGrid", MessageType.Normal);
            }
            catch (Exception ex)
            {
                log.LogMessage(ex.ToString(), MessageType.Error);
            }
        }

        private void timerDataSaver_Tick(object sender, EventArgs e)
        {
            if (canWriteToXML && canReadDataGrid)
            {
                canWriteToXML = false;
                canReadDataGrid = false;
                addToXml();
                canWriteToXML = true;
                canReadDataGrid = true;
            }
        }

        private void timerDataUpdater_Tick(object sender, EventArgs e)
        {
            Process[] proc = Process.GetProcessesByName("Hearthstone");
            if (proc.Length != 0)
            {
                log.LogMessage("Hearthstone detected!", MessageType.Normal);
                if (Reflection.IsInMainMenu() && canReadDataGrid)
                {
                    account.BattleTag = Reflection.GetBattleTag().Name + "#" + Reflection.GetBattleTag().Number;
                    int index = 0;
                    canReadDataGrid = false;
                    for (int i = 0; i < dataGridView.RowCount; i++)
                    {
                        var formattedValue = dataGridView.Rows[i].Cells[2].FormattedValue;
                        if (formattedValue != null && formattedValue.Equals(account.Username))
                        {
                            index = i;
                        }
                    }
                    canReadDataGrid = true;
                    dataGridView.Rows[index].Cells[0].Value = account.BattleTag;
                    if (frmMain.ActiveForm != null)
                        frmMain.ActiveForm.Text = "Current acc is BattleTag:" + account.BattleTag + " email:" +
                                                  account.Username;
                    log.LogMessage("Updated BattleTag:" + account.BattleTag + " for account " + account.Username, MessageType.Normal);
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int index = dataGridView.SelectedRows[0].Index;

            string email = dataGridView.Rows[index].Cells[2].FormattedValue.ToString();
            string psswrd = "questsmining228";

            account.Username = email;
            account.Password = psswrd;

            frmMain.ActiveForm.Text = "Current acc is BattleTag:" + account.BattleTag + " email:" + account.Username;

            btNet.StartBnetAccount(email, psswrd);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            account.Username = "";
            account.Password = "";
            account.BattleTag = "";

            frmMain.ActiveForm.Text = "Idle";

            btNet.LogoutBnet();
        }
    }
}
