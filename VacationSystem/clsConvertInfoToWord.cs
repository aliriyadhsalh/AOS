
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

internal class clsUpdateWordTable
{
    public static void UpdateTableInWord(string filePath, DataGridView dataGridView)
    {
        try
        {
            // تحقق من أن الملف غير مقفل
            if (IsFileLocked(filePath))
            {
                MessageBox.Show("الملف قيد الاستخدام من قبل عملية أخرى. يرجى إغلاق أي تطبيقات أخرى قد تكون تستخدم الملف.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // تحقق من وجود الملف
            if (!File.Exists(filePath))
            {
                MessageBox.Show("الملف المحدد لا يوجد في المسار المحدد.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // فتح المستند
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(filePath, true))
            {
                MainDocumentPart mainPart = wordDocument.MainDocumentPart;
                if (mainPart == null)
                {
                    MessageBox.Show("المستند لا يحتوي على جزء رئيسي.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // العثور على أول جدول في المستند
                Table table = mainPart.Document.Body.Elements<Table>().FirstOrDefault();
                if (table == null)
                {
                    MessageBox.Show("لم يتم العثور على جدول في المستند.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // تحويل DataGridView إلى DataTable
                DataTable dataTable = DataGridViewToDataTable(dataGridView);

                // تحديث الجدول
                UpdateTable(table, dataTable);

                // حفظ التغييرات
                mainPart.Document.Save();
            }

            MessageBox.Show("تم تحديث الملف بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (IOException ioEx)
        {
            MessageBox.Show("حدث خطأ أثناء محاولة الوصول إلى الملف: " + ioEx.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("حدث خطأ غير متوقع: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static DataTable DataGridViewToDataTable(DataGridView dgv)
    {
        DataTable dataTable = new DataTable();

        // إضافة الأعمدة إلى DataTable
        foreach (DataGridViewColumn column in dgv.Columns)
        {
            dataTable.Columns.Add(column.HeaderText);
        }

        // إضافة الصفوف إلى DataTable
        foreach (DataGridViewRow row in dgv.Rows)
        {
            if (!row.IsNewRow)
            {
                DataRow dataRow = dataTable.NewRow();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dataRow[i] = row.Cells[i].Value?.ToString() ?? string.Empty;
                }
                dataTable.Rows.Add(dataRow);
            }
        }

        return dataTable;
    }

    private static void UpdateTable(Table table, DataTable dataTable)
    {
        // مسح الصفوف الحالية (تجاوز صف الرأس إذا كان موجوداً)
        foreach (var row in table.Elements<TableRow>().Skip(1).ToList())
        {
            row.Remove();
        }

        // إضافة الصفوف الجديدة من DataTable
        foreach (DataRow dataRow in dataTable.Rows)
        {
            TableRow tableRow = new TableRow();
            foreach (var item in dataRow.ItemArray)
            {
                TableCell cell = new TableCell(new Paragraph(new Run(new Text(item.ToString()))));

                // تعيين اتجاه النص إلى اليمين إلى اليسار
                ParagraphProperties paragraphProperties = new ParagraphProperties(
                    new BiDi { Val = OnOffValue.FromBoolean(true) });
                cell.Elements<Paragraph>().FirstOrDefault().ParagraphProperties = paragraphProperties;

                tableRow.AppendChild(cell);
            }
            table.AppendChild(tableRow);
        }
    }

    private static bool IsFileLocked(string filePath)
    {
        try
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                return false;
            }
        }
        catch (IOException)
        {
            return true;
        }
    }

    }


