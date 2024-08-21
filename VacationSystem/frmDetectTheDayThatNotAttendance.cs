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
    public partial class frmDetectTheDayThatNotAttendance : Form
    {
        public frmDetectTheDayThatNotAttendance()
        {
            InitializeComponent();
        }
        private int? EmployeeID = null;
        public frmDetectTheDayThatNotAttendance(int EmployeeID)
        {
            InitializeComponent();
            this.EmployeeID = EmployeeID;
        }


        private async void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (EmployeeID != null)
            {
                byte AttendStatus = 0;
                bool? UpdateNumberOfHours = null;
                if (rdbAttend.Checked)
                { AttendStatus = 1;

                  UpdateNumberOfHours = await clsOverTime.UpdateHoursBasedAttendance(EmployeeID.Value, dtDateFrom.Value, dtDateTo.Value);
                }
                else
                { AttendStatus = 0;

                    UpdateNumberOfHours = await clsOverTime.setZerohourWhenEmployeeNitAttend(EmployeeID.Value, dtDateFrom.Value, dtDateTo.Value);
                }

                bool? UpdateAttendance = await clsAttendance.UpdateAttendStatus(EmployeeID.Value, dtDateFrom.Value,dtDateTo.Value,AttendStatus);

                if (UpdateAttendance.Value && UpdateNumberOfHours.Value)
                {
                    MessageBox.Show("تم التحديث بنجاح","تحديث",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("حدث خطا ما لم تتم الاضافة", "عدم حضور ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("حدث خطا ما لم يتم تحديد العنصر بشكل صحيح ", "عدم حضور ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
