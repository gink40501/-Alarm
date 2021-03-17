using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 鬧鐘
{


    class week
    {
        private int[] date = new int[7];
        private int[] WEEK = new int[7];
        public void input(string WEEK, int DATA)
        {
            switch (WEEK)
            {
                case "Monday":
                    date[0] = DATA;
                    this.WEEK[0] = 0;
                    break;
                case "Tuesday":
                    date[1] = DATA;
                    this.WEEK[1] = 1;
                    break;
                case "Wednesday":
                    date[2] = DATA;
                    this.WEEK[2] = 2;
                    break;
                case "Thursday":
                    date[3] = DATA;
                    this.WEEK[3] = 3;
                    break;
                case "Friday":
                    date[4] = DATA;
                    this.WEEK[4] = 4;
                    break;
                case "Saturday":
                    date[5] = DATA;
                    this.WEEK[5] = 5;
                    break;
                case "Sunday":
                    date[6] = DATA;
                    this.WEEK[6] = 6;
                    break;

            }
        }
        public int[] git_data()
        {
            return date;
        }
        public int[] git_week()
        {
            return WEEK;
        }
    }

    class month
    {
        public List<week> Weeks = new List<week>();
        public int MANTH;
        public int your;
        public int Days;
        public month(int YOUR, int manth)
        {
            DateTime dateTime;
            MANTH = manth;
            your = YOUR;
            dateTime = new DateTime(your, MANTH, 1, 0, 0, 0);
            Days = DateTime.DaysInMonth(your, MANTH);
            Weeks.Add(new week());
            var j = 0;
            for (int i = 1; i <= Days; i++)
            {
                dateTime = new DateTime(your, MANTH, i, 0, 0, 0);
                var week = dateTime.DayOfWeek.ToString();
                Weeks[j].input(week, Convert.ToInt32(dateTime.Day));
                if (week == "Sunday")
                {
                    j++;
                    Weeks.Add(new week());
                }

            }
        }
        public List<week> git_total()
        {
            return Weeks;
        }
        public void button_print_week( )
        {

        }

    }


}
