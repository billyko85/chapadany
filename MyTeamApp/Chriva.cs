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
    public partial class Chriva : Form
    {
        private const string strChriva = "Chriva";
        private int codProvChriva;
        private DBMySQL dbMysql;


        public Chriva()
        {
            InitializeComponent();

            dbMysql = new DBMySQL();

            codProvChriva = dbMysql.leerCodProv(strChriva);

        }



        private void button1_Click(object sender, EventArgs e)
        {
            int codVersion = dbMysql.InsertVersion(DateTime.Today.ToString(), DateTime.Today, strChriva);

            //dbMysql.InsertArticulos(gridOtero, bar, codProvChriva, false);

        }

        private void Otero_Load(object sender, EventArgs e)
        {

            dbMysql.cargarArticulosChriva(gridOtero);

            labUltimaVersionActualizada.Text = dbMysql.leerUltimaVersionActualizada(strChriva);

      //      nro_Version_Actualizada = dbMysql.leerVersionID(otero);


        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int codVersion = dbMysql.InsertVersion(DateTime.Today.ToString(), DateTime.Today, strChriva);

            dbMysql.InsertArticulos(gridOtero, bar, codProvChriva, true);
        }
    }
}
