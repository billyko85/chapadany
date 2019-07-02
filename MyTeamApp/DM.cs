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
    public partial class DM : Form
    {
        private DBsqlite dbsqlite;
        private Dm_SQL_SERVER dbMysql;
        private int codProvDM;
        public const string productos = "productos";
        public const string empresas = "empresas";
        public const string productos_tipo = "productos_tipo";
 
        public const string proveedor = "DM";

        
        public DM()
        {
            InitializeComponent();

            dbsqlite = new DBsqlite();
            dbMysql = new Dm_SQL_SERVER();

            codProvDM = dbMysql.leerCodProv("DM");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //labUltimaVersionLista.Text = dbsqlite.leerVersionDM();
            //dbsqlite.cargarTabla(dataGridDM, comboTablas.SelectedItem.ToString());
        }

        private void DM_Load(object sender, EventArgs e)
        {
        }

        private void btnInsertarArt_Click(object sender, EventArgs e)
        {
            DataTable tabla = null;

            tabla = dbsqlite.cargarTabla(empresas);
            dbMysql.InsertarDmEmpresasTrans(tabla, EmpresaBar);

            tabla.Clear();

            tabla =  dbsqlite.cargarTabla( productos_tipo);
            dbMysql.InsertarDmProductos_TipoTrans(tabla, Productos_tipo_Bar);

            tabla.Clear();

            tabla = dbsqlite.cargarTabla(productos);
            dbMysql.InsertarDmArticulosBulk(tabla, productos_Bar);

        }

        private void labUltimaVersionActualizada_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}