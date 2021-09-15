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
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }
        Form22 f = new Form22();
        private void button1_Click(object sender, EventArgs e)
        {
            voprdll.Class1.vopros6(checkedListBox2, f, this);
        }
    }
}
