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

        private Proveedores_SQLSERVER dbConnect;


        public Rpm()
        {
            InitializeComponent();
            dbConnect = new Proveedores_SQLSERVER();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBAccess db1 = new DBAccess();
            DataTable datos = null;

            OpenFileDialog ExcelDialog = new OpenFileDialog();
            //            ExcelDialog.Filter = "Excel Files (*.xlsx) | *.xlsx";
            ExcelDialog.InitialDirectory = @"C:\Users\billyko\Downloads";
            ExcelDialog.Title = "Elegir archivo";
            if (ExcelDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFileName.Text = ExcelDialog.FileName;
                txtFileName.ReadOnly = true;
                txtFileName.Click -= button1_Click;
                button1.Enabled = false;

                datos = db1.cargarTablaRPM(ExcelDialog.FileName);

                dbConnect.InsertarPreciosBulk(datos, progressBar1, "Rpm");

                dataGridView1.DataSource = datos;


            }
        }

        private void Rpm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'baseRPM2DataSet.proveedo' Puede moverla o quitarla según sea necesario.
            this.proveedoTableAdapter.Fill(this.baseRPM2DataSet.proveedo);

        }
    }
}
