using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyTeamApp
{
    public partial class CargasVentas : Form
    {
        private DBMySQL dbmysql;

        public CargasVentas()
        {
            InitializeComponent();
        }

        private void textBusqueda_KeyDown(object sender, KeyEventArgs e)
        {


            //string query = "  SELECT RpmArticulo.arterc, RpmArticulo.ardesc, RpmFamilias.fadesc, " +
            //               "RpmRubros.rbdesc FROM RpmArticulo,RpmFamilias,RpmRubros WHERE RpmArticulo.arflia = RpmFamilias.facodi and " +
            //               "RpmArticulo.arrub2 = RpmRubros.rbcodi AND arterc LIKE '%LCA-394%'"; 


            //if (e.KeyCode == Keys.Enter)
            //{

            //    dbmysql.cargarGrid(dataGridBusqueda, query, "RpmArticulo");

            //    dbmysql.

            //    //enter key is down
            //}




        }

        private void textBusqueda_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
