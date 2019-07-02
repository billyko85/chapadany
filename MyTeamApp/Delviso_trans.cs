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
    public partial class DelVisoTrans : Form
    {
        private const string DelViso = "DelViso";
        private int codProvDelViso;
        private DBMySQL dbMysql;


        public DelVisoTrans()
        {
            InitializeComponent();

            dbMysql = new DBMySQL();

            codProvDelViso = dbMysql.leerCodProv("DelViso");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int codVersion = dbMysql.InsertVersion(DateTime.Today.ToString(), DateTime.Today, DelViso);

            dbMysql.InsertArticulos(gridOtero, bar, codProvDelViso, false);

        }

        private void Otero_Load(object sender, EventArgs e)
        {

            dbMysql.cargarArticulosDelVisoTrans(gridOtero);

            labUltimaVersionActualizada.Text = dbMysql.leerUltimaVersionActualizada(DelViso);

      //      nro_Version_Actualizada = dbMysql.leerVersionID(otero);


        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int codVersion = dbMysql.InsertVersion(DateTime.Today.ToString(), DateTime.Today, DelViso);

            dbMysql.InsertArticulos(gridOtero, bar, codProvDelViso, true);
        }
    }
}
