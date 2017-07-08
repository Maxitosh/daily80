namespace daily80
{
	partial class frmMain
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.btnStartCreateAccs = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.timerDataSaver = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timerDataUpdater = new System.Windows.Forms.Timer(this.components);
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.Battle_TAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lvl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daily80 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartCreateAccs
            // 
            this.btnStartCreateAccs.Location = new System.Drawing.Point(11, 12);
            this.btnStartCreateAccs.Name = "btnStartCreateAccs";
            this.btnStartCreateAccs.Size = new System.Drawing.Size(116, 62);
            this.btnStartCreateAccs.TabIndex = 0;
            this.btnStartCreateAccs.Text = "Start creating accounts";
            this.btnStartCreateAccs.UseVisualStyleBackColor = true;
            this.btnStartCreateAccs.Click += new System.EventHandler(this.btnStartCreateAccs_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(170, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Battle_TAG,
            this.Lvl,
            this.email,
            this.daily80});
            this.dataGridView.Location = new System.Drawing.Point(310, 12);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(585, 445);
            this.dataGridView.TabIndex = 2;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(11, 425);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(81, 32);
            this.btnLoadData.TabIndex = 3;
            this.btnLoadData.Text = "Load DATA";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // timerDataSaver
            // 
            this.timerDataSaver.Interval = 5000;
            this.timerDataSaver.Tick += new System.EventHandler(this.timerDataSaver_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // timerDataUpdater
            // 
            this.timerDataUpdater.Tick += new System.EventHandler(this.timerDataUpdater_Tick);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(222, 377);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(82, 32);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(222, 425);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(82, 32);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Battle_TAG
            // 
            this.Battle_TAG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Battle_TAG.HeaderText = "Battle_TAG";
            this.Battle_TAG.Name = "Battle_TAG";
            this.Battle_TAG.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Lvl
            // 
            this.Lvl.HeaderText = "Lvl";
            this.Lvl.Name = "Lvl";
            this.Lvl.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // email
            // 
            this.email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // daily80
            // 
            this.daily80.HeaderText = "daily80";
            this.daily80.Name = "daily80";
            this.daily80.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 469);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStartCreateAccs);
            this.Name = "frmMain";
            this.Text = "QuestMiner";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.Button btnStartCreateAccs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Timer timerDataSaver;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Timer timerDataUpdater;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridViewTextBoxColumn Battle_TAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lvl;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn daily80;
    }
}

