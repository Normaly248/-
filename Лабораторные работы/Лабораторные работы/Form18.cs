using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Лабораторные_работы
{
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }
        Form19 f = new Form19();
        public static int year = 0;
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            year = (hScrollBar1.Value * 1) +10;
            textBox4.Text = "Ваш ответ: " + Convert.ToString(year);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            voprdll.Class1.vopros5(year, 27, f, this);
        }

        

        
    }
}
