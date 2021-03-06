using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 鬧鐘
{
    public partial class Form1 : Form
    {
        NotifyIcon notifyIcon;
        Alarm alarm = new Alarm();
        bool oNoff = false, oNoff_1 = false;
        SoundPlayer player = new SoundPlayer();
        dll test = new dll();
        
        public Form1()
        {
            InitializeComponent();
            listBox1.Enabled = false;
            notifyIcon = new NotifyIcon();//縮小視窗
            notifyIcon.Text = "開啟檔案";
            notifyIcon.Icon = new Icon("下載.ico");
            notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);


            string must_name = "must.csv";
            if (System.IO.File.Exists(must_name))//音樂檔案
            {
                StreamReader read_sw = new StreamReader(must_name);
                string totoal = read_sw.ReadToEnd();
                string[] vs = totoal.Split('\n');
                comboBox1.Items.AddRange(vs);
               
            }
            else
            {
                StreamWriter sw = new StreamWriter(must_name);
                sw.Close();
            }

            string FileName = "鬧鐘儲存資料.csv";
            if (System.IO.File.Exists(FileName))
            {
                StreamReader read_sw = new StreamReader("鬧鐘儲存資料.csv");
                string data = read_sw.ReadToEnd();
                string[] DATA = data.Split(',');
                for (int i = 0; i < DATA.Length - 3; i = i + 3)
                    alarm.add(DATA[i], DATA[i + 1], DATA[i + 2]);
                listBox1.Enabled = true;
                read_sw.Close();

                string[] h_SEVE = new string[alarm.length];
                string[] m_SEVE = new string[alarm.length];
                string[] week_SEVE = new string[alarm.length];
                alarm.m_h_save(ref h_SEVE, ref m_SEVE, ref week_SEVE);
                for (int i = 0; i < h_SEVE.Length; i++)
                    listBox1.Items.Add(h_SEVE[i] + "時" + m_SEVE[i] + "分 " + week_SEVE[i]);
            }
            else
            {
                StreamWriter sw = new StreamWriter("鬧鐘儲存資料.csv");
                sw.Close();
            }
            

            for (int i = 0; i < 60; i++)
                m.Items.Add(i);

            closs_miss.Enabled = false;
            button2.Enabled = false;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon.Visible = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)//關閉時觸發
        {
            StreamWriter sw = new StreamWriter("鬧鐘儲存資料.csv");
            string[] h_SEVE = new string[alarm.length];
            string[] m_SEVE = new string[alarm.length];
            string[] week_SEVE = new string[alarm.length];
            alarm.m_h_save(ref h_SEVE, ref m_SEVE, ref week_SEVE);
            for (int i = 0; i < h_SEVE.Length; i++)
                sw.Write(h_SEVE[i] + ',' + m_SEVE[i] + ',' + week_SEVE[i] + ',');
            sw.Close();
            StreamWriter sw1 = new StreamWriter("must.csv");
            foreach(var i in comboBox1.Items)
            {
                sw1.Write(i + "\n");
            }
            sw1.Close();
            if (oNoff)
                test.SetVol_dowon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string week = "";
            string hour, min;
            hour = Convert.ToString(h.SelectedItem);
            min = Convert.ToString(m.SelectedItem);
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i))
                    week = week + checkedListBox1.Items[i].ToString() + "_";
            alarm.add(hour, min, week);
            listBox1.Items.Add(hour + "時" + min + "分    " + week);
            string was = (string)comboBox1.SelectedItem;

        }
        public int i8 = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (alarm.ALARM(DateTime.Now.Hour.ToString(), DateTime.Now.Minute.ToString(), DateTime.Now.DayOfWeek.ToString()))
            {

                if (oNoff == false && oNoff_1 == false)
                {
                    for (int i = 0; i < 50; i++)
                        test.SetVol();
                    this.Show();
                    notifyIcon.Visible = false;
                    player.SoundLocation = "mp3.wav";
                    player.Load();
                    oNoff = true;
                    closs_miss.Enabled = true;
                    player.PlayLooping();
                }
            }
            else
            {
                oNoff_1 = false;
                oNoff = false;
            }



            label3.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" +
            DateTime.Now.Second.ToString() + "   " + DateTime.Now.DayOfWeek;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var test = listBox1.Items.IndexOf(listBox1.SelectedItem.ToString());
            listBox1.Items.Remove(listBox1.SelectedItem);
            alarm.delete(test);
            button2.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            oNoff_1 = true;
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            notifyIcon.Visible = true;
        }

        private void muiss_Click(object sender, EventArgs e)
        {
            OpenFileDialog saveFileDialog1 = new OpenFileDialog();
            saveFileDialog1.Filter="WAV|*.wav";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sw = new StreamReader(@saveFileDialog1.FileName.ToString());
                string name=saveFileDialog1.SafeFileName;
                comboBox1.Items.Add(name);
                File.Copy(@saveFileDialog1.FileName.ToString(), @"C:\Users\gink4\OneDrive\桌面\鬧鐘\鬧鐘\鬧鐘\bin\Debug\"+ name, true );
               
            }
        }

        private void closs_miss_Click(object sender, EventArgs e)
        {
            player.Stop();
            oNoff = false;
            oNoff_1 = true;
            closs_miss.Enabled = false;
            for (int i = 0; i < 40; i++)
                test.SetVol_dowon();

        }
    }
}
