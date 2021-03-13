using Newtonsoft.Json;
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
    public partial class 鬧鐘 : Form
    {
        bool on_off=true;
        NotifyIcon notifyIcon;
        SoundPlayer player = new SoundPlayer();//音樂的撥放器
        dll sound = new dll();//控制user的dll
        List<ALARM> Alam= new List<ALARM>();//鬧鐘的資料
        music_management management;//音樂管理器
        List<Music_database> music = new List<Music_database>();//全部的音樂資料
        int day = -1;
        public 鬧鐘()
        {
            InitializeComponent();
            notifyIcon = new NotifyIcon();//縮小視窗
            notifyIcon.Text = "開啟檔案";//顯示提示
            //notifyIcon.Icon = new Icon("下載.ico");//小圖示
            notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            closs_miss.Enabled = false;
            刪除.Enabled = false;
            comboBox1.Text = comboBox1.Items[0].ToString();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon.Visible = false;
        }

        private void Form1_Shown(object sender, EventArgs e)//當剛開始的時候執行
        {
            for (int i = 0; i < 60; i++)//把時鐘的時間輸入進去到combobox
                m.Items.Add(i);
            for (int i = 0; i < 24; i++)
                h.Items.Add(i);
            m.Text = "0";
            h.Text = "0";
            if (File.Exists("鬧鐘儲存資料.json"))//偵測檔案是否存在 鬧鐘
            {
                StreamReader READ_ALARM = new StreamReader("鬧鐘儲存資料.json");
                string alarm = READ_ALARM.ReadToEnd();//讀取檔案裡面字串 
                Alam = JsonConvert.DeserializeObject<List<ALARM>>(alarm);//反序列化 格式List<ALARM>
                READ_ALARM.Close();
                foreach (var i in Alam)//將資料傳到listbox
                    listBox1.Items.Add(i.alarm_all_value());
            }
            if (File.Exists("音樂的儲存資料.json"))//偵測檔案是否存在 音樂資料
            {
                StreamReader total_music_sw = new StreamReader("音樂的儲存資料.json");
                string total_music = total_music_sw.ReadToEnd();//全部讀取
                music = JsonConvert.DeserializeObject<List<Music_database>>(total_music);//json檔案序列化
                management = new music_management(music);
                total_music_sw.Close();
                foreach(var i in music)//將資料匯入music_TOTAL下拉式選單
                    music_TOTAL.Items.Add(i.GetName());
                music_TOTAL.Text = music[0].GetName();
            }
            else
            {
                management = new music_management(music);
            }
            
            
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)//關閉時觸發
        {
           
            StreamWriter sw = new StreamWriter("鬧鐘儲存資料.json");

            //JsonSerializerSettings jsetting = new JsonSerializerSettings();
            //jsetting.NullValueHandling = NullValueHandling.Ignore;
            //Formatting.Indented
            var alarm = JsonConvert.SerializeObject(Alam); //SerializeObject(Alam);//序列化存成字串
            sw.Write(alarm);//寫入檔案
            sw.Close();//關閉檔案

            StreamWriter sw_josm = new StreamWriter("音樂的儲存資料.json");
            var alarm_1 = JsonConvert.SerializeObject(management.totoal_music());
            sw_josm.Write(alarm_1);//寫入檔案
            sw_josm.Close();//關閉檔案

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString()==comboBox1.Items[0].ToString())
            {
                日曆.Enabled = false;
                星期資料.Enabled = true;
            }
            else
            {
               日曆.Enabled = true;
               星期資料.Enabled = false; 
            }

           int now_day=Convert.ToInt32(DateTime.Now.Day.ToString());
            if (now_day != day)
            {//這個功能是 主要過完一天所有的按鈕都要回復
                day=now_day  ;
                foreach (var i in Alam)
                    i.recovery();
            }

            label3.Text = DateTime.Now.ToString();
            foreach(var i in Alam)//核對時間
                if (i.Alarm_()==true)
                {
                    if (on_off==true) {
                        sound.SetVol();
                        for (int j=0;j<50;j=j+2)//把聲音大到音量100
                            sound.SetVol();
                        var route= management.search_name(i.get_must());
                        player.SoundLocation=route.GetPosition();//把音樂路徑匯入裡面
                        player.PlayLooping();
                        on_off = false;
                        closs_miss.Enabled = true;
                    }
                }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            刪除.Enabled = true;
        }
        private void muiss_Click(object sender, EventArgs e)
        {
            OpenFileDialog saveFileDialog1 = new OpenFileDialog();//開啟物件視窗
            saveFileDialog1.Filter="WAV|*.wav";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sw = new StreamReader(@saveFileDialog1.FileName.ToString());//選取的物件
                string name=saveFileDialog1.SafeFileName;//選取的物件名稱
                Music_database music = new Music_database(name, @saveFileDialog1.FileName.ToString());

                music_TOTAL.Items.Add(music.GetName());//加入combobox
                management.Add_music(music);
            }
        }
        private void 存資料_Click(object sender, EventArgs e)//全部的儲存資料
        {
            
            var H = h.SelectedItem.ToString();
            var M = m.SelectedItem.ToString();
            string name_music = management.search_name(music_TOTAL.Text).GetName();//取得被選取的音樂資料
            cycle CYCLE;
            if (comboBox1.Text.ToString()=="星期")//如果是選擇到星期
            {
                string[] week = new string[星期資料.CheckedItems.Count];//星期
                int j = 0;
                foreach (var i in 星期資料.CheckedItems)//將全部有選取的資料輸入到week
                {
                    week[j] = i.ToString();
                    j++;
                }
                ALARM newAlarm = new ALARM(Convert.ToInt32(H), Convert.ToInt32(M), name_music, true, week);
                Alam.Add(newAlarm);
            }
            else
            {
                ALARM newAlarm = new ALARM(Convert.ToInt32(H), Convert.ToInt32(M), name_music, true, 日曆.Value);
                Alam.Add(newAlarm);
            }
            
           
            
            listBox1.Items.Clear();
            foreach (var i in Alam)
                listBox1.Items.Add(i.alarm_all_value());
        }

        private void 隱藏到工具列_Click(object sender, EventArgs e)
        {
            this.Hide();
            notifyIcon.Visible = true;
        }

        private void closs_miss_Click(object sender, EventArgs e)
        {
            for(int i=0; i<70/2;i++)
                sound.SetVol_dowon();
            player.Stop();
            foreach(var i in Alam)
                if (i.Alarm_()==true)
                    i.open_off = false;
            on_off = true;
            closs_miss.Enabled = false;
        }

        private void 刪除_Click(object sender, EventArgs e)
        {
            int position;
            position = listBox1.Items.IndexOf(listBox1.SelectedItem.ToString());
            listBox1.Items.Remove(listBox1.SelectedItem.ToString());//移除lsitbox的資料
            Alam.Remove(Alam[position]);//刪除資料庫的資料
            刪除.Enabled = false;
        }
    }
}
