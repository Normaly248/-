﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Лабораторные_работы
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }
        Form17 f = new Form17();
        public static int prozent = 0;
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
             prozent= (trackBar1.Value * 10);
             textBox3.Text = "Ваш ответ: " + Convert.ToString(prozent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            voprdll.Class1.vopros5(prozent, 80, f, this);
        }

        
        
    }
}
