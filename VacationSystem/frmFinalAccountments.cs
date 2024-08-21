using DocumentFormat.OpenXml.Wordprocessing;
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
    public partial class frmFinalAccountments : Form
    {
        public frmFinalAccountments()
        {
            InitializeComponent();
        }

        private async void frmTeacherList_Load(object sender, EventArgs e)
        {
           
            dgv.DataSource = await clsFinalAccounts.GetAll();

            if (dgv.RowCount > 0)
            {
                dgv.Columns[0].HeaderText = "التسلسل";
                dgv.Columns[1].Width = 250;
                dgv.Columns[1].HeaderText = "الاسم";
                dgv.Columns[2].Width = 200;
                dgv.Columns[2].HeaderText = "العنوان الوظيفي";
                dgv.Columns[3].Width = 100;
                dgv.Columns[3].HeaderText = "الدرجة الوظيفية";
                dgv.Columns[4].HeaderText = "عدد ايام الحضور";
                dgv.Columns[5].HeaderText = " عدد الساعات الكلي";
                dgv.Columns[6].HeaderText = "مبلغ الساعة الواحدة";
                dgv.Columns[7].HeaderText = "المبلغ الكلي للساعات";
                dgv.Columns[8].HeaderText = "مبلغ الطعام لليوم الواحد";
                dgv.Columns[9].HeaderText = "المبلغ الكلي للطعام";
                dgv.Columns[10].HeaderText = "المبلغ المستحق للموظف";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
