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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        Form8 f = new Form8();
        private void button1_Click(object sender, EventArgs e)
        {
            voprdll.Class1.vopros1("разновидность", textBox1, f, this);
                
        }
    }
}
