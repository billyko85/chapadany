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
    public partial class DerEncendido : Form
    {
        public DerEncendido()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "dBASE files (*.dbf)|*.dbf";
            ofd.ShowDialog();

            if (ofd.FileName.Length > 0)
            {
                DataTable dt = ReadDbf.ReadDBF(ofd.FileName);
                grdDBF.DataSource = dt;

                Proveedores_SQLSERVER sql = new Proveedores_SQLSERVER();

                //sql.InsertarPreciosBulk(dt, barCastelar, "DerArticulos");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path.GetDirectoryName(fileName) + ";Extended Properties=dBASE IV;User ID=;Password=;");
            //try
            //{
            //    if (con.State == ConnectionState.Closed) { con.Open(); }
            //    OleDbDataAdapter da = new OleDbDataAdapter("select * from " + Path.GetFileName(fileName), con);
            //    DataSet ds = new DataSet();
            //    da.Fill(ds);
            //    con.Close();
            //    int i = ds.Tables[0].Rows.Count;
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }
    }
}
