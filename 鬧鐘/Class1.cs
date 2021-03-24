using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 鬧鐘
{


    public class cycle
    {
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        [JsonProperty]
        private string[] week { get; set; }
        [JsonProperty]
        private DateTime dateTime { get; set; }
        public cycle()
        {

        }
        public cycle(DateTime date)
        {
            dateTime = date;
        }
        public cycle(string[] WEEK)
        {
            week = WEEK;
        }
        public object get_week_data()
        {
            if (week == null)
            {
                return dateTime;
            }
            else
            {
                return week;
            }
        }
    }

    public class ALARM
    {
        [JsonProperty]
        private string must;
        public bool open_off;
        
        public cycle Cycle;
        [JsonProperty]
        private int Hour;
        [JsonProperty]
        private int Minute;
        [JsonProperty]
        private int sec=0;
        public ALARM()
        {

        }

        public ALARM(int hour, int m, string MUST, bool t_f, DateTime dateTime)
        {
            Hour = hour;
            Minute = m;
            //alarm = new ALARM_3_1(m, hour);
            must = MUST;
            open_off = t_f;
            this.Cycle = new cycle(dateTime);

        }

        public ALARM(int hour, int m, string MUST, bool t_f, string[] week)
        {
            Hour = hour;
            Minute = m;
            //alarm = new ALARM_3_1(m, hour);
            must = MUST;
            open_off = t_f;
            this.Cycle = new cycle(week);
        }

        public void get_alarm_time(ref int Hour,ref int Minute)//回傳設定的鬧鐘時間
        {
            Hour = this.Hour;
            Minute = this.Minute;
        }
        public bool get_open_off()//回傳鬧鐘(現在狀態)
        {
            return open_off;
        }
        public void get_open_off(bool true_off)//更改鬧鐘的狀態
        {
            open_off = true_off;
        }

        public string get_must()//回傳(現在)音樂
        {
            return must;
        }
        public void chang_must(string must_1)//更改音樂
        {
            must = must_1;
        }

        public bool Alarm_()//核對時間是否一致
        {
           //核對時間是否到時間
            int NOW_Hour=DateTime.Now.Hour;
            int NOW_Minute = DateTime.Now.Minute;
            int NOW_Sec = DateTime.Now.Second;
            if (Cycle.get_week_data().GetType().Name.ToString() == "DateTime")
            {
                DateTime 設定 = (DateTime)Cycle.get_week_data();
                string date = DateTime.Now.Date.ToString();//現在的日期
                string DATA = 設定.Date.ToString();//設定的日期
                if (date == DATA)
                {
                    if (NOW_Hour==Hour &&NOW_Minute==Minute&& NOW_Sec==sec)
                        return true;
                }
            }
            else
            {
                
                string now_Week = DateTime.Now.DayOfWeek.ToString();//now星期
                string[] week = (string[])Cycle.get_week_data();
                bool week_true_false = !(Array.IndexOf(week, now_Week) == -1);
                if (open_off)
                {
                    if (NOW_Hour == Hour && NOW_Minute == Minute && NOW_Sec == sec)
                        return true;
                }
            }

            return false;
        }
        public string alarm_all_value()//字串輸出
        {
            string h = Hour.ToString();
            string m = Minute.ToString();
            string week = "";
            if (Cycle == null)
                return "";
            if (Cycle.get_week_data().GetType() == typeof(string[]))
            {
                string[] WEEK;
                WEEK = (string[])Cycle.get_week_data();
                foreach (var i in WEEK)
                    week = week + i + " ";
            }
            else
            {
                DateTime DATA = (DateTime)Cycle.get_week_data();

                week = DATA.Year.ToString() + "/" + DATA.Month.ToString() + "/" + DATA.Day.ToString();
            }

            return h + ":" + m + "   " + week + "<" + must + ">";
        }
        public void recovery()
        {
            open_off = true;
        }

        
    }
    public class Music_database //音樂的資料庫的類別
    {
        [JsonProperty]
        private string name { get; set; }//名稱
        [JsonProperty]
        private string position { get; set; }//位置
        public Music_database(string NAME, string POSITION)
        {
            name = NAME;
            position = POSITION;
        }
        public string GetName()
        {
            return name;
        }
        public string GetPosition()
        {
            return position;
        }
    }


    public class music_management//音樂管理器
    {
        public List<Music_database> Databases;//全部的音樂
        public music_management(List<Music_database> total_music)//將音樂的資料輸入近來
        {
            Databases = total_music;
        }
        public Music_database search_name(string music_name)//收尋功能名稱
        {
           
            foreach (var i in Databases)
                if (i.GetName() == music_name)//收尋音樂的名稱
                    return i;//回傳收尋到的整個物件
            return null;//沒收尋到就回傳空直
        }
        public void Add_music(Music_database music)//新增音樂
        {
            // Music_database music = new Music_database(NAME, POSITION);
            Databases.Add(music);
        }

        public void delete_music(string music_name)//刪除音樂
        {
            if (search_name(music_name) != null)
                Databases.Remove(search_name(music_name));//刪除
        }
        public List<Music_database> totoal_music()//把所有音樂的資料庫回傳回去
        {
            return Databases;
        }
    }


}
