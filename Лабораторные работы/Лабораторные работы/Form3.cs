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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Class1.clear(listBox1);
            double a = Class1.vvod(textBox1);
            double b = Class1.vvod(textBox2);
            double x = Class1.vvod(textBox3);
            double y1 = Class1.vary(a,b,x);
            double r1 = Class1.varr(a, b,x);
            string y = "y";
            string r = "r";
            Class1.vivod(listBox1, y1, y);
            Class1.vivod(listBox1, r1, r);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Class1.output(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1.back();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Class1.key_presst(e, textBox1, textBox2);
        }

        private void textBox2_TextChanged(object sender, KeyPressEventArgs e)
        {
            Class1.key_pressbutton(e, textBox2, button2);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      
    }
}
