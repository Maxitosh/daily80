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
            this.btnStartCreateAccs = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartCreateAccs
            // 
            this.btnStartCreateAccs.Location = new System.Drawing.Point(29, 45);
            this.btnStartCreateAccs.Name = "btnStartCreateAccs";
            this.btnStartCreateAccs.Size = new System.Drawing.Size(116, 62);
            this.btnStartCreateAccs.TabIndex = 0;
            this.btnStartCreateAccs.Text = "Start creating accounts";
            this.btnStartCreateAccs.UseVisualStyleBackColor = true;
            this.btnStartCreateAccs.Click += new System.EventHandler(this.btnStartCreateAccs_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 469);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStartCreateAccs);
            this.Name = "frmMain";
            this.Text = "QuestMiner";
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.Button btnStartCreateAccs;
        private System.Windows.Forms.Button button1;
    }
}

