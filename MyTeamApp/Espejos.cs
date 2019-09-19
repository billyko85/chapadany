using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTeamApp
{
    public partial class Espejos : Form
    {

        private espejosSqlServer dbConnect;


        public Espejos()
        {
            InitializeComponent();
            dbConnect = new espejosSqlServer();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ExcelDialog = new OpenFileDialog();
            //            ExcelDialog.Filter = "Excel Files (*.xlsx) | *.xlsx";
            ExcelDialog.InitialDirectory = @"C:\Users\billyko\Downloads";
            ExcelDialog.Title = "Elegir archivo";
            if (ExcelDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MyExcelDmApp.DB_PATH = ExcelDialog.FileName;
                txtFileName.Text = ExcelDialog.FileName;
                txtFileName.ReadOnly = true;
                txtFileName.Click -= btnLoad_Click;
                btnLoad.Enabled = false;
                MyExcelDmApp.InitializeExcel();
                //dataGridEmpList.DataSource = MyExcelDmApp.ReadMyExcel();
                dgEspejos.DataSource = MyExcelEspejos.ReadMyExcel_DataTable();
                //dbConnect.InsertarEspejosBulk(MyExcelEspejos.ReadMyExcel_DataTable());
            }
    }
}
