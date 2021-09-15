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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            this.Height = 0;
            this.Width = 0;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
             private void timer2_Tick(object sender, EventArgs e)
              {
                  if (Height < 1100)
                      Height = Height + 23;
                  else
                      timer2.Enabled = false;

              }
              private void timer1_Tick_1(object sender, EventArgs e)
              {
                  if (Width < 1940)
                      Width = Width + 40;
                  else
                      timer2.Enabled = false;

              }
      
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Hide();
            f.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            this.Hide();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            this.Hide();
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            this.Hide();
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form13 f = new Form13();
            this.Hide();
            f.ShowDialog();
        }
        

    
       
    }
}
