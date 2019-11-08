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
    public partial class EdyLuz : Form
    {
        public EdyLuz()
        {
            InitializeComponent();
        }

        private void btnLoadDBF_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "dBASE files (*.dbf)|*.dbf";
            ofd.ShowDialog();

            if (ofd.FileName.Length > 0)
            {
                DataTable dt = ReadDbf.ReadDBF(ofd.FileName);
                grdDBF.DataSource = dt;

                Proveedores_SQLSERVER sql = new Proveedores_SQLSERVER();

                sql.InsertarPreciosBulk(dt, barCastelar, "EdyLuz");
            }
           }
    }
}
