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
    public partial class Faros_Fal : Form
    {
        private Proveedores_SQLSERVER dbConnect;

        public Faros_Fal()
        {
            InitializeComponent();
            dbConnect = new Proveedores_SQLSERVER();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ExcelDialog = new OpenFileDialog();
            //            ExcelDialog.Filter = "Excel Files (*.xlsx) | *.xlsx";
            ExcelDialog.InitialDirectory = @"C:\Users\billyko\Downloads";
            ExcelDialog.Title = "Elegir archivo";
            if (ExcelDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MyExcelFal.DB_PATH = ExcelDialog.FileName;
                txtPathFile.Text = ExcelDialog.FileName;
                txtPathFile.ReadOnly = true;
                btnCargar.Enabled = false;
                MyExcelFal.InitializeExcel();
                dgFal.DataSource = MyExcelFal.ReadMyExcel_DataTable();

                dbConnect.InsertarPreciosBulk(MyExcelFal.ReadMyExcel_DataTable(),progressBar1, "FarosFal");
            }
        }
    }
}
