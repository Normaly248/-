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
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
        }
        Form15 f = new Form15();
        private void button1_Click(object sender, EventArgs e)
        {
            voprdll.Class1.vopros4(comboBox1, f, this, 1);
        }
    }
}
