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
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }
        Form21 f = new Form21();
        private void button1_Click(object sender, EventArgs e)
        {
            voprdll.Class1.vopross7(checkedListBox2, f, this);
        }
    }
}
