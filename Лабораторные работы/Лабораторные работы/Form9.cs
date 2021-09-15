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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        Form10 f = new Form10();
        private void button1_Click(object sender, EventArgs e)
        {
            voprdll.Class1.vopros2(checkBox1, checkBox3, checkBox2, checkBox4, f, this);   
        }
    }
}
