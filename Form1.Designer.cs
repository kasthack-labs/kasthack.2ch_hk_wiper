namespace _2ch_vk_wiper {
	partial class Form1 {
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent() {
			this.txt_url = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txt_accounts = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txt_proxies = new System.Windows.Forms.TextBox();
			this.btn_wipe = new System.Windows.Forms.Button();
			this.txt_wipe_text = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lbl_count = new System.Windows.Forms.Label();
			this.bw_wiper = new System.ComponentModel.BackgroundWorker();
			this.label6 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// txt_url
			// 
			this.txt_url.Location = new System.Drawing.Point(13, 43);
			this.txt_url.Name = "txt_url";
			this.txt_url.Size = new System.Drawing.Size(321, 20);
			this.txt_url.TabIndex = 0;
			this.txt_url.Text = "http://vk.com/wall-[0-9]+_[0-9]+";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Тред";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 103);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(148, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Файл с акками(логин:пасс)";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// txt_accounts
			// 
			this.txt_accounts.Location = new System.Drawing.Point(13, 142);
			this.txt_accounts.Name = "txt_accounts";
			this.txt_accounts.Size = new System.Drawing.Size(321, 20);
			this.txt_accounts.TabIndex = 3;
			this.txt_accounts.Text = "B:\\dbg_v\\acc.txt";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 183);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(160, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Файл с проксями(адрес:порт)";
			// 
			// txt_proxies
			// 
			this.txt_proxies.Location = new System.Drawing.Point(13, 241);
			this.txt_proxies.Name = "txt_proxies";
			this.txt_proxies.Size = new System.Drawing.Size(321, 20);
			this.txt_proxies.TabIndex = 5;
			this.txt_proxies.Text = "B:\\dbg_v\\prox.txt";
			// 
			// btn_wipe
			// 
			this.btn_wipe.Location = new System.Drawing.Point(16, 461);
			this.btn_wipe.Name = "btn_wipe";
			this.btn_wipe.Size = new System.Drawing.Size(318, 51);
			this.btn_wipe.TabIndex = 6;
			this.btn_wipe.Text = "Завайпать!";
			this.btn_wipe.UseVisualStyleBackColor = true;
			this.btn_wipe.Click += new System.EventHandler(this.button1_Click);
			// 
			// txt_wipe_text
			// 
			this.txt_wipe_text.Location = new System.Drawing.Point(13, 311);
			this.txt_wipe_text.Multiline = true;
			this.txt_wipe_text.Name = "txt_wipe_text";
			this.txt_wipe_text.Size = new System.Drawing.Size(321, 75);
			this.txt_wipe_text.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 277);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Текст(только латиница)";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(13, 421);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Отправлено";
			// 
			// lbl_count
			// 
			this.lbl_count.AutoSize = true;
			this.lbl_count.Location = new System.Drawing.Point(106, 420);
			this.lbl_count.Name = "lbl_count";
			this.lbl_count.Size = new System.Drawing.Size(13, 13);
			this.lbl_count.TabIndex = 10;
			this.lbl_count.Text = "0";
			// 
			// bw_wiper
			// 
			this.bw_wiper.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_wiper_DoWork);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(379, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(160, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Задержка между постами(мс)";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(382, 56);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
			this.numericUpDown1.TabIndex = 12;
			this.numericUpDown1.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(382, 121);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(134, 17);
			this.checkBox1.TabIndex = 13;
			this.checkBox1.Text = "Вайпать без проксей";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(604, 524);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.lbl_count);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txt_wipe_text);
			this.Controls.Add(this.btn_wipe);
			this.Controls.Add(this.txt_proxies);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_accounts);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txt_url);
			this.Name = "Form1";
			this.Text = "Поехавший против ВК";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txt_url;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txt_accounts;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txt_proxies;
		private System.Windows.Forms.Button btn_wipe;
		private System.Windows.Forms.TextBox txt_wipe_text;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lbl_count;
		private System.ComponentModel.BackgroundWorker bw_wiper;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}

