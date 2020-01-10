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
    public partial class Rpm : Form
    {



        public Rpm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBAccess db1 = new DBAccess();

            OpenFileDialog ExcelDialog = new OpenFileDialog();
            //            ExcelDialog.Filter = "Excel Files (*.xlsx) | *.xlsx";
            ExcelDialog.InitialDirectory = @"C:\Users\billyko\Downloads";
            ExcelDialog.Title = "Elegir archivo";
            if (ExcelDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MyExcelDmApp.DB_PATH = ExcelDialog.FileName;
                txtFileName.Text = ExcelDialog.FileName;
                txtFileName.ReadOnly = true;
                txtFileName.Click -= button1_Click;
                button1.Enabled = false;
                MyExcelDmApp.InitializeExcel();

                //db1.OpenConnection(archivo);


                //dataGridEmpList.DataSource = MyExcelDmApp.ReadMyExcel();

                //dbConnect.InsertarDmArticulosAppBulk(MyExcelDmApp.ReadMyExcel_DataTable(), Bar);
            }
        }
    }
}
