using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace MyTeamApp
{
    public partial class FrmCromosol : Form
    {
        public const string Fabricantes = "Marca";
        public const string Rubro = "Rubro";
        public const string ArticuloRubro = "ArticuloRubro";
        public const string VehiculosArticulos = "VehiculoArticulo";
        public const string VehiculoMarca = "VehiculoMarca";
        public const string VehiculoModelo = "VehiculoModelo";
        public const string Articulo = "Articulo";
        public const string Equivalentes = "Equivalentes";
        public const string Empresa = "Empresa";

        public int nro_Version_Actualizada = -1;
        public int nro_Version_Lista = -1;

        private DBsqlCE dbsqlCe;
        private Cromosol_SQLSERVER dbCromosol;
    
        public FrmCromosol()
        {
            InitializeComponent();
            //dbMysql = new DBMySQL();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dbsqlCe = new DBsqlCE();

            dbCromosol = new Cromosol_SQLSERVER();


        }
                    

        private void button1_Click_1(object sender, EventArgs e)
        {

            DataTable datos = null;

            if (this.checkEmpresas.Checked) { 
                datos = dbsqlCe.cargarDataTable(Empresa);
                //dbCromosol.InsertarEmpresa(datos, cromosolBar);
                dbCromosol.InsertarEmpresaBulk(datos, cromosolBar);
                datos.Dispose();
            }

            if (this.checkArticuloRubro.Checked) { 
                datos = dbsqlCe.cargarDataTable(ArticuloRubro);
                dbCromosol.InsertarArticuloRubroTrans(datos, pbArticuloRubro);
                datos.Dispose();
            }

            if (this.checkMarcas.Checked) { 
                datos = dbsqlCe.cargarDataTable(VehiculoMarca);
                dbCromosol.InsertarMarcas(datos, pbMarcas);
                datos.Dispose();
            }

            if (this.checkVehiculoModelo.Checked) { 
                datos = dbsqlCe.cargarDataTable(VehiculoModelo);
                dbCromosol.InsertarModelosBulk(datos, pbVehiculoModelo);
                datos.Dispose();
            }

            if (this.checkRubro.Checked) { 
                datos = dbsqlCe.cargarDataTable(Rubro);
                dbCromosol.InsertarRubrosTrans(datos, pbRubro);
                datos.Dispose();
            }

            if (this.checkMarcas.Checked)
            {
                datos = dbsqlCe.cargarDataTable(Fabricantes);
                dbCromosol.InsertarMarcasTrans(datos, pbFabricantes);
                datos.Dispose();
            }

            if (this.checkArticulos.Checked) { 
                datos = dbsqlCe.cargarDataTable(Articulo);
                dbCromosol.InsertarArticulosBulk(datos, pbArticulos);
                //dbCromosol.InsertarArticulosTrans(datos, pbArticulos);
                datos.Dispose();
            }

            if (this.checkVehiculosArticulos.Checked) { 
                datos = dbsqlCe.cargarDataTable(VehiculosArticulos);
                dbCromosol.InsertarVehiculosArticulosBulk(datos, pbVehiculoArticulos);
                //dbCromosol.InsertarVehiculosArticulos(datos, pbVehiculoArticulos);
                datos.Dispose();
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
