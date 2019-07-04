using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyTeamApp
{
    public class Lam_SQLSERVER
    {

        private string connectionString =
            "Data Source = chapadany.database.windows.net; Initial Catalog = chapadany_prueba1;" +
            " Integrated Security = False; User ID = daniel; Password=andenopA*1;" +
            "Connect Timeout = 60; Encrypt=False;TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";




        public void InsertarPreciosBulk(DataTable dataGrid, ProgressBar bar)
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
            

            SqlCommand command = new SqlCommand("truncate table ProveedoresLam", conn);
            command.ExecuteNonQuery();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
            {
                bulkCopy.DestinationTableName =
                    "dbo.ProveedoresLam";

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


        public void InsertarPreciosTrans(DataTable dataGrid, ProgressBar bar)
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


            buid_Rubros.Append(string.Format("delete from ProveedoresLam; INSERT INTO ProveedoresLam" +
                          " ([CODIGO], [RUBRO], [LINEA], [AUTO], [DESCRIP], [LADO], [MODELO] ,[PRECIO] ,[P], [PEDIDO] ,[REG]) VALUES "));

            foreach (DataRow row in dataGrid.Rows)
            {
                if ( row[0].ToString().Trim().Length > 0 ) { 

                buid_Rubros.Append(string.Format(
                            "('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},'{8}',{9},{10}) ,",
                            row[0].ToString().Trim(),
                            row[1].ToString().Trim(),
                            row[2].ToString().Trim(),
                            row[3].ToString().Trim(),
                            row[4].ToString().Trim(),
                            row[5].ToString().Trim(),
                            row[6].ToString().Trim(),
                            row[7],
                            row[8].ToString().Trim(),
                            row[9],
                            row[10]   
                            ));

                    bar.Increment(1);
                }

            }

            command.CommandText = buid_Rubros.ToString().Substring(0, buid_Rubros.ToString().Length - 1);
            command.ExecuteNonQuery();
            t.Commit();

            conn.Close();

        }


    }
}
