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
    public partial class ActualizarDelViso : Form
    {
        private Proveedores_SQLSERVER dbConnect;

        public ActualizarDelViso()
        {
            InitializeComponent();
            dbConnect = new Proveedores_SQLSERVER();

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {

            DataTable datos;
            OpenFileDialog ExcelDialog = new OpenFileDialog();
            //            ExcelDialog.Filter = "Excel Files (*.xlsx) | *.xlsx";
            ExcelDialog.InitialDirectory = @"C:\U.
sers\billyko\Downloads";
            ExcelDialog.Title = "Elegir archivo";
            if (ExcelDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                MyExcelDelviso.DB_PATH = ExcelDialog.FileName;

                txtPathFile.Text = ExcelDialog.FileName;
                txtPathFile.ReadOnly = true;
                btnCargar.Enabled = false;
                MyExcelDelviso.InitializeExcel();
                datos = MyExcelDelviso.ReadMyExcel_DataTable();
                dgFal.DataSource = datos;
                dbConnect.InsertarPreciosBulk(datos, progressBar1, "DelvisoExcel");

            }



        }
        }
}
