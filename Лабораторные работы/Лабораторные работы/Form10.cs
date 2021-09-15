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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        Form11 f = new Form11();
        private void button1_Click(object sender, EventArgs e)
        {
        voprdll.Class1.vopros3(radioButton1, radioButton3, radioButton2, radioButton4, f, this);
                
                               
            
        }
    }
}
