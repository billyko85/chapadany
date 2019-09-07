using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace MyTeamApp
{
    public class Dm_SQL_SERVER
    {

        public int codProv = -1;

        private string connectionString =
     "Data Source = chapadany.database.windows.net; Initial Catalog = chapadany_prueba1;" +
     " Integrated Security = False; User ID = daniel; Password=andenopA*1;" +
     "Connect Timeout = 60; Encrypt=False;TrustServerCertificate=False;" +
     "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


    

    public int leerCodProv(string proveedor)
    {
        if (this.codProv >= 0)
            return this.codProv;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand mycomand = new SqlCommand("SELECT CodProv FROM Proveedores WHERE nombre = '" + proveedor + "'", conn);
            SqlDataReader myreader = mycomand.ExecuteReader();

            myreader.Read();
            this.codProv = myreader.GetInt32(0);

            conn.Close();

            return this.codProv;

    }

        public void InsertarDmEmpresasTrans(DataTable dataGrid, ProgressBar bar)
        {

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            SqlTransaction t = conn.BeginTransaction(IsolationLevel.RepeatableRead);
            StringBuilder builder = new StringBuilder();

            command.Transaction = t;

            builder.Append(string.Format("truncate table DM_empresas; INSERT INTO DM_empresas(id, empresa, fecha_alta, fecha_modificacion) VALUES "));

            foreach (DataRow row in dataGrid.Rows)
            {

                builder.Append(string.Format(" ('{0}','{1}','{2}','{3}') ,",
                          row[0],
                          row[1].ToString(),
                          row[2].ToString(),
                          row[3].ToString()
                          ));

                bar.Increment(1);
            }
            //    
            command.CommandText = builder.ToString().Remove(builder.ToString().Length - 1);

            command.ExecuteNonQuery();
            t.Commit();

            conn.Close();

        }

        public void InsertarDmProductos_TipoTrans(DataTable dataGrid, ProgressBar bar)
        {

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            SqlTransaction t = conn.BeginTransaction(IsolationLevel.RepeatableRead);
            StringBuilder builder = new StringBuilder();

            command.Transaction = t;

            builder.Append(string.Format("truncate table DM_productos_tipo ; INSERT INTO DM_productos_tipo(id, tipo) VALUES "));

            foreach (DataRow row in dataGrid.Rows)
            {

                builder.Append(string.Format(" ({0},'{1}'),",
                              row[0],
                              row[1].ToString()
                          ));

                bar.Increment(1);
            }

            command.CommandText = builder.ToString().Remove(builder.ToString().Length - 1);
            command.ExecuteNonQuery();
            t.Commit();

            conn.Close();

        }


        public void InsertarDmArticulos(DataTable datatable, ProgressBar bar)
        {
            const int maxRows = 1000;
            int limite;

            bar.Minimum = 0;
            bar.Maximum = datatable.Rows.Count;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            for (int i = 0; i <= datatable.Rows.Count; i = i + maxRows)
            {

                SqlCommand command = conn.CreateCommand();
                SqlTransaction t = conn.BeginTransaction(IsolationLevel.RepeatableRead);
                StringBuilder builder = new StringBuilder();

                command.Transaction = t;

                builder.Append(string.Format("INSERT IGNORE INTO DM_productos(id, descripcion, codigo,precio,imagen,empresa,id_categoria,origen,stock,fecha_alta,fecha_modificacion,fotos,pesado) VALUES"));

                if (datatable.Rows.Count > i + maxRows)
                { limite = i + maxRows; }
                else
                { limite = datatable.Rows.Count; }

                for (int j = i; j < limite; j++)
                {

                    builder.Append(string.Format(
                                  " ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}') ,",
                                 datatable.Rows[j].ItemArray[0],
                                 datatable.Rows[j].ItemArray[1].ToString(),
                                 datatable.Rows[j].ItemArray[2].ToString(),
                                 datatable.Rows[j].ItemArray[3].ToString(),
                                 datatable.Rows[j].ItemArray[4].ToString(),
                                 datatable.Rows[j].ItemArray[5].ToString(),
                                 datatable.Rows[j].ItemArray[6].ToString(),
                                 datatable.Rows[j].ItemArray[7].ToString(),
                                 datatable.Rows[j].ItemArray[8].ToString(),
                                 datatable.Rows[j].ItemArray[9].ToString(),
                                 datatable.Rows[j].ItemArray[10].ToString(),
                                 datatable.Rows[j].ItemArray[11].ToString(),
                                 datatable.Rows[j].ItemArray[12].ToString()
                                 ));



                    bar.Increment(1);


                }

                command.CommandText = builder.ToString().Remove(builder.ToString().Length - 1);
                command.ExecuteNonQuery();
                t.Commit();

            }

        }



        public void InsertarDmArticulosAppBulk(DataTable datatable, ProgressBar bar)
        {

            bar.Minimum = 0;
            bar.Maximum = datatable.Rows.Count;

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            SqlCommand command = new SqlCommand("truncate table DM_productos_webApp", conn);
            command.ExecuteNonQuery();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
            {
                bulkCopy.DestinationTableName =
                    "dbo.DM_productos_webApp";

                try
                {
                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(datatable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Eror bulk DM productos");
                }
            }

            bar.Value = bar.Maximum;

            conn.Close();

        }

        public void InsertarDmArticulosBulk(DataTable datatable, ProgressBar bar)
        {

            bar.Minimum = 0;
            bar.Maximum = datatable.Rows.Count;

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            SqlCommand command = new SqlCommand("truncate table Dm_productos", conn);
            command.ExecuteNonQuery();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
            {
                bulkCopy.DestinationTableName =
                    "dbo.DM_productos";

                try
                {
                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(datatable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Eror bulk DM productos");
                }
            }

            bar.Value = bar.Maximum;

            conn.Close();

        }


    }
}
