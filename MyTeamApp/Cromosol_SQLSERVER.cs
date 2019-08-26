using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyTeamApp
{
    public class Cromosol_SQLSERVER
    {

        private string connectionString =
            "Data Source = chapadany.database.windows.net; Initial Catalog = chapadany_prueba1;" +
            " Integrated Security = False; User ID = daniel; Password=andenopA*1;" +
            "Connect Timeout = 60; Encrypt=False;TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public void InsertarEmpresaBulk(DataTable dataGrid, ProgressBar bar)
        {

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            SqlCommand command = new SqlCommand("truncate table Cromosol_Empresa", conn);
            command.ExecuteNonQuery();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
            {
                bulkCopy.DestinationTableName =
                    "dbo.Cromosol_Empresa";

                try
                {
                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(dataGrid);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bar.Value = bar.Maximum;

            conn.Close();

        }

        public void InsertarEmpresa(DataTable dataGrid, ProgressBar bar)
        {

            int initTime = Environment.TickCount;

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            //try
            //{
            IDbCommand command = conn.CreateCommand();

            IDbTransaction t = conn.BeginTransaction(IsolationLevel.RepeatableRead);
            command.Transaction = t;

            StringBuilder builder = new StringBuilder();

            builder.Append(string.Format("delete from Cromosol_Empresa; INSERT INTO Cromosol_Empresa(EmpresaID, Nombre, Activa, RutaImagenes," +
                "Descuento,Incremento,DescuentoPagoCliente,DescuentoPagoVendedor,ComprobanteSinDescuento) VALUES "));

            foreach (DataRow row in dataGrid.Rows)
            {

                builder.Append(string.Format(
                           " ('{0}','{1}','{2}','','{4}','{5}','{6}','{7}','{8}') ,",
                          row[0],
                          row[1].ToString(),
                          row[2].ToString(),
                          row[3].ToString(),
                          row[4].ToString(),
                          row[5].ToString(),
                          row[6].ToString(),
                          row[7].ToString(),
                          row[8].ToString().Replace(",", " ")
                          ));


                bar.Increment(1);
            }

            //buid_listaPreciosProv.AppendFormat(" ON DUPLICATE KEY UPDATE fecha_mod = VALUES(fecha_mod), precio1 = VALUES(precio1), precio2=VALUES(precio2)");
            command.CommandText = builder.ToString().Remove(builder.ToString().Length - 1, 1);
            command.ExecuteNonQuery();
            t.Commit();

            conn.Close();

            //}

            //catch (Exception ex_trans)
            //{
            //    MessageBox.Show("Error en transacción: " + ex_trans.Message);
            //}
            //finally
            //{
            //    connection.Close();
            //}
        }




        public void InsertarArticuloRubro(DataTable datatable, ProgressBar bar)
        {
            const int maxRows = 5000;
            int limite;

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

            IDbCommand cmdDelete = conn.CreateCommand();
            cmdDelete.CommandText = "delete FROM Cromosol_ArticuloRubro;";
            cmdDelete.ExecuteNonQuery();
            cmdDelete.Dispose();



            for (int i = 0; i <= datatable.Rows.Count; i = i + maxRows)
            {

                IDbCommand command = conn.CreateCommand();
                IDbTransaction t = conn.BeginTransaction(IsolationLevel.RepeatableRead);
                StringBuilder builder = new StringBuilder();

                command.Transaction = t;

                builder.Append(string.Format("INSERT IGNORE INTO Cromosol_ArticuloRubro(ArticuloRubroID, RubroID, ArticuloID ) VALUES "));

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




        public void InsertarArticuloRubroTrans(DataTable dataGrid, ProgressBar bar)
        {

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            IDbCommand cmdDelete = conn.CreateCommand();
            cmdDelete.CommandText = "TRUNCATE TABLE Cromosol_ArticuloRubro;";
            cmdDelete.ExecuteNonQuery();
            cmdDelete.Dispose();

            const int maxRows = 1000;
            int limite;

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;


            for (int i = 0; i <= dataGrid.Rows.Count; i = i + maxRows)
            {

                IDbCommand command = conn.CreateCommand();
                IDbTransaction t = conn.BeginTransaction(IsolationLevel.RepeatableRead);
                command.Transaction = t;

                StringBuilder builder = new StringBuilder();

                builder.Append(string.Format("INSERT INTO Cromosol_ArticuloRubro(ArticuloRubroID, RubroID, ArticuloID ) values "));

                if (dataGrid.Rows.Count > i + maxRows)
                { limite = i + maxRows; }
                else
                { limite = dataGrid.Rows.Count; }

                for (int j = i; j < limite; j++)
                {

                    builder.Append(string.Format(
                               "('{0}','{1}','{2}') ,",
                              dataGrid.Rows[j].ItemArray[0],
                              dataGrid.Rows[j].ItemArray[1].ToString(),
                              dataGrid.Rows[j].ItemArray[2].ToString()
                              ));

                    bar.Increment(1);

                }

                command.CommandText = builder.ToString().Remove(builder.ToString().Length - 1);

                if (command.CommandText.Length > 0)
                {
                    command.ExecuteNonQuery();
                    t.Commit();
                }
                else
                {
                    t.Rollback();
                    break;
                }

            }

            conn.Close();

        }

        public void InsertarMarcas(DataTable dataGrid, ProgressBar bar)
        {

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            SqlCommand  cmd_marcas = conn.CreateCommand();
            string sql = null;
            int counter = 0;

            foreach (DataRow row in dataGrid.Rows)
            {
                sql += "(@idMarcas" + counter + ", @marca" + counter + ", @activo" + counter + ") ,";

                cmd_marcas.Parameters.Add(new SqlParameter("@idMarcas" + counter, row[0].ToString().Trim()));
                cmd_marcas.Parameters.Add(new SqlParameter("@marca" + counter, row[1].ToString().Trim()));
                cmd_marcas.Parameters.Add(new SqlParameter("@activo" + counter, row[2].ToString().Trim()));

                counter++;
                bar.Increment(1);

            }

            cmd_marcas.CommandText = "delete from Cromosol_VehiculoMarca;" +
                "INSERT INTO Cromosol_VehiculoMarca(VehiculoMarcaID, Descripcion, Activo) " +
                "VALUES " + sql.Substring(0, sql.Length - 1);

            try
            {
                cmd_marcas.ExecuteNonQuery(); bar.Increment(1);
            }
            catch (Exception ex) { MessageBox.Show("Excepcion mySQL: " + ex.Message); }


            conn.Close();

        }

        public void InsertarModelosTrans(DataTable dataGrid, ProgressBar bar)
        {

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            //try
            //{
            IDbCommand command = conn.CreateCommand();
            int initTime = Environment.TickCount;
            IDbTransaction t = conn.BeginTransaction(IsolationLevel.RepeatableRead);
            command.Transaction = t;

            StringBuilder builder = new StringBuilder();

            builder.Append(string.Format("delete from Cromosol_VehiculoModelo; " +
                                         "BULK INSERT Cromosol_VehiculoModelo(VehiculoModeloID, VehiculoMarcaID, Descripcion, AnioDesde, AnioHasta,Observaciones,Activo,Motor) VALUES "));

            foreach (DataRow row in dataGrid.Rows)
            {
                builder.Append(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}') ,",
                          row[0],
                          row[1],
                          row[2].ToString().Replace("'", " "),
                          row[3],
                          row[4],
                          row[5],
                          row[6],
                          row[7]
                          ));


                bar.Increment(1);
            }

            command.CommandText = builder.ToString().Substring(0, builder.ToString().Length - 1);
            command.ExecuteNonQuery();
            t.Commit();

            conn.Close();

        }

        public void InsertarModelosBulk(DataTable dataGrid, ProgressBar bar)
        {

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            SqlCommand command = new SqlCommand("truncate table Cromosol_VehiculoModelo", conn);
            command.ExecuteNonQuery();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
            {
                bulkCopy.DestinationTableName =
                    "dbo.Cromosol_VehiculoModelo";

                try
                {
                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(dataGrid);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bar.Value = bar.Maximum;

            conn.Close();

        }


        public void InsertarArticulosBulk(DataTable dataGrid, ProgressBar bar)
        {

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            SqlCommand command = new SqlCommand("truncate table Cromosol_Articulo", conn);
            command.ExecuteNonQuery();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
            {
                
                bulkCopy.BatchSize = 100000; // How many Rows you want to insert at a time
                bulkCopy.BulkCopyTimeout = 0;

                bulkCopy.DestinationTableName =
                    "dbo.Cromosol_Articulo";

                try
                {
                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(dataGrid);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bar.Value = bar.Maximum;

            conn.Close();

        }


        public void InsertarVehiculosArticulosBulk(DataTable dataGrid, ProgressBar bar)
        {

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            SqlCommand command = new SqlCommand("truncate table Cromosol_VehiculoArticulo", conn);
            command.ExecuteNonQuery();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
            {

                bulkCopy.BatchSize = 100000; // How many Rows you want to insert at a time
                bulkCopy.BulkCopyTimeout = 0;

                bulkCopy.DestinationTableName =
                    "dbo.Cromosol_VehiculoArticulo";

                try
                {
                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(dataGrid);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bar.Value = bar.Maximum;

            conn.Close();

        }


        public void InsertarRubrosTrans(DataTable dataGrid, ProgressBar bar)
        {

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            //try
            //{
            IDbCommand command = conn.CreateCommand();
            int initTime = Environment.TickCount;
            IDbTransaction t = conn.BeginTransaction(IsolationLevel.RepeatableRead);
            command.Transaction = t;

            StringBuilder buid_Rubros = new StringBuilder();


            buid_Rubros.Append(string.Format("delete from Cromosol_Rubro; INSERT INTO Cromosol_Rubro" +
                          "(RubroID,Codigo,Descripcion,Rubro_Padre,Activo,Orden) " +
                          "VALUES "));


            foreach (DataRow row in dataGrid.Rows)
            {
                buid_Rubros.Append(string.Format(
                            "('{0}','{1}','{2}','{3}','{4}','{5}') ,",
                            row[0],
                            row[1].ToString(),
                            row[2].ToString(),
                            row[3],
                            row[4].ToString(),
                            row[5]
                            ));

                bar.Increment(1);
            }

            command.CommandText = buid_Rubros.ToString().Substring(0, buid_Rubros.ToString().Length - 1);
            command.ExecuteNonQuery();
            t.Commit();

            conn.Close();

        }

        public void InsertarMarcasTrans(DataTable dataGrid, ProgressBar bar)
        {

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            IDbCommand command = conn.CreateCommand();

            IDbTransaction t = conn.BeginTransaction(IsolationLevel.RepeatableRead);
            command.Transaction = t;

            StringBuilder builder = new StringBuilder();

            builder.Append(string.Format("DELETE FROM Cromosol_Marca;" +
                                         "INSERT INTO Cromosol_Marca(MarcaID, Codigo, Descripcion, Activo, Orden) VALUES "));

            foreach (DataRow row in dataGrid.Rows)
            {

                builder.Append(string.Format(
                           "('{0}','{1}','{2}','{3}','{4}') ,",
                          row[0],
                          row[1].ToString(),
                          row[2].ToString(),
                          row[3].ToString(),
                          row[4].ToString()
                          ));

                bar.Increment(1);
            }

            command.CommandText = builder.ToString().Substring(0, builder.ToString().Length - 1);
            command.ExecuteNonQuery();
            t.Commit();

            conn.Close();

        }

        public void InsertarArticulosTrans(DataTable dataGrid, ProgressBar bar)
        {

            SqlConnection conn = new SqlConnection(connectionString);

            string fecha;

            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            IDbCommand cmdDelete = conn.CreateCommand();
            cmdDelete.CommandText = "TRUNCATE TABLE Cromosol_Articulo;";
            cmdDelete.ExecuteNonQuery();
            cmdDelete.Dispose();

            const int maxRows = 10000;
            int limite;

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;


            for (int i = 0; i <= dataGrid.Rows.Count; i = i + maxRows)
            {

                IDbCommand command = conn.CreateCommand();
                IDbTransaction t = conn.BeginTransaction(IsolationLevel.RepeatableRead);
                command.Transaction = t;

                StringBuilder builder = new StringBuilder();

                builder.Append(string.Format("INSERT INTO Cromosol_Articulo(ArticuloID, EmpresaID, Numero, MarcaID, " +
                                               "Descripcion,Codigo,PrecioMinorista,PrecioMayorista,UnidadxBulto,Nota,MonedaID, " +
                                               "MensajeBaja,FechaBaja,Imagen,CodigoFabricante,IVA) VALUES "));

                if (dataGrid.Rows.Count > i + maxRows)
                {
                    limite = i + maxRows;
                }
                else
                {
                    limite = dataGrid.Rows.Count;
                }

                for (int j = i; j < limite; j++)
                {
                    if (dataGrid.Rows[j].ItemArray[12].ToString().Length == 0)
                    { fecha = string.Empty; }
                    else {
                        fecha = dataGrid.Rows[j].ItemArray[12].ToString().Trim().Substring(6, 4) +
                                dataGrid.Rows[j].ItemArray[12].ToString().Trim().Substring(3, 2) +
                                dataGrid.Rows[j].ItemArray[12].ToString().Trim().Substring(0, 2);
                    }

                    builder.Append(string.Format(
                    "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}') ,",
                   dataGrid.Rows[j].ItemArray[0],
                   dataGrid.Rows[j].ItemArray[1].ToString(),
                   dataGrid.Rows[j].ItemArray[2].ToString(),
                   dataGrid.Rows[j].ItemArray[3].ToString(),
                   dataGrid.Rows[j].ItemArray[4].ToString().Replace('"', ' ').Trim(),
                   dataGrid.Rows[j].ItemArray[5].ToString(),
                   dataGrid.Rows[j].ItemArray[6].ToString(),
                   dataGrid.Rows[j].ItemArray[7].ToString(),
                   dataGrid.Rows[j].ItemArray[8].ToString(),
                   dataGrid.Rows[j].ItemArray[9].ToString(),
                   dataGrid.Rows[j].ItemArray[10].ToString(),
                   dataGrid.Rows[j].ItemArray[11].ToString(),
                   fecha,
                   dataGrid.Rows[j].ItemArray[13].ToString(),
                   dataGrid.Rows[j].ItemArray[14].ToString(),
                   dataGrid.Rows[j].ItemArray[15].ToString()
                   ));

                    bar.Increment(1);
                }

                command.CommandText = builder.ToString().Remove(builder.ToString().Length - 1);

                if (command.CommandText.Length > 0)
                {
                    command.ExecuteNonQuery();
                    t.Commit();
                }
                else
                {
                    t.Rollback();
                    break;
                }

            }

            conn.Close();

        }


        public void InsertarVehiculosArticulos(DataTable dataGrid, ProgressBar bar)
        {

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            IDbCommand cmdDelete = conn.CreateCommand();
            cmdDelete.CommandText = "TRUNCATE TABLE Cromosol_VehiculoArticulo;";
            cmdDelete.ExecuteNonQuery();
            cmdDelete.Dispose();

            const int maxRows = 1000;
            int limite;

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;


            for (int i = 0; i <= dataGrid.Rows.Count; i = i + maxRows)
            {

                IDbCommand command = conn.CreateCommand();
                IDbTransaction t = conn.BeginTransaction(IsolationLevel.RepeatableRead);
                command.Transaction = t;

                StringBuilder builder = new StringBuilder();

                builder.Append(string.Format("INSERT INTO Cromosol_VehiculoArticulo(VehiculoArticuloID, VehiculoModeloID, ArticuloID) values "));

                if (dataGrid.Rows.Count > i + maxRows)
                { limite = i + maxRows; }
                else
                { limite = dataGrid.Rows.Count; }

                for (int j = i; j < limite; j++)
                {

                    builder.Append(string.Format(
                               "('{0}','{1}','{2}') ,",
                              dataGrid.Rows[j].ItemArray[0],
                              dataGrid.Rows[j].ItemArray[1].ToString(),
                              dataGrid.Rows[j].ItemArray[2].ToString()
                              ));

                    bar.Increment(1);

                }

                command.CommandText = builder.ToString().Remove(builder.ToString().Length - 1);

                if (command.CommandText.Length > 0)
                {
                    command.ExecuteNonQuery();
                    t.Commit();
                }
                else
                {
                    t.Rollback();
                    break;
                }

            }

            conn.Close();


        }




    }
}
