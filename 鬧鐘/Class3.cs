using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 鬧鐘
{
    class Class3
    {
        class week {
            private int[] date = new int[7];
            public void input(string WEEK, int DATA)
            {
                switch (WEEK)
                {
                    case "Monday":
                        date[0] = DATA;
                        break;
                    case "Tuesday":
                        date[1] = DATA;
                        break;
                    case "Wednesday":
                        date[2] = DATA;
                        break;
                    case "Thursday":
                        date[3] = DATA;
                        break;
                    case "Friday":
                        date[4] = DATA;
                        break;
                    case "Saturday":
                        date[5] = DATA;
                        break;
                    case "Sunday":
                        date[6] = DATA;
                        break;

                }
            }
            public int[] git_week_data()
            {
                return date;
            }
        }

        class month{
            public List<week> Weeks;
            public int MANTH;
            public int your;
            public int Days;
            public month(int YOUR,int manth)
            {
                DateTime dateTime;
                MANTH = manth;
                your = YOUR;
                dateTime = new DateTime(your, MANTH,1,0,0,0);
                Days= DateTime.DaysInMonth(your,MANTH);
                Weeks.Add(new week());
                for (int i=1;i<= Days; i++)
                {
                    dateTime = new DateTime(your, MANTH, i, 0, 0, 0);
                    
                }
            }

            
        }

    }
}
