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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        public int a; 
        private void button1_Click(object sender, EventArgs e)
        {
            a = voprdll.Class1
                .rezball(0);
            if (a == 0 || a >= 5)
                textBox1.Text = "Вы набрали " + a.ToString() + " баллов" + "\r\n";
            else if (a == 1)
                textBox1.Text += "Вы набрали " + a.ToString() + " балл" + "\r\n";
            else if (a >= 2 && a <= 4)
                textBox1.Text = "Вы набрали " + a.ToString() + " балла" + "\r\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lab_5.Class1.back();
        }

        
    }
}
