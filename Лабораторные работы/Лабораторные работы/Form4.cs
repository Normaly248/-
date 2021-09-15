using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using lab3;
using biblioteka;

namespace Лабораторные_работы
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lab3.Class1.back();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lab3.Class1.output(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double R1=0;
            double R2=0;
            double R3=0;
            double R4=0;
            double R5=0;
            double R6=0;
            double R7=0;
            double R8=0;
            double R9=0;
            double R11;
            double R22;
            double R33;
            double R44;
            double R55;
            double R66;
            double R77;
            double R88;
            double R99;
            double r1 = 0, r2 = 0, r3 = 0, a = 0, b = 0, c = 0;
            r1 = lab3.Class1.vvod(textBox1);
            r2 = lab3.Class1.vvod(textBox2);
            r3 = lab3.Class1.vvod(textBox3);
            a = lab3.Class1.vvod(textBox4);
            b = lab3.Class1.vvod(textBox5);
            c = lab3.Class1.vvod(textBox6);
            lab3.Class1.Plosh(r1, r2, r3, a, b, c, ref R1, ref R2, ref R3, ref R4, ref R5, ref R6, ref R7, ref R8, ref R9);
            lab3.Class1.Plosh1(r1, r2, r3, a, b, c, out R11, out R22, out R33, out R44, out R55, out R66, out R77, out R88, out R99);
            lab3.Class1.vivod(listBox1, R1, "S 1");
            lab3.Class1.vivod(listBox1, R2, "S 2");
            lab3.Class1.vivod(listBox1, R3, "S 3");
            lab3.Class1.vivod(listBox1, R4, "S 1");
            lab3.Class1.vivod(listBox1, R5, "S 2");
            lab3.Class1.vivod(listBox1, R6, "S 3");
            lab3.Class1.vivod(listBox1, R7, "S 1");
            lab3.Class1.vivod(listBox1, R8, "S 2");
            lab3.Class1.vivod(listBox1, R9, "S 3");

            lab3.Class1.vivod(listBox2, R11,"S 1");
            lab3.Class1.vivod(listBox2, R22, "S 2");
            lab3.Class1.vivod(listBox2, R33, "S 3");
            lab3.Class1.vivod(listBox2, R44, "S 1");
            lab3.Class1.vivod(listBox2, R55, "S 2");
            lab3.Class1.vivod(listBox2, R66, "S 3");
            lab3.Class1.vivod(listBox2, R77, "S 1");
            lab3.Class1.vivod(listBox2, R88, "S 2");
            lab3.Class1.vivod(listBox2, R99, "S 3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double x1 = 0, x2 = 0, x3 = 0, x4 = 0, x5 = 0;
            double y1 = 0, y2 = 0, y3 = 0, y4 = 0, y5 = 0;
            double sa = 0, sb = 0, sc = 0, plosh = 0;
            x1 = Classlib.vvod(textBox1);
            x2 = Classlib.vvod(textBox3);
            x3 = Classlib.vvod(textBox5);
            x4 = Classlib.vvod(textBox7);
            x5 = Classlib.vvod(textBox9);
            y1 = Classlib.vvod(textBox2);
            y2 = Classlib.vvod(textBox4);
            y3 = Classlib.vvod(textBox6);
            y4 = Classlib.vvod(textBox8);
            y5 = Classlib.vvod(textBox10);
            Classlib.obPlosh(x1, x2, x3, x4, x5, y1, y2, y3, y4, y5, ref sa, ref sb, ref sc);
            Classlib.obPlosh1(x1, x2, x3, x4, x5, y1, y2, y3, y4, y5, out sa, out sb, out sc);
            plosh = sa + sb + sc;
            Classlib.Vivod(textBox11, plosh);
            Classlib.Vivod(textBox12, plosh);
        }

        
        }
    }

