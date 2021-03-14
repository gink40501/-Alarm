
namespace 鬧鐘
{
    partial class 鬧鐘
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(鬧鐘));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.星期資料 = new System.Windows.Forms.CheckedListBox();
            this.h = new System.Windows.Forms.ComboBox();
            this.m = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.刪除 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.closs_miss = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.muiss = new System.Windows.Forms.Button();
            this.music_TOTAL = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.日曆 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listBox1.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 32;
            this.listBox1.Location = new System.Drawing.Point(12, 341);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(953, 196);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // 星期資料
            // 
            this.星期資料.FormattingEnabled = true;
            this.星期資料.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.星期資料.Location = new System.Drawing.Point(634, 12);
            this.星期資料.Name = "星期資料";
            this.星期資料.Size = new System.Drawing.Size(127, 186);
            this.星期資料.TabIndex = 1;
            // 
            // h
            // 
            this.h.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.h.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.h.FormattingEnabled = true;
            this.h.Location = new System.Drawing.Point(12, 62);
            this.h.Name = "h";
            this.h.Size = new System.Drawing.Size(121, 36);
            this.h.TabIndex = 2;
            // 
            // m
            // 
            this.m.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.m.FormattingEnabled = true;
            this.m.Location = new System.Drawing.Point(234, 62);
            this.m.Name = "m";
            this.m.Size = new System.Drawing.Size(121, 36);
            this.m.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "時";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(374, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "分";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Info;
            this.button1.Location = new System.Drawing.Point(800, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 47);
            this.button1.TabIndex = 6;
            this.button1.Text = "確定處存鬧鐘資料";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.存資料_Click);
            // 
            // 刪除
            // 
            this.刪除.Location = new System.Drawing.Point(234, 280);
            this.刪除.Name = "刪除";
            this.刪除.Size = new System.Drawing.Size(127, 45);
            this.刪除.TabIndex = 7;
            this.刪除.Text = "刪除鬧鐘";
            this.刪除.UseVisualStyleBackColor = true;
            this.刪除.Click += new System.EventHandler(this.刪除_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(460, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 36);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(460, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 36);
            this.label4.TabIndex = 9;
            this.label4.Text = "現在時間";
            // 
            // closs_miss
            // 
            this.closs_miss.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.closs_miss.Location = new System.Drawing.Point(21, 131);
            this.closs_miss.Name = "closs_miss";
            this.closs_miss.Size = new System.Drawing.Size(334, 106);
            this.closs_miss.TabIndex = 10;
            this.closs_miss.Text = "關閉鬧鐘";
            this.closs_miss.UseVisualStyleBackColor = true;
            this.closs_miss.Click += new System.EventHandler(this.closs_miss_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(800, 67);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 40);
            this.button3.TabIndex = 11;
            this.button3.Text = "隱藏";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.隱藏到工具列_Click);
            // 
            // muiss
            // 
            this.muiss.Location = new System.Drawing.Point(800, 113);
            this.muiss.Name = "muiss";
            this.muiss.Size = new System.Drawing.Size(127, 41);
            this.muiss.TabIndex = 12;
            this.muiss.Text = "新增音樂";
            this.muiss.UseVisualStyleBackColor = true;
            this.muiss.Click += new System.EventHandler(this.muiss_Click);
            // 
            // music_TOTAL
            // 
            this.music_TOTAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.music_TOTAL.FormattingEnabled = true;
            this.music_TOTAL.Location = new System.Drawing.Point(800, 201);
            this.music_TOTAL.Name = "music_TOTAL";
            this.music_TOTAL.Size = new System.Drawing.Size(127, 26);
            this.music_TOTAL.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(803, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 28);
            this.label5.TabIndex = 14;
            this.label5.Text = "選擇音樂";
            // 
            // 日曆
            // 
            this.日曆.Checked = false;
            this.日曆.CustomFormat = "";
            this.日曆.Font = new System.Drawing.Font("新細明體", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.日曆.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.日曆.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.日曆.Location = new System.Drawing.Point(634, 210);
            this.日曆.Name = "日曆";
            this.日曆.Size = new System.Drawing.Size(127, 27);
            this.日曆.TabIndex = 15;
            this.日曆.Value = new System.DateTime(2021, 3, 13, 0, 0, 0, 0);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "星期",
            "日期"});
            this.comboBox1.Location = new System.Drawing.Point(466, 113);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 26);
            this.comboBox1.TabIndex = 16;
            // 
            // 鬧鐘
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(974, 555);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.日曆);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.music_TOTAL);
            this.Controls.Add(this.muiss);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.closs_miss);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.刪除);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m);
            this.Controls.Add(this.h);
            this.Controls.Add(this.星期資料);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "鬧鐘";
            this.Text = "鬧鐘";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckedListBox 星期資料;
        private System.Windows.Forms.ComboBox h;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button 刪除;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button closs_miss;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button muiss;
        private System.Windows.Forms.ComboBox music_TOTAL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker 日曆;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox m;
    }
}

