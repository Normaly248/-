using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Лабораторные_работы
{
    class Class1
    {
        public static int k = 0;
        public static double vary(double a, double b, double x)
{
    double y = (Math.Pow(a, 2 * x) + Math.Pow(b, -x) * (Math.Cos(a + b) * x)) / (x + 1);
return y;
}
public static double varr(double a, double b, double x)
{
    double r = Math.Sqrt(x * x + b) - Math.Pow(b * b * Math.Sin(x + a) / x, 3);
return r;
}

public static double vvod(TextBox t)
{
return Convert.ToDouble(t.Text);
}
public static void Vivod(TextBox S, double result)
{
    S.Text = Convert.ToString(result);
}
public static void vivod(ListBox t, double rez, string l)
{
string str = string.Format("{0}= {1}",l, rez);
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
    