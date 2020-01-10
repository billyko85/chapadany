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
                ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + archivo + " ; Persist Security Info=False");
            

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


        public void cargarTabla(System.Windows.Forms.DataGridView grid, string codProd, string archivo)
        {
            string sql = "SELECT productos.auto, productos.marca, productos.Descrip,  marprov.Marca, compras.codart, compras.Cantidad, "+
                "controlcompras.Fecha, provedores.nombre, productos.ventas, productos.stock " +
"FROM(((compras LEFT JOIN productos ON compras.codart = productos.codProd) " +
"LEFT JOIN marprov ON productos.MarProd = marprov.Codigo) " +
"LEFT JOIN controlcompras ON compras.codcompra = controlcompras.codcompra) " +
"LEFT JOIN provedores ON controlcompras.codprov = provedores.codprov " +
"WHERE(((productos.CodProd) = ";


            OpenConnection(archivo);

            OleDbDataAdapter adap = new OleDbDataAdapter ( sql + codProd + "))", connection);
            

            DataSet dsDatos = new DataSet();
            adap.Fill(dsDatos,"compras");

            grid.DataSource = dsDatos.Tables["compras"];

            CloseConnection();

        }


      

    }

}
