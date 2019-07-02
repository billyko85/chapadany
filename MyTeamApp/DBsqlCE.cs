using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
//Add MySql Library
using System.Data.SqlServerCe;

namespace MyTeamApp
{
    class DBsqlCE
    {
        private SqlCeConnection connection;
        private string connectionString = "Data Source=C:\\Cromosol\\Neox SLA\\SLA.sdf; Password ='adminxx'";
        private const char Cromosol = '1';
        private const char BBA = '2';
        private bool openConnection = false;
        private SqlCeResultSet resultSet;

        public DBsqlCE()
        {
            Initialize();
        }

        private void Initialize()
        {
            connection = new SqlCeConnection(connectionString);
        }

        private bool OpenConnection()
        {
            if (openConnection == true)
                return true;

            try
            {
                connection.Open();
                openConnection = true;
                return true;
            }

            catch (SqlCeException ex)
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
                openConnection = false;
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
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        public string leerUltimaVersionLista()
        {
            string version;
            try
            {
                this.OpenConnection();

                SqlCeCommand cmd = connection.CreateCommand();

                cmd.CommandText = "select Valor from SystemParameters where Codigo = 'SLAX_ULTIMA_ACTUALIZACION';";
                version = (string)cmd.ExecuteScalar();

                this.CloseConnection();

                return version;
            }

            catch (SqlCeException ex)

            {
                MessageBox.Show(ex.Message);
                this.CloseConnection();
            }

            return null;

        }


        public DataTable cargarDataTable(string tabla)
        {
            string query;

            query = "select * from " + tabla;

            try
            {
                this.OpenConnection();
                SqlCeCommand cmd = connection.CreateCommand();

                cmd.CommandText = query;
                resultSet = cmd.ExecuteResultSet(ResultSetOptions.Scrollable);
                return ResultSetToDataTable(resultSet);

                //               this.CloseConnection();
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message);
                this.CloseConnection();
                return null;
            }


        }

        public DataTable ResultSetToDataTable(SqlCeResultSet set)
        {
            DataTable dt = new DataTable();

            // copy columns
            for (int col = 0; col < set.FieldCount; col++)
            {
                dt.Columns.Add(set.GetName(col), set.GetFieldType(col));
            }

            // copy data
            while (set.Read())
            {
                DataRow row = dt.NewRow();
                for (int col = 0; col < set.FieldCount; col++)
                {
                    int ordinal = set.GetOrdinal(set.GetName(col));
                    row[col] = set.GetValue(ordinal);
                }
                dt.Rows.Add(row);
            }

            return dt;
        }

        public void cargarTablas(System.Windows.Forms.DataGridView grid, string tabla, string proveedor, int row_index)
        {
            string query;
           
            query = "select * from " + tabla;
            grid.DataSource = null;
            grid.Rows.Clear();

            try
            {
                this.OpenConnection();
                SqlCeCommand cmd = connection.CreateCommand();
                
                cmd.CommandText = query;
                resultSet = cmd.ExecuteResultSet(ResultSetOptions.Scrollable);
                grid.DataSource = resultSet;

 //               this.CloseConnection();
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message);
                this.CloseConnection();
            }

        }


    }

}