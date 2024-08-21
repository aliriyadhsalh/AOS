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
    public partial class frmEmployees : Form
    {
        public frmEmployees()
        {
            InitializeComponent();
        }

        private int _GetEmployeeID()
        {
            return (int)dgv.CurrentRow.Cells[0].Value;
        }
        private async void frmEmployees_Load(object sender, EventArgs e)
        {
            dgv.DataSource = await Task.Run(()=>clsEmployee.GetEmployeeList());
            lblRowCount.Text = dgv.Rows.Count.ToString();

            if (dgv.RowCount >0)
            {
                dgv.Columns[0].HeaderText = "الرقم التعريفي";
                dgv.Columns[1].HeaderText = "الاسم";
                dgv.Columns[2].HeaderText = "العنوان الوظيفي";
                dgv.Columns[3].HeaderText = "الدرجة الوظيفية";
                dgv.Columns[4].HeaderText = "مبلغ الساعة الواحدة";
                dgv.Columns[5].HeaderText = "مبلغ الطعام لليوم الواحد";

            }
        }

        private void AddEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditEmployee();
            frm.ShowDialog();
            frmEmployees_Load(null,null);
        }

        private void EditEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditEmployee((int)dgv.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmEmployees_Load(null, null);

        }

        private async void DeleteEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متاكد من حذف هذا الموظف ؟","حذف",MessageBoxButtons.OK,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int EmployeeID = _GetEmployeeID();
                bool? IsDeleteAttendance = await clsAttendance.Delete(EmployeeID);
                bool?IsDeleteOverTime = await clsOverTime.Delete(EmployeeID);
                bool? IsDeleteEmployee = await clsEmployee.Delete((int)dgv.CurrentRow.Cells[0].Value);

                if (IsDeleteAttendance != null)
                {
                    if (IsDeleteOverTime != null)
                    {
                        if (IsDeleteEmployee != null)
                        {
                            MessageBox.Show("تم حذف الموظف بنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmEmployees_Load(null, null);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("حدث خطا لم يتم حذف الموظف","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditEmployee();
            frm.ShowDialog();
            frmEmployees_Load(null, null);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditEmployee((int)dgv.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmEmployees_Load(null, null);

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متاكد من حذف هذا الموظف ؟", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int EmployeeID = _GetEmployeeID();
                bool? IsDeleteAttendance = await clsAttendance.Delete(EmployeeID);
                bool? IsDeleteOverTime = await clsOverTime.Delete(EmployeeID);
                bool? IsDeleteEmployee = await clsEmployee.Delete((int)dgv.CurrentRow.Cells[0].Value);

                if (IsDeleteAttendance != null)
                {
                    if (IsDeleteOverTime != null)
                    {
                        if (IsDeleteEmployee != null)
                        {
                            MessageBox.Show("تم حذف الموظف بنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmEmployees_Load(null, null);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("حدث خطا لم يتم حذف الموظف", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
