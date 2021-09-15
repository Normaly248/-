using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
namespace voprdll
{
    public class Class1
    {
        public static string vvod(TextBox t)
        {
            return Convert.ToString(t.Text);
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

        static int[] mas = new int[30];
        static string[,] mass = new string[30, 2];
        static string[,] mass1 = new string[30, 5];
        static int mm = 0;
        static int mm1 = 0;
        static int mm2 = 0;
        public static void nul()
        {
            mm = 0;
            mm1 = 0;
            mm2 = 0;
        }
        public static string[,] vopros(string rez, string rez1, string rez2, string rez3, string rez4)
        {
            mass1[mm, 0] = rez;
            mass1[mm, 1] = rez1;
            mass1[mm, 2] = rez2;
            mass1[mm, 3] = rez3;
            mass1[mm, 4] = rez4;
            mm++;
            return mass1;
        }
        public static int[] vivodrez(int bal)
        {
            mas[mm1] = bal;
            mm1++;
            return mas;
        }
        public static string[,] vivodrez1(string rez, string rez1)
        {
            mass[mm2, 0] = rez;
            mass[mm2, 1] = rez1;

            mm2++;
            return mass;
        }
        static int ball;
        public static int rezball(int a)
        {
            ball = ball + a;
            return ball;
        }

        public static void vopros1(string x, TextBox t, Form f, Form s)
        {
            string str;
            string otvet = voprdll.Class1.vvod(t);
            str = otvet.ToLower();
            if (x == str)
            {
              
                voprdll.Class1.rezball(1);
                voprdll.Class1.vivodrez(1);
                voprdll.Class1.vivodrez1(otvet, "");
                voprdll.Class1.vivod("Ответ ", otvet, " правильный", f, s);
            }
            else if (str == "")
            {
                DialogResult result = MessageBox.Show("Введите ответ", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
                voprdll.Class1.vivodrez(0);
                voprdll.Class1.vivodrez1(otvet, "");
                voprdll.Class1.vivod("Ответ", otvet, "не правильный", f, s);
            }
        }
        public static void vopros2(CheckBox checkBox1, CheckBox checkBox2, CheckBox checkBox3, CheckBox checkBox4,Form f, Form s)
        {

            if ((checkBox1.Checked) && (checkBox3.Checked))
            {
                
                voprdll.Class1.rezball(2);
                voprdll.Class1.vivodrez(2);
                voprdll.Class1.vivodrez1(checkBox1.Text, checkBox3.Text);
                voprdll.Class1.vivod("Ответы", "", "правильные", f, s);

            }
            else if ((!checkBox1.Checked) && (!checkBox3.Checked) && (!checkBox2.Checked) && (!checkBox4.Checked))
            {
                MessageBox.Show("ВЫ НЕ ОТВЕТИЛИ", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((!checkBox1.Checked) && (!checkBox3.Checked))
            {
                
                voprdll.Class1.vivodrez(0);
                voprdll.Class1.vivodrez1(checkBox2.Text, checkBox4.Text);
                voprdll.Class1.vivod("Ответы", "", "неправильный", f, s);
            }
            else if (((checkBox1.Checked) || (checkBox3.Checked)) && !((checkBox1.Checked) && (checkBox3.Checked)) && ((checkBox2.Checked) || (checkBox4.Checked)))
            {
                
                voprdll.Class1.rezball(1);
                voprdll.Class1.vivodrez(1);
                if (checkBox1.Checked && checkBox2.Checked)
                    voprdll.Class1.vivodrez1(checkBox1.Text, checkBox2.Text);
                else if (checkBox1.Checked && checkBox4.Checked)
                    voprdll.Class1.vivodrez1(checkBox1.Text, checkBox4.Text);
                else if (checkBox2.Checked && checkBox3.Checked)
                    voprdll.Class1.vivodrez1(checkBox2.Text, checkBox3.Text);
                else if (checkBox3.Checked && checkBox4.Checked)
                    voprdll.Class1.vivodrez1(checkBox3.Text, checkBox4.Text);
                voprdll.Class1.vivod("1", "", "правильный", f, s);
            }

            else
            {
                MessageBox.Show("Выберете 2 варианта ответа", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void vopros3(RadioButton radioButton1, RadioButton radioButton2, RadioButton radioButton3, RadioButton radioButton4,Form f, Form s)
        {
            if (!(radioButton1.Checked) && !(radioButton2.Checked) && !(radioButton3.Checked) && !(radioButton4.Checked))
            {
                MessageBox.Show("ВЫ НЕ ОТВЕТИЛИ", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
             

                if (radioButton1.Checked)
                {
                    voprdll.Class1.vivodrez(1);
                    voprdll.Class1.vivodrez1(radioButton1.Text, "");
                    voprdll.Class1.vivod("Ответ", "", "неправильный", f, s);
                }
                else if (radioButton2.Checked)
                {
                    voprdll.Class1.vivodrez(0);
                    voprdll.Class1.vivodrez1(radioButton2.Text, "");
                    voprdll.Class1.vivod("Ответ", "", "неправильный", f, s);
                }
                else if (radioButton3.Checked)
                {
                    voprdll.Class1.rezball(1);
                    voprdll.Class1.vivodrez(1);
                    voprdll.Class1.vivodrez1(radioButton3.Text, "");
                    voprdll.Class1.vivod("Ответ", "", "правильный", f, s);
                }
                else if (radioButton4.Checked)
                {

                    voprdll.Class1.vivodrez(0);
                    voprdll.Class1.vivodrez1(radioButton4.Text, "");
                    voprdll.Class1.vivod("Ответ", "", "неправильный", f, s);
                }
            }
        }

        public static void vopros4(ComboBox comboBox1, Form f, Form s, int rez)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("ВЫ НЕ ОТВЕТИЛИ", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
                if (comboBox1.SelectedIndex == rez)
                {
                    voprdll.Class1.rezball(1);
                    voprdll.Class1.vivodrez(1);
                    voprdll.Class1.vivodrez1(comboBox1.Text, "");
                    voprdll.Class1.vivod("Ответ", "", " правильный", f, s);
                }
                else
                {
                    voprdll.Class1.vivodrez(0);
                    voprdll.Class1.vivodrez1(comboBox1.Text, "");
                    voprdll.Class1.vivod("Ответ", "", " неправильный", f, s);
                }

            }
        }
        public static void vopros5(int prozent, int true_prozent, Form f, Form s)
        {
            if (prozent != 0)
            {
                if (prozent == true_prozent)
                {
                    
                    voprdll.Class1.rezball(1);
                    voprdll.Class1.vivodrez(1);
                    voprdll.Class1.vivodrez1(Convert.ToString(prozent), "");
                    voprdll.Class1.vivod("Ответ ", Convert.ToString(prozent), "правильный", f, s);
                }
                else
                {
              
                    voprdll.Class1.vivodrez(0);
                    voprdll.Class1.vivodrez1(Convert.ToString(prozent), "");
                    voprdll.Class1.vivod("Ответ ", Convert.ToString(prozent), "не правильный", f, s);
                }
            }
            else
            {
                MessageBox.Show("ВЫ НЕ ОТВЕТИЛИ", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static void vopros6(CheckedListBox checkedListBox1, Form f, Form s)
        {
            string otv1 = "";
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("ВЫ НЕ ОТВЕТИЛИ", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((checkedListBox1.CheckedIndices.Count == 3) && (checkedListBox1.CheckedIndices.Contains(0))
                && (checkedListBox1.CheckedIndices.Contains(1))
                && (checkedListBox1.CheckedIndices.Contains(4)))
            {
                otv1 = "1) Турция 2) Египет 5) Иран";
                voprdll.Class1.vivodrez(3);
                voprdll.Class1.rezball(3);
                voprdll.Class1.vivodrez1(otv1, "");
                voprdll.Class1.vivod("Ответ ", "", "правильный", f, s);
            }
            else
            {
                if (checkedListBox1.CheckedIndices.Contains(0))
                    otv1 += "1) Турция";
                if (checkedListBox1.CheckedIndices.Contains(1))
                    otv1 += " 2) Египет";
                if (checkedListBox1.CheckedIndices.Contains(2))
                    otv1 += " 3) Канада";
                if (checkedListBox1.CheckedIndices.Contains(3))
                    otv1 += " 4) США";
                if (checkedListBox1.CheckedIndices.Contains(4))
                    otv1 += " 5) Иран";
                if (checkedListBox1.CheckedIndices.Contains(5))
                    otv1 += " 6) Китай";
                voprdll.Class1.vivodrez(0);
                voprdll.Class1.vivodrez1(otv1, "");
                voprdll.Class1.vivod("Ответ ", "", "не правильный", f, s);
            }

        }
      
        public static void vopross7(CheckedListBox checkedListBox3, Form f, Form s)
        {
            string otv1 = "";
            if (checkedListBox3.CheckedItems.Count == 0)
            {
                MessageBox.Show("ВЫ НЕ ОТВЕТИЛИ", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((checkedListBox3.CheckedIndices.Count == 1) && (checkedListBox3.CheckedIndices.Contains(0)))
            {
                otv1 = "1)Крахмал";
                voprdll.Class1.vivodrez(1);
                voprdll.Class1.rezball(1);
                voprdll.Class1.vivodrez1(otv1, "");
                voprdll.Class1.vivod("Ответ ", "", "правильный", f, s);
            }
            else
            {
                if (checkedListBox3.CheckedIndices.Contains(0))
                    otv1 += "1) Крахмал";
                if (checkedListBox3.CheckedIndices.Contains(1))
                    otv1 += " 2) Мальтоза";
                if (checkedListBox3.CheckedIndices.Contains(2))
                    otv1 += " 3) Сахароза";
                voprdll.Class1.vivodrez(0);
                voprdll.Class1.vivodrez1(otv1, "");
                voprdll.Class1.vivod("Ответ ", "", "неправильный", f, s);
            }
        }

        
    }
}
