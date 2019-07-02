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
    public partial class farosDam : Form
    {
        private const string dam = "farosDam";
        private int codProvDam;
        private DBMySQL dbMysql;

        public farosDam()
        {
            InitializeComponent();

            dbMysql = new DBMySQL();

            codProvDam = dbMysql.leerCodProv(dam);


        }

        private void farosDam_Load(object sender, EventArgs e)
        {
            dbMysql.cargarArticulosfarosDam(gridDam);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            dbMysql.InsertArticulos(gridDam, bar, codProvDam, true);
        }
    }
}
