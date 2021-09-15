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
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }
        Form12 f = new Form12();
        private void button1_Click(object sender, EventArgs e)
        {
            voprdll.Class1.vopros1("масличные", textBox2, f, this);
        }
    }
}
