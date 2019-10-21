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
    public partial class Dam : Form
    {
        public Dam()
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

                Dam_SQLSERVER sql = new Dam_SQLSERVER();

                //sql.InsertarPreciosBulk(dt, barCastelar);
                sql.InsertarPreciosBulk(dt, barCastelar);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
