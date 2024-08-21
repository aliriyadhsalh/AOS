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
    public partial class frmAddEditEmployee : Form
    {
        private clsEmployee employee;

        public frmAddEditEmployee()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
            employee = new clsEmployee();
        }

        public frmAddEditEmployee(int Id)
        {
            InitializeComponent();
            Mode = enMode.Update;
            employee = clsEmployee.Find(Id);
        }

        enum enMode { AddNew =1 ,Update =2}
        enMode Mode = enMode.AddNew;


        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                employee.Name = txtEmployeeName.Text;
                employee.Position = txtposition.Text;
                employee.JobTitle = txbJobTitle.Text;
                employee.PriceForOneHour = Convert.ToSingle(txbPriceForOneHours.Text);
                employee.PriceForDailyMeal = Convert.ToSingle(txbpriceForOneMeal.Text);

                bool? Save = await employee.Save();

                if (Save.Value)
                {
                    MessageBox.Show("تم حفظ معلومات الموظف بنجاح","تم الحفظ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("يبدو ان هناك خطا في عملية الادخال","خطا",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtEmployeeName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeName.Text))
            {
                errorProvider1.SetError(txtEmployeeName, "ادخل اسم الوظف");
            }
        }

        private void txtposition_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtposition.Text))
            {

                errorProvider1.SetError(txtposition, "ادخل العنوان الوظيفي");
            }
        }

        private void frmAddEditEmployee_Load(object sender, EventArgs e)
        {
            if(Mode == enMode.Update)
            {
                txtEmployeeName.Text = employee.Name;
                txtposition.Text = employee.Position;
                txbJobTitle.Text = employee.JobTitle;
                txbPriceForOneHours.Text = employee.PriceForOneHour.ToString();
                txbpriceForOneMeal.Text = employee.PriceForDailyMeal.ToString();
            }
        }
    }
}
