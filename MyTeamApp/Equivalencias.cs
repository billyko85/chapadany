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
    public partial class Equivalencias : Form
    {
        private DBMySQL dbMysql;

        public Equivalencias()
        {
            InitializeComponent();

            dbMysql = new DBMySQL();

            dbMysql.cargarComboBox(comboProveedores);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbMysql.cargarArticulosProveedor(dataGrid ,comboProveedores);
        }

        private void Equivalencias_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
           
        }
    }
}
