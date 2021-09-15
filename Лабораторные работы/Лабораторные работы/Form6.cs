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
    public partial class Form6 : Form
    {

        public Form6()
        {
            
            InitializeComponent();
        }
        Form7 f = new Form7();
        private void button2_Click(object sender, EventArgs e)
        {
            voprdll.Class1.vopros1("сорт", textBox1, f, this);
        }
    }
    
}
