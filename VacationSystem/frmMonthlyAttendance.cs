using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VacationSystemLogic;
using System.IO;
namespace VacationSystem
{
    public partial class frmMonthlyAttendance : Form
    {
        public frmMonthlyAttendance()
        {
            InitializeComponent();
        }

        private string _GetEmployeeName()
        {
            return dgv.CurrentRow.Cells[1].Value.ToString();
        }

        private async void frmMonthlyAttendance_Load(object sender, EventArgs e)
        {
            dgv.DataSource = await clsAttendance.GetMonthlyAttendance();
            if (dgv.Rows.Count > 0)
            {
                dgv.Columns[0].HeaderText = "ت";
                dgv.Columns[1].Width = 250;
                dgv.Columns[1].HeaderText = "الاسم الثلاثي";
                dgv.Columns[2].Width = 200;
                dgv.Columns[2].HeaderText = "العنوان الوظيفي";
                dgv.Columns[dgv.ColumnCount - 1].Width = 80;
                dgv.Columns[dgv.ColumnCount - 1].HeaderText = "المجموع";
                lblRowCount.Text = dgv.Rows.Count.ToString();

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
                clsUpdateWordTable.UpdateTableInWord(selectedFilePath,dgv);
            }
        }

        private async void DetectDayThatNotAttendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int EmployeeID = clsEmployee.Find(_GetEmployeeName()).EmployeeId.Value;
            Form frm = new frmDetectTheDayThatNotAttendance(EmployeeID);
            frm.ShowDialog();
            frmMonthlyAttendance_Load(null,null);
        }

        private async void FillDefaultData_Click(object sender, EventArgs e)
        {
            bool? IsdataExist = await clsAttendance.IsDataExist();

            if (IsdataExist.Value)
            {
                MessageBox.Show("تم ملىء بيانات هذا الشهر مسبقا وسيتم اضافة بيانات افتراضية كل يوم جديد خلال الشهر الحالي ","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            bool? IsDone = await clsAttendance.FillDefaultData();

            if (IsDone.HasValue) {

                MessageBox.Show("تمت اضافة البيانات بنجاح","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                frmMonthlyAttendance_Load(null,null);
            }
            else
            {
                MessageBox.Show("خطا لم تتم اضافة البيانات","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private async void btnAddDataForOneEmployee_Click(object sender, EventArgs e)
        {
            int EmployeeID = clsEmployee.Find(_GetEmployeeName()).EmployeeId.Value;

            bool? IsdataExist = await clsAttendance.IsDataExist(EmployeeID);

            if (IsdataExist.Value)
            {
                MessageBox.Show("تم ملىء بيانات هذا الشهر مسبقا وسيتم اضافة بيانات افتراضية كل يوم جديد خلال الشهر الحالي ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool? IsDone = await clsAttendance.FillDefaultData(EmployeeID);

            if (IsDone.HasValue)
            {

                MessageBox.Show("تمت اضافة البيانات بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMonthlyAttendance_Load(null, null);
            }
            else
            {
                MessageBox.Show("خطا لم تتم اضافة البيانات", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

