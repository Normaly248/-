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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        Form23 f = new Form23();
        private void button1_Click(object sender, EventArgs e)
        {
            voprdll.Class1.vopros3(radioButton1, radioButton2, radioButton3, radioButton4, f, this);
                
            
        }
    }
}