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
        }
      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
       
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "dBASE files (*.dbf)|*.dbf";
            ofd.ShowDialog();

            if (ofd.FileName.Length > 0)
            {
                DataTable dt = ReadDbf.ReadDBF(ofd.FileName);
                dataGridEmpList.DataSource = dt;

                Proveedores_SQLSERVER sql = new Proveedores_SQLSERVER();

                sql.InsertarPreciosBulk(dt, Bar, "DistrimarBDF");


            }

        }
    }
}
