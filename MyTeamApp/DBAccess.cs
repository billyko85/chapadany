using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace MyTeamApp
{
    class DBAccess      
    {
        private OleDbConnection connection; 

        public DBAccess()
        {
            Initialize();
        }

        private void Initialize()
        {
            
        }

        private bool OpenConnection(string archivo)
        {
            //C:\Users\billyko\Drive ChapaDany\Listas\db1.mdb

            connection = new OleDbConnection
                ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + archivo );
            

            try
            {
                connection.Open();
                return true;
            }

            catch (OleDbException ex)
            {
                switch (ex.ErrorCode)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }

        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        public DataTable cargarTablaRPM( string archivo){

            DataTable salida;
            string sql = "select arterc as codigo_proveedor, arcuar as codigo_prov2,RBDESC AS MARCA, " +
"armode as modelo, proveedo.prrazo as fabricante, familias.fadesc as categoria, ardesc as descripcion, " +
"armode as datos_extra  , aroo as precio from ((articulo  inner join rubros  on articulo.arrub2 = rubros.rbcodi) " +
"inner join familias on articulo.arflia = familias.facodi) inner join proveedo on proveedo.prcodi = articulo.arprov";


            OpenConnection(archivo);

            OleDbDataAdapter adap = new OleDbDataAdapter(sql, connection);


            DataSet dsDatos = new DataSet();
            adap.Fill(dsDatos);

            salida = dsDatos.Tables[0];

            CloseConnection();

            return salida;
        }

        public void cargarTabla(System.Windows.Forms.DataGridView grid, string codProd, string archivo)
        {
            string sql = "select arterc as codigo_proveedor, arcuar as codigo_prov2,RBDESC AS MARCA, " +
"armode as modelo, proveedo.prrazo as fabricante, familias.fadesc as categoria, ardesc as descripcion, " +
"armode as datos_extra  , aroo as precio from ((articulo  inner join rubros  on articulo.arrub2 = rubros.rbcodi) " +
"inner join familias on articulo.arflia = familias.facodi) inner join proveedo on proveedo.prcodi = articulo.arprov";


            OpenConnection(archivo);

            OleDbDataAdapter adap = new OleDbDataAdapter ( sql, connection);
            

            DataSet dsDatos = new DataSet();
            adap.Fill(dsDatos);

            grid.DataSource = dsDatos.Tables[0];

            CloseConnection();

        }


      

    }

}
