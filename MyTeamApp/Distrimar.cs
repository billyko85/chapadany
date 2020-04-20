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
    public partial class Distrimar : Form
    {
        private Distrimar_SQLSERVER dbConnect;
        const string vacio = "VACIO";

        public Distrimar()
        {
            InitializeComponent();
            tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);
            dbConnect = new Distrimar_SQLSERVER();

            //lab_nro_version.Text = dbConnect.leerVersionNombre("DelViso").ToString();
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
            ExcelDialog.InitialDirectory = @"C:\Users\billyko\Downloads";
            ExcelDialog.Title = "Elegir archivo";
            if (ExcelDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MyExcelDistrimar.DB_PATH = ExcelDialog.FileName;
                txtFileName.Text = ExcelDialog.FileName;
                txtFileName.ReadOnly = true;
                txtFileName.Click -= btnLoad_Click;
                tabControl1.Selecting -= tabControl1_Selecting;
                btnLoad.Enabled = false;
                MyExcelDistrimar.InitializeExcel();

                dataGridEmpList.DataSource = MyExcelDistrimar.ReadMyExcel();
            }

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

            dbConnect.Bulk_Insert(dataGridEmpList, Bar);

        }

        private void btnInsertarVersion_Click(object sender, EventArgs e)
        {

            if (txtVersion.Text.Length > 0)
            {
                //dbConnect.InsertVersion(txtVersion.Text, dateVersion.Value, "DelViso");
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

        private void in_rowIndex_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
