using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab3
{
    public class Class1
    {
        public static double vvod(TextBox t)
        {
            return Convert.ToDouble(t.Text);
        }
        public static double S(double a, double R)
        {
            return Math.PI * R * R * a / 360;
        }
        public static void Plosh(double R1, double R2, double R3, double a, double b, double c, ref double S_a, ref double S_a1, ref double S_a2, ref double S_b, ref double S_b1, ref double S_b2, ref double S_c, ref double S_c1, ref double S_c2)
        {
            S_a = S(a, R1);
            S_a1 = S(b, R1);
            S_a2 = S(c, R1);
            S_b = S(a, R2);
            S_b1 = S(b, R2);
            S_b2 = S(c, R2);
            S_c = S(a, R3);
            S_c1 = S(b, R3);
            S_c2 = S(c, R3);
        }

        public static void Plosh1(double R1, double R2, double R3, double a, double b, double c, out double S_a, out double S_a1, out double S_a2, out double S_b, out double S_b1, out double S_b2, out double S_c, out double S_c1, out double S_c2)
        {

            S_a = S(a, R1);
            S_a1 = S(b, R1);
            S_a2 = S(c, R1);
            S_b = S(a, R2);
            S_b1 = S(b, R2);
            S_b2 = S(c, R2);
            S_c = S(a, R3);
            S_c1 = S(b, R3);
            S_c2 = S(c, R3);
        }
        public static void vivod(ListBox t, double rez, string l)
        {
            string str = string.Format("{0}= {1}", l, rez);
            t.Items.Add(str);
        }
        public static void clear(ListBox t)
        {
            t.Items.Clear();
        }
        public static void output(Form t)
        {
            Application.OpenForms[0].Show();
            t.Hide();
        }
        public static void back()
        {
            Application.Exit();
        }
        public static void key_presst(KeyPressEventArgs e, TextBox t1, TextBox b)
        {
            if (!Char.IsDigit(e.KeyChar) && !(Char.IsControl(e.KeyChar)))
            {
                if (!(e.KeyChar.ToString() == "," && t1.Text.IndexOf(",") == -1) && !(e.KeyChar.ToString() == "-"))
                    e.Handled = true;
            }
            if (e.KeyChar.Equals((char)13))
                b.Focus();
        }
        public static void key_pressbutton(KeyPressEventArgs e, TextBox t1, Button b)
        {
            if (!Char.IsDigit(e.KeyChar) && !(Char.IsControl(e.KeyChar)))
            {
                if (!(e.KeyChar.ToString() == "," && t1.Text.IndexOf(",") == -1) && !(e.KeyChar.ToString() == "-"))
                    e.Handled = true;
            }
            if (e.KeyChar.Equals((char)13))
                b.Focus();
        }
    }
}
