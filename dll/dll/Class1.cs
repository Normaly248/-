using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace dll
{
    public class Class1
    {

        public static int[] funk1(DataGridView DGV)
        {
            int[] mas = new int[DGV.ColumnCount];
            for (int i = 0; i < DGV.ColumnCount; i++)
            {
                mas[i] = (int)DGV.Rows[1].Cells[i].Value;
            }
            return mas;
        }
        public static string funk2()
        {
            return Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        }

        public static void add(string fullName)
        {
            string m = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + fullName + ".mbd;";
            var k = new ADOX.Catalog();
            try
            {
                k.Create(m);
                MessageBox.Show("БД Успешно создана");

            }
            catch (System.Runtime.InteropServices.COMException sit)
            {
                MessageBox.Show(sit.Message);
            }
            finally
            {
                k = null;
            }

        }
        public static void add_structdouble(string fullName)
        {
            var p = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + fullName + ".mbd;");
            p.Open();
            var c = new OleDbCommand("CREATE TABLE [MASSIVS]([Номер элемента] counter, [Исходный массив] char(200), [Результирующий массив] char(200))", p);
            try
            {
                c.ExecuteNonQuery();
                MessageBox.Show("Структура базы данных записана");

            }
            catch (Exception situation)
            {
                var clear = new OleDbCommand("DELETE FROM [MASSIVS]", p);
                clear.ExecuteNonQuery();
                MessageBox.Show(situation.Message);
            }
            p.Close();
        }
        public static void add_zap_double(string fullName, int[] mas, int[] rezmas, int j)
        {

            for (int i = 0; i < mas.Length; i++)
            {
                var p = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullName + ".mbd;");
                p.Open();
                if (i < j)
                {
                    var c = new OleDbCommand("INSERT INTO [MASSIVS](" + " [Исходный массив],[Результирующий массив]) VALUES('" + mas[i] + "', '" + rezmas[i] + "')");
                    c.Connection = p;
                    c.ExecuteNonQuery();
                }
                else
                {
                    var c = new OleDbCommand("INSERT INTO [MASSIVS](" + " [Исходный массив],[Результирующий массив]) VALUES('" + mas[i] + "', ' ')");
                    c.Connection = p;
                    c.ExecuteNonQuery();
                }
                p.Close();
            }
            MessageBox.Show("В таблице БД была добавлена запись", "Информация", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        public static void add_pdf(int[] rezmas, params int[] mas)
        {
            var Document = new Document();
            var Zap = PdfWriter.GetInstance(Document, new System.IO.FileStream("Massivs.pdf", System.IO.FileMode.Create));
            Document.Open();
            var Shift = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\times.ttf", "CP1251", BaseFont.EMBEDDED);
            var ft = new Font(Shift, 12, Font.NORMAL, BaseColor.BLACK);
            PdfPTable tabl = new PdfPTable(2);
            var cell = new PdfPCell();
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Colspan = 2;
            cell.Border = 0;
            cell.FixedHeight = 16.0F;
            cell.Phrase = new Phrase("Одномерные массивы", ft);
            tabl.AddCell(cell);
            cell.BackgroundColor = BaseColor.WHITE;
            cell.Colspan = 1;
            cell.Border = 15;
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.Phrase = new Phrase("Исходный массив", ft);
            tabl.AddCell(cell);
            cell.Phrase = new Phrase("Результирующий массив", ft);
            tabl.AddCell(cell);
            int a = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            for (int i = 0; i < mas.Length; i++)
            {
                cell.Phrase = new Phrase(mas[i].ToString(), ft);
                tabl.AddCell(cell);
                if (rezmas.Length > a)
                {
                    cell.Phrase = new Phrase(rezmas[i].ToString(), ft);
                    tabl.AddCell(cell);
                    a++;
                }
                else
                {
                    cell.Phrase = new Phrase("", ft);
                    tabl.AddCell(cell);
                }
            }
            tabl.TotalWidth = Document.PageSize.Width - 200;
            tabl.WriteSelectedRows(0, -1, 40, Document.PageSize.Height - 30, Zap.DirectContent);
            Document.Close();
            Zap.Close();
            System.Diagnostics.Process.Start("IExplore.exe", System.IO.Directory.GetCurrentDirectory() + @"\Massivs.pdf");
        }

        public static void ZapisBloknot(string fullname, params int[] mas)
        {

            StreamWriter rez = File.CreateText(fullname + ".txt");
            for (int i = 0; i < mas.Length; i++)
            {
                rez.WriteLine(String.Format("{0}", mas[i]));
            }
            rez.Dispose();
            System.Diagnostics.Process.Start(fullname + ".txt");
        }

        public static void ZapisWordIsx(int[] mas, params int[] masrez)
        {

            object start = 0;
            object end = 0;
            var Wrd = new Microsoft.Office.Interop.Word.Application();
            Wrd.Visible = true;
            var inf = Type.Missing;
            String str;
            var Doc = Wrd.Documents.Add(inf, inf, inf, inf);
            Microsoft.Office.Interop.Word.Range tableLocation = Doc.Range(ref start, ref end);
            object oMissing = System.Reflection.Missing.Value;
            Doc.Paragraphs.Add(ref oMissing);
            Doc.Paragraphs.Add(ref oMissing);
            Doc.Paragraphs.Add(ref oMissing);
            Doc.Paragraphs.Add(ref oMissing);
            Doc.Paragraphs.Add(ref oMissing);
            Wrd.Selection.TypeText("Исходный массив");
            Microsoft.Office.Interop.Word.Paragraph wordparagraph = Doc.Paragraphs[4];
            wordparagraph.Range.Text = "результирующий массив";
            wordparagraph = Doc.Paragraphs[2];
            tableLocation = wordparagraph.Range;
            Object t1 = Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            Object t2 = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
            Microsoft.Office.Interop.Word.Table tbl = Wrd.ActiveDocument.Tables.Add(tableLocation, 2, mas.Length, t1, t2);
            for (int i = 0; i < mas.Length; i++)
            {
                tbl.Cell(1, i + 1).Range.InsertAfter("[" + Convert.ToString(i) + "]");
                str = String.Format("{0:0.##}", mas[i]);
                tbl.Cell(2, i + 1).Range.InsertAfter(str);
            }
            string str2;
            object unit;
            object extent;
            unit = Microsoft.Office.Interop.Word.WdUnits.wdStory;
            extent = Microsoft.Office.Interop.Word.WdMovementType.wdMove;
            Wrd.Selection.EndKey(ref unit, ref extent);
            Object a1 = Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            Object a2 = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
            Microsoft.Office.Interop.Word.Table tb2 = Wrd.ActiveDocument.Tables.Add(Wrd.Selection.Range, 2, masrez.Length, a1, a2);
            for (int i = 0; i < masrez.Length; i++)
            {
                tb2.Cell(1, i + 1).Range.InsertAfter("[" + Convert.ToString(i) + "]");
                str2 = String.Format("{0:0.##}", masrez[i]);
                tb2.Cell(2, i + 1).Range.InsertAfter(str2);
            }

        }

        public static void ZapisExcel(int[] masrez, params int[] mas)
        {
            int length = mas.Length;
            int lengthrez = masrez.Length;
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workBook;
            Microsoft.Office.Interop.Excel._Worksheet workSheel;
            workBook = excelApp.Workbooks.Add();
            workSheel = (Microsoft.Office.Interop.Excel._Worksheet)workBook.Worksheets.get_Item(1);
            workSheel.Name = "massiv";
            Microsoft.Office.Interop.Excel.Range range1 = workSheel.Range[workSheel.Cells[1, 1], workSheel.Cells[1, length]];
            range1.Merge(Type.Missing);

            range1.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            range1.Cells.Font.Name = "Times New Roman";
            range1.Cells.Font.Size = 18;
            range1.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            Microsoft.Office.Interop.Excel.Range range2 = workSheel.Range[workSheel.Cells[2, 1], workSheel.Cells[3, length]];
            range2.Cells.Columns.AutoFit();
            range2.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            range2.Cells.Font.Name = "Times New Roman";
            range2.Cells.Font.Size = 18;
            range2.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            range2.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            range2.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            range2.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            range2.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            workSheel.Range[("A4")].Select();
            workSheel.Cells[1, 1] = "Исходный массив";
            for (int i = 0; i < length; i++)
            {
                workSheel.Cells[2, i + 1] = "[" + i + "]";
                workSheel.Cells[3, i + 1] = mas[i];
            }

            Microsoft.Office.Interop.Excel.Range range3 = workSheel.Range[workSheel.Cells[5, 1], workSheel.Cells[5, lengthrez]];

            range3.Merge(Type.Missing);
            range3.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range3.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range3.Cells.Font.Name = "Times New Roman";
            range3.Cells.Font.Size = 18;
            range3.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            Microsoft.Office.Interop.Excel.Range range4 = workSheel.Range[workSheel.Cells[6, 1], workSheel.Cells[7, lengthrez]];
            range4.Cells.Columns.AutoFit();
            range4.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            range4.Cells.Font.Name = "Times New Roman";
            range4.Cells.Font.Size = 18;
            range4.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            range4.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            range4.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            range4.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            range4.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            workSheel.Range[("A4")].Select();
            workSheel.Cells[5, 1] = "Результирующий массив";
            for (int i = 0; i < lengthrez; i++)
            {
                workSheel.Cells[6, i + 1] = "[" + i + "]";
                workSheel.Cells[7, i + 1] = masrez[i];
            }
            excelApp.Visible = true;
            excelApp.UserControl = true;
        }
        public static void ZapisExcelmac(string filename, int[] masrez, params int[] mas)
        {
            int length = mas.Length;
            int lengthrez = masrez.Length;
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workBook;
            Microsoft.Office.Interop.Excel.Worksheet workSheel;
            workBook = excelApp.Workbooks.Open(filename);
            workSheel = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets.get_Item(1);
            workSheel.Name = "massiv";
            workSheel.Cells[1, 1] = "Исходный массив";
            for (int i = 0; i < length; i++)
            {
                workSheel.Cells[2, i + 1] = "[" + i + "]";
                workSheel.Cells[3, i + 1] = mas[i];
            }
            workSheel.Cells[5, 1] = "Результирующий массив";
            for (int i = 0; i < lengthrez; i++)
            {
                workSheel.Cells[6, i + 1] = "[" + i + "]";
                workSheel.Cells[7, i + 1] = masrez[i];
            }
            excelApp.Visible = true;
            excelApp.UserControl = true;
        }
    }
}
    
