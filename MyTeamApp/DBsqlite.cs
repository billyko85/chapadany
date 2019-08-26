using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace MyTeamApp
{
    class DBsqlite
    {
        private SQLiteConnection connection;


        public DBsqlite()
        {
            Initialize();
        }

        private void Initialize()
        {
            
        }

        private bool OpenConnection(string archivo)
        {
            
            connection = new SQLiteConnection("Data Source=C:\\dmcompras\\bin\\data\\db\\" + archivo);

            try
            {
                connection.Open();
                return true;
            }

            catch (SQLiteException ex)
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
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public DataTable cargarTabla(string tabla)
        {
            string query;
            DataTable grid = null;

            //switch (tabla)
            //{ 
            //    case "productos":
            //        query = "SELECT id,descripcion,codigo,precio,imagen,empresa,id_categoria,origen,pesado FROM " + tabla + " where pesado is null";
            //        break;

            //    case "precios":
            //        query = "SELECT id,precio from productos where pesado is null";
            //        break;

            //    default:
            //        return;
            //        break;
            //}

            query = "SELECT * from " + tabla;

            if (OpenConnection("DB_PRODUCTOS.dm"))
            { 
                try
                {
                    SQLiteCommand ObjCommand = new SQLiteCommand(query, connection);
                ObjCommand.CommandType = CommandType.Text;
                SQLiteDataAdapter ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
                DataSet dataSet = new DataSet();
                ObjDataAdapter.Fill(dataSet, tabla);
                grid = dataSet.Tables[tabla];
                }
                catch (SqlException sqlexc)
                {

                }
            }

            CloseConnection();

            return grid;
        }


        public string leerVersionDM()
        {
            return leerEscalar("select ultima_actualizacion from clientes limit 1", "DB_PEDIDOS.dm");
        }

        public string leerEscalar(string query, string archivo)
        {
            string escalar;

            if (OpenConnection(archivo))
            {
                SQLiteCommand ObjCommand = new SQLiteCommand(query, connection);
                ObjCommand.CommandType = CommandType.Text;

                escalar = (string)ObjCommand.ExecuteScalar();

                CloseConnection();

                return escalar;

            }

            return null;

        }

    }

}
