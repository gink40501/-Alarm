using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 鬧鐘
{
    class Alarm
    {
        private List<string> h = new List<string>();//時
        private List<string> m = new List<string>();//分
        private List<string> week = new List<string>();//星期
        private List<string> music = new List<string>();//音樂
        public void add(string H, string M, string week)
        {
            h.Add(H);
            m.Add(M);
            this.week.Add(week);
        }
        public void m_h_save(ref string[] H, ref string[] M, ref string[] WEEK)
        {
            WEEK = week.ToArray();
            H = h.ToArray();
            M = m.ToArray();
        }
        public int length
        {
            get=> h.Count;
        }
        public void delete(int i)
        {
            h.RemoveAt(i);
            m.RemoveAt(i);
            week.RemoveAt(i);
        }
        public bool ALARM(string H, string M, String week_1)
        {


            bool t_f = false;
            for (int i = 0; i < h.Count; i++)
            {
                string WEEK = week[i];
                string[] Week = WEEK.Split('_');
                if (h[i] == H && m[i] == M)
                {
                    foreach (var j in Week)
                        if (j == week_1)
                        {
                            t_f = true;
                            break;
                        }
                    break;
                }
            }
            return t_f;

        }
    }

    public class ALARM_3_1
    {
        private int H;
        private int M;
        public ALARM_3_1(int h, int m)
        {
            H = h;
            M = m;
        }
        public int return_hour()
        {
            return H;
        }
        public int return_m()
        {
            return M;
        }
    }

    public class ALARM
    {
        private string must;
        private bool open_off;
        private string[] week;
        private ALARM_3_1 alarm;
        
        public ALARM(int m, int hour, string MUST, bool t_f, string[] WEEK)
        {
            alarm = new ALARM_3_1(m, hour);
            must = MUST;
            open_off = t_f;
            week = WEEK;
        }

        public ALARM_3_1 get_alarm_time(ref string[] WEEK)//回傳設定的鬧鐘時間
        {
            WEEK=week;
            return alarm;
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

        public bool Alarm()
        {
            string now_Week = DateTime.Now.DayOfWeek.ToString();
            bool week_true_false = !(Array.IndexOf(week, now_Week) == -1);
            ALARM_3_1 now_time = new ALARM_3_1(DateTime.Now.Minute, DateTime.Now.Hour);//核對時間是否到時間
            if (open_off)
            {
                if (now_time == alarm && week_true_false && open_off)
                    return true;
            }
            return false;
        }

    }

}
