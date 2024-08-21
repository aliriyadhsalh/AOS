using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VacationSystem;
using VacationSystemLogic;

namespace VacationSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


        private void CreatEmployeeButton()
        {
            Button btnEmployee = new Button();
            btnEmployee.Text = "الموظفين";
            btnEmployee.Font = new System.Drawing.Font("Cairo",10,FontStyle.Regular);
            btnEmployee.BackColor = System.Drawing.Color.White;
            btnEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnEmployee.Image = Properties.Resources.administrator;
            btnEmployee.ImageAlign = ContentAlignment.MiddleRight;
            btnEmployee.Size = new Size(180,57) ;
            btnEmployee.Location = new Point(151,160);
            btnEmployee.Click += btnEmployee_Click;
            splitContainer1.Panel2.Controls.Add(btnEmployee);
        }

        private void CreatOverTimeButton()
        {
            Button btnDaliyAttend = new Button();
            btnDaliyAttend.Text = "الساعات الاضافية";
            btnDaliyAttend.Font = new System.Drawing.Font("Cairo", 10, FontStyle.Regular);
            btnDaliyAttend.BackColor = System.Drawing.Color.White;
            btnDaliyAttend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnDaliyAttend.Image = Properties.Resources.paste;
            btnDaliyAttend.ImageAlign = ContentAlignment.MiddleRight;
            btnDaliyAttend.Size = new Size(180, 57);
            btnDaliyAttend.Location = new Point(151,230);
            btnDaliyAttend.Click += btnOverTimeList_Click;
            splitContainer1.Panel2.Controls.Add(btnDaliyAttend);

        }

        private void CreatFoodList()
        {
            Button btnMonthlyAttend = new Button();
            btnMonthlyAttend.Text = "سجل الاطعام";
            btnMonthlyAttend.Font = new System.Drawing.Font("Cairo", 10, FontStyle.Regular);
            btnMonthlyAttend.BackColor = System.Drawing.Color.White;
            btnMonthlyAttend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnMonthlyAttend.Image = Properties.Resources.paste;
            btnMonthlyAttend.ImageAlign = ContentAlignment.MiddleRight;
            btnMonthlyAttend.Size = new Size(180, 57);
            btnMonthlyAttend.Location = new Point(151, 300);
            btnMonthlyAttend.Click += btnListFood_Click;
            splitContainer1.Panel2.Controls.Add(btnMonthlyAttend);

        }


        private void CreateFinalMonthlyAccountsList()
        {
            Button btnMonthlyAttend = new Button();
            btnMonthlyAttend.Text = "المحصلة الشهرية";
            btnMonthlyAttend.Font = new System.Drawing.Font("Cairo", 10, FontStyle.Regular);
            btnMonthlyAttend.BackColor = System.Drawing.Color.White;
            btnMonthlyAttend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnMonthlyAttend.Image = Properties.Resources.wallet;
            btnMonthlyAttend.ImageAlign = ContentAlignment.MiddleRight;
            btnMonthlyAttend.Size = new Size(180, 57);
            btnMonthlyAttend.Location = new Point(151, 370);
            btnMonthlyAttend.Click += btnFinalAccounts_Click;
            splitContainer1.Panel2.Controls.Add(btnMonthlyAttend);

        }




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LogIn()
        {
            clsUser user = clsUser.FindByUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if (user != null)
            {

                if (chkRememberMe.Checked)
                {
                    //store username and password
                    clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

                }
                else
                {
                    //store empty username and password
                    clsGlobal.RememberUsernameAndPassword("", "");

                }

                //incase the user is not active
                if (!user.IsActive)
                {

                    txtUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobal.CurrentUser = user;


                btnLogin.Visible = false;
                txtUserName.Visible = false;
                txtPassword.Visible = false;
                chkRememberMe.Visible = false;
                lblPassWord.Visible = false;
                lblUsername.Visible = false;

                CreatEmployeeButton();
                CreatOverTimeButton();
                CreatFoodList();
                CreateFinalMonthlyAccountsList();

                lblTiltle.Text = "تم تسجيل الدخول بنجاح";
                lblTiltle.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0); 


            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
                _LogIn();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;

        }

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            Form frm = new frmEmployees();
            frm.ShowDialog();
        }

        private void btnOverTimeList_Click(object sender, EventArgs e)
        {
            Form frm = new frmOverTime();
            frm.ShowDialog();
        }

        private void btnListFood_Click(object sender, EventArgs e)
        {
            Form form = new frmMonthlyAttendance();
            form.ShowDialog();
        }

        private void btnFinalAccounts_Click(object sender, EventArgs e)
        {
            Form frmFinalAccounts = new frmFinalAccountments();
            frmFinalAccounts.ShowDialog();
        }
    }
}
