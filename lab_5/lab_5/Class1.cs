using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;

namespace lab_5
{
    public class Class1
    {
        public static double vvod(TextBox t)
        {
            return Convert.ToDouble(t.Text);
        }
        public static void back()
        {
            Application.Exit();
        }
        public static void outputt(Form t)
        {
            Application.OpenForms[0].Show();
            t.Hide();
        }
        public static void vivod(string viv, string result, string otvet, Form t, Form _this)
        {
            DialogResult result1 = MessageBox.Show(viv + " " + result + " " + otvet, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result1 == DialogResult.OK)
            {
                _this.Hide();
                t.ShowDialog();
            }
        }
        static int ball;
        public static int rezball(int a)
        {
            ball = ball + a;
            return ball;
        }
    }
}
