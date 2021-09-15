using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using laba6;
using dll;

namespace Лабораторные_работы
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }
        public int l;
        private void button1_Click(object sender, EventArgs e)
        {
            String g = Interaction.InputBox("Введите количество элементов массива", "Введите значение");
            int a = Convert.ToInt32(g);
            int[] massPtr = new int[a];
            laba6.Class1.enter_mass(a, massPtr);
            laba6.Class1.out_mas(a, dataGridView1, massPtr);
            int rez = laba6.Class1.rezsumm(massPtr);
            laba6.Class1.vivod(rez, textBox1);
            int k = laba6.Class1.count_mas(rez, massPtr);
            int[] massrez = new int[k];
            laba6.Class1.set_mas(k, massPtr, massrez);  
            laba6.Class1.out_mas(k, dataGridView2, massrez);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] massPtr = new int[dataGridView1.ColumnCount];
            int[] rezmas = new int[dataGridView2.ColumnCount];
            massPtr = dll.Class1.funk1(dataGridView1);
            rezmas = dll.Class1.funk1(dataGridView2);
            string Name = Interaction.InputBox("Введите название базы данных");
            string fullName = dll.Class1.funk2() + "\\" + Name;
            dll.Class1.add(fullName);
            dll.Class1.add_structdouble(fullName);
            dll.Class1.add_zap_double(fullName, massPtr, rezmas, l);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int [] massPtr = new int[dataGridView1.ColumnCount];
            int [] rezmas = new int[dataGridView2.ColumnCount];
            massPtr = dll.Class1.funk1(dataGridView1);
            rezmas = dll.Class1.funk1(dataGridView2);
            dll.Class1.ZapisBloknot("Исходный массив", massPtr);
            dll.Class1.ZapisBloknot("Результат", rezmas);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[] massPtr = new int[dataGridView1.ColumnCount];
            int[] rezmas = new int[dataGridView2.ColumnCount];
            massPtr = dll.Class1.funk1(dataGridView1);
            rezmas = dll.Class1.funk1(dataGridView2);
            dll.Class1.add_pdf(rezmas, massPtr);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int[] massPtr = new int[dataGridView1.ColumnCount];
            int[] rezmas = new int[dataGridView2.ColumnCount];
            massPtr = dll.Class1.funk1(dataGridView1);
            rezmas = dll.Class1.funk1(dataGridView2);
            dll.Class1.ZapisWordIsx(massPtr, rezmas);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int[] massPtr = new int[dataGridView1.ColumnCount];
            int[] rezmas = new int[dataGridView2.ColumnCount];
            massPtr = dll.Class1.funk1(dataGridView1);
            rezmas = dll.Class1.funk1(dataGridView2);
            OpenFileDialog otkr = new OpenFileDialog();
            otkr.DefaultExt = "*.xlsm;*.xlsx";
            otkr.Filter = "Microsoft Excel (*.xlsm*)|*.xls*";
            otkr.Title = "выберите документ";
            if (otkr.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dll.Class1.ZapisExcelmac(otkr.FileName, rezmas, massPtr);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int[] massPtr = new int[dataGridView1.ColumnCount];
            int[] rezmas = new int[dataGridView2.ColumnCount];
            massPtr = dll.Class1.funk1(dataGridView1);
            rezmas = dll.Class1.funk1(dataGridView2);
            dll.Class1.ZapisExcel(rezmas, massPtr);
        }

        
    }
}
