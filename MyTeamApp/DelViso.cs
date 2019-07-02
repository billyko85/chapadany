using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyTeamApp;

using System.Data.SqlServerCe;

namespace MyTeamApp
{
    public partial class DelViso : Form
    {
        private DBMySQL dbConnect;
        const string vacio = "VACIO";

        public DelViso()
        {
            InitializeComponent();
            tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);
            dbConnect = new DBMySQL();

            lab_nro_version.Text = dbConnect.leerVersionNombre("DelViso").ToString();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs args)
        {
            TabPage current = (sender as TabControl).SelectedTab;

            if (string.IsNullOrEmpty(MyExcel.DB_PATH))
            {
                MessageBox.Show(" Please provide the team excel file ..", "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                args.Cancel = true;
            }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
            TabControl tc = sender as TabControl;
            if (tc.SelectedIndex == 1)
            {
                dataGridEmpList.DataSource = (BindingList<Lista>)MyExcel.EmpList;
                dataGridEmpList.AutoResizeColumns();
            }
            
        }


       
        protected  override void OnFormClosing(System.Windows.Forms.FormClosingEventArgs e)
        {
            if(!string.IsNullOrEmpty(MyExcel.DB_PATH))
            MyExcel.CloseExcel();
        }

        

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
       
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog ExcelDialog = new OpenFileDialog();
            //            ExcelDialog.Filter = "Excel Files (*.xlsx) | *.xlsx";
            ExcelDialog.InitialDirectory = @"C:\Users\billyko\Desktop\ChapaDany\ExcelUsingCSharp_demo\MyTeamApp";
            ExcelDialog.Title = "Select your team excel";
            if (ExcelDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MyExcel.DB_PATH = ExcelDialog.FileName;
                txtFileName.Text = ExcelDialog.FileName;
                txtFileName.ReadOnly = true;
                txtFileName.Click -= btnLoad_Click;
                tabControl1.Selecting -= tabControl1_Selecting;
                btnLoad.Enabled = false;
                MyExcel.InitializeExcel();
                dataGridEmpList.DataSource = MyExcel.ReadMyExcel();
            }

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

            dbConnect.InsertMassive(this.dataGridEmpList, this.progressBar1, "DelViso", Convert.ToInt32(in_rowIndex.Value));

        }

        private void btnInsertarVersion_Click(object sender, EventArgs e)
        {

            if (txtVersion.Text.Length > 0)
            {
                dbConnect.InsertVersion(txtVersion.Text, dateVersion.Value, "DelViso");
            }

        }

        private void dateVersion_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
