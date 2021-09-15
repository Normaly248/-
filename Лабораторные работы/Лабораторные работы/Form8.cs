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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        Form9 f = new Form9();
        private void button1_Click(object sender, EventArgs e)
        {
            voprdll.Class1.vopros2(checkBox1, checkBox2, checkBox3, checkBox4, f, this);
            
                
            
        }
    }
}
