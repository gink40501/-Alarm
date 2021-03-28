using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 鬧鐘
{
    public partial class Form1 : Form
    {
        List<holiday> Holidays_1;
        
        public Form1(object x)
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            Holidays_1 = (List<holiday>)x;
            for(int i=0;i< Holidays_1.Count-1; i++)
                dataGridView1.Rows.Add();
            int j = 0;
            foreach (var i in Holidays_1)
            {
                dataGridView1.Rows[j].Cells[0].Value = i.Anniversary;
                dataGridView1.Rows[j].Cells[1].Value = i.datatime;
                dataGridView1.Rows[j].Cells[2].Value = i.day;
                dataGridView1.Rows[j].Cells[3].Value = i.annotation;
                j++;
            }
            
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
