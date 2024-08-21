using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VacationSystemLogic;

namespace VacationSystem
{
    public partial class frmOverTime : Form
    {
        public frmOverTime()
        {
            InitializeComponent();
        }

        private string _GetEmployeeName()
        {
            return dgv.CurrentRow.Cells[1].Value.ToString();
        }
        private async void frmOverTime_Load(object sender, EventArgs e)
        {
            dgv.DataSource = await clsOverTime.GetMonthlyOverTime();

            if (dgv.Rows.Count > 0)
            {
                dgv.Columns[0].HeaderText = "ت";
                dgv.Columns[1].Width = 250;
                dgv.Columns[1].HeaderText = "الاسم الثلاثي";
                dgv.Columns[2].Width = 200;
                dgv.Columns[2].HeaderText = "العنوان الوظيفي";
                dgv.Columns[dgv.ColumnCount - 1].Width = 80;
                dgv.Columns[dgv.ColumnCount - 1].HeaderText = "المجموع";
            }

        }

        private void txtHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            
            short.TryParse(txtHours.Text, out short Hours);

           short MonthNumber =  (short)DateTime.Now.Month;

            byte DayNumber = 0;
            switch (cmbDay.Text)
            {
                case "الاحد":
                    DayNumber = 1;
                    break;
                case "الاثنين":
                    DayNumber = 2;
                    break;
                case "الثلاثاء":
                    DayNumber = 3;
                    break;
                case "الاربعاء":
                    DayNumber = 4;
                    break;
                case "الخميس":
                    DayNumber = 5;
                    break;
                case "الجمعة":
                    DayNumber = 6;
                    break;
                case "السبت":
                    DayNumber = 7;
                    break;
            }

            bool? Update = await Task.Run(() => clsOverTime.UpdateNumberOfHoursPerDay(Hours, DayNumber, MonthNumber));

            if (Update.Value)
            {
                MessageBox.Show($" تم تحديث بيانات يوم " + cmbDay.Text + " من شهر " + MonthNumber ,"",MessageBoxButtons.OK,MessageBoxIcon.Information);
                frmOverTime_Load(null,null);
            }
            else
            {
                MessageBox.Show("فشل");
            }
        }

        private void btnShowInWord_Click(object sender, EventArgs e)
        {
            string selectedFilePath = null;
            openFileDialog1.Filter = "Word Documents (*.doc;*.docx)|*.doc;*.docx|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                selectedFilePath = openFileDialog1.FileName;
                // ...
            }

            if (selectedFilePath != null)
            {
                clsUpdateWordTable.UpdateTableInWord(selectedFilePath, dgv);
            }

        }

        private async void FillDefaultData_Click(object sender, EventArgs e)
        {
            bool? IsDataExist = await clsOverTime.IsDataExist();

            if (IsDataExist.Value)
            {
                MessageBox.Show("تم ملىء بيانات هذا الشهر مسبقا وسيتم اضافة بيانات افتراضية كل يوم جديد خلال الشهر الحالي ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool? Filldata = await clsOverTime.FilldefaultData();

            if (Filldata.HasValue)
            {
                MessageBox.Show("تمت اضافة البيانات بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmOverTime_Load(null, null);
            }
            else
            {
                MessageBox.Show("خطا لم تتم اضافة البيانات", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private async void btnFillDataForOneEmployee_Click(object sender, EventArgs e)
        {
            int EmployeeID = clsEmployee.Find(_GetEmployeeName()).EmployeeId.Value;


            bool? IsDataExist = await clsOverTime.IsDataExist(EmployeeID);

            if (IsDataExist.Value)
            {
                MessageBox.Show("تم ملىء بيانات هذا الشهر مسبقا وسيتم اضافة بيانات افتراضية كل يوم جديد خلال الشهر الحالي ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool? Filldata = await clsOverTime.FilldefaultData(EmployeeID);

            if (Filldata.HasValue)
            {
                MessageBox.Show("تمت اضافة البيانات بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmOverTime_Load(null, null);
            }
            else
            {
                MessageBox.Show("خطا لم تتم اضافة البيانات", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
