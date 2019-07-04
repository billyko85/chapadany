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
    public partial class Otero : Form
    {
        private const string otero = "Otero";
        private int codProvOtero;
        private DBMySQL dbMysql;


        public Otero()
        {
            InitializeComponent();

            dbMysql = new DBMySQL();

            codProvOtero = dbMysql.leerCodProv("Otero");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int codVersion = dbMysql.InsertVersion(DateTime.Today.ToString(), DateTime.Today, otero);



        }

        private void Otero_Load(object sender, EventArgs e)
        {

            dbMysql.cargarArticulosOtero(gridOtero);

            labUltimaVersionActualizada.Text = dbMysql.leerUltimaVersionActualizada(otero);

      //      nro_Version_Actualizada = dbMysql.leerVersionID(otero);


        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int codVersion = dbMysql.InsertVersion(DateTime.Today.ToString(), DateTime.Today, otero);

            dbMysql.InsertArticulos(gridOtero, bar, codProvOtero, true);
        }
    }
}
