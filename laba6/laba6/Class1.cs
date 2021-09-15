using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;

namespace laba6
{
    public class Class1
    {
        public static void enter_mass(int n, params int[] masPtr)
        {
            Random a = new Random();
            for (int i = 0; i < n; i++)
            {
                masPtr[i] = (int)(a.Next() % 900) / 20 - 20;
            }
        }

        public static void out_mas(int len, DataGridView grid, params int[] aPtz)
        {
            grid.ColumnCount = len;
            grid.RowCount = 2;
            for (int i = 0; i < len; i++)
            {
                grid.Rows[0].Cells[i].Value = "[" + i + "]";
                grid.Rows[1].Cells[i].Value = aPtz[i];
            }
            int Width = 0;
            for (int j = 0; j < grid.ColumnCount; j++)
            {
                Width += grid.Columns[j].Width;
            }
            if (Width > 1200)
                grid.Width = 1200;
            else
                grid.Width = Width;
        }
        public static int rezsumm(int[] masPtr)
        {
            int i = 0;
            for (int j = 0; j < masPtr.Length; j++)
            {
                if (masPtr[j] % 2 != 0)
                    i = i+1;
            }
            return i;
        }
        public static int count_mas(double s, int[] masPtr)
            {
                int j = 0;
                for (int i = 0; i < masPtr.Length; i++)
                    {
                        if (masPtr[i] > s)
                                  j++;  

                    }
                return j;
            }
        public static void vivod(double a, TextBox t)
        {
            t.Text = Convert.ToString(a);
        }
        

        public static void set_mas(double s, int[] masPtr, params int[] rezmasPtr)
        {
            int j = 0;
            for (int i = 0; i < masPtr.Length; i++)     
            {
                if (masPtr[i] > s)
                {
                    rezmasPtr[j] = masPtr[i];
                    j++;
                }

            }
        }
    }
}
