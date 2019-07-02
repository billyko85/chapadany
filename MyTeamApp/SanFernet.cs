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
    public partial class SanFernet : Form
    {
        private const string sanFernet = "San Fernet";
        private int codProvSanFernet;
        private DBMySQL dbMysql;


        public SanFernet()
        {
            InitializeComponent();

            dbMysql = new DBMySQL();

            codProvSanFernet = dbMysql.leerCodProv(sanFernet);

        }



        private void button1_Click(object sender, EventArgs e)
        {
            int codVersion = dbMysql.InsertVersion(DateTime.Today.ToString(), DateTime.Today, sanFernet);

            dbMysql.InsertArticulos(gridOtero, bar, codProvSanFernet, false);

        }

        private void Otero_Load(object sender, EventArgs e)
        {

            dbMysql.cargarArticulosSanFernet(gridOtero);

            labUltimaVersionActualizada.Text = dbMysql.leerUltimaVersionActualizada(sanFernet);

      //      nro_Version_Actualizada = dbMysql.leerVersionID(otero);


        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int codVersion = dbMysql.InsertVersion(DateTime.Today.ToString(), DateTime.Today, sanFernet);

            dbMysql.InsertArticulos(gridOtero, bar, codProvSanFernet, true);
        }
    }
}
