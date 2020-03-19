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
    public partial class CargasInicial : Form
    {
        private DBMySQL dbmysql;
        private DBAccess dbAccess;
        public const string productos = "productos";

        public const int c_DelViso  = 1;
        public const int c_Cromosol = 2;
        public const int c_BBA = 3;
        public const int c_DM = 4;
        public const int c_Otero = 5;


        class ComboItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public ComboItem(string text, object value)
            {
                Text = text; Value = value;
            }
            public override string ToString()
            {
                return Text;
            }
        }    
        
            public CargasInicial()
        {
            InitializeComponent();

            dbmysql = new DBMySQL();
            dbAccess = new DBAccess();

            //            codProvDM = dbMysql.leerCodProv("DM");
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() { return Text; }
        }

        private void btnInsertarArt_Click(object sender, EventArgs e)
        {
            //dbAccess.cargarTabla(dataGridVB, txtCodProd.Text, txtMDB.Text);
        }

        private void CargasInicial_Load(object sender, EventArgs e)
        {
            comboProveedores.Items.Add(new ComboItem("DelViso", c_DelViso));
            comboProveedores.Items.Add(new ComboItem("Cromosol",c_Cromosol));
            comboProveedores.Items.Add(new ComboItem("BBA",c_BBA));
            comboProveedores.Items.Add(new ComboItem("DM",c_DM));
            comboProveedores.Items.Add(new ComboItem("Otero", c_Otero));

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboboxItem item = (ComboboxItem)comboProveedores.SelectedItem;
            ComboItem item = (ComboItem)comboProveedores.SelectedItem;

            switch ((int)item.Value) {            
            case c_DelViso:
                    dbmysql.cargarTablaListaProveedores(dataGridProveedores, "SELECT ListasProveedores.descrip, ListasProveedores.auto,ListasProveedores.codProv, ListasProveedores.codProv2, " +
  "ListasPreciosProveedores.precio1 FROM ListasProveedores, ListasPreciosProveedores " +
  "WHERE ListasProveedores.idProv = 1 AND ListasProveedores.idProv = ListasPreciosProveedores.idProv AND ListasProveedores.codProv = ListasPreciosProveedores.codProv " +
"AND MATCH(ListasProveedores.descrip)AGAINST('" + dataGridVB.Rows[0].Cells[2].Value.ToString() + "') > 0 " +
"AND ListasProveedores.auto IN(sELECT auto FROM ListasProveedores WHERE ListasProveedores.idProv = 1 " +
"AND MATCH(ListasProveedores.auto) AGAINST('" + dataGridVB.Rows[0].Cells[0].Value.ToString() + "') > 0 GROUP By ListasProveedores.auto)");

                    break;
            }
            

        }

        private void dataGridProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


            //DatagridProveedores. ;

            dbmysql.InsertarComprasDelViso(dataGridVB, cromosolBar,c_DelViso, dataGridProveedores.SelectedCells);
        }

        private void cromosolBar_Click(object sender, EventArgs e)
        {

        }
    }
}