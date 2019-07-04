using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyTeamApp
{
    public class Distrimar_SQLSERVER
    {

        private string connectionString =
            "Data Source = chapadany.database.windows.net; Initial Catalog = chapadany_prueba1;" +
            " Integrated Security = False; User ID = daniel; Password=andenopA*1;" +
            "Connect Timeout = 60; Encrypt=False;TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public void Bulk_Insert(DataGridView dataGrid, ProgressBar bar)
        {

            DataTable dt = new DataTable();

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            dt.Columns.AddRange(new DataColumn[5] 
            {
                new DataColumn("Fabrica", typeof(string)),
                new DataColumn("Codigo", typeof(string)),
                new DataColumn("Descrip",typeof(string)),
                new DataColumn("Modelo",typeof(string)),
                new DataColumn("Precio",typeof(float))
            });

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                    dt.Rows.Add(
                        row.Cells[0].Value.ToString(), 
                        row.Cells[1].Value.ToString(),
                        row.Cells[2].Value.ToString(),
                        row.Cells[3].Value.ToString(),
                        row.Cells[4].Value
                        );

                bar.Increment(1);

            }

            if (dt.Rows.Count > 0)
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


                SqlCommand command = new SqlCommand("truncate table dbo.Distrimar", conn);
                command.ExecuteNonQuery();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName =
                        "dbo.Distrimar";

                    bulkCopy.BulkCopyTimeout = 60000;

                    try
                    {
                        // Write from the source to the destination.
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }

        }

        public void InsertarPreciosBulk(DataGridView dataGrid, ProgressBar bar)
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
            

            SqlCommand command = new SqlCommand("truncate table dbo.Distrimar", conn);
            command.ExecuteNonQuery();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
            {
                bulkCopy.DestinationTableName =
                    "dbo.Distrimar";

                try
                {
                    // Write from the source to the destination.
                    //bulkCopy.WriteToServer(dataGrid);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bar.Value = bar.Maximum;

            conn.Close();

        }


        public void InsertarPreciosTrans(DataGridView dataGrid, ProgressBar bar)
        {

            bar.Minimum = 0;
            bar.Maximum = dataGrid.RowCount;

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


            buid_Rubros.Append(string.Format("delete from Distrimar; INSERT INTO Distrimar" +
                          "([Fabrica] ,[Codigo],[Descrip],[Modelo],[Precio]) VALUES "));

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if ( row.Cells[0].ToString().Trim().Length > 0 ) { 

                buid_Rubros.Append(string.Format(
                            "('{0}','{1}','{2}','{3}',{4}) ,",
                            row.Cells[0].Value.ToString().Trim(),
                            row.Cells[1].Value.ToString().Trim(),
                            row.Cells[2].Value.ToString().Trim(),
                            row.Cells[3].Value.ToString().Replace('"',' ').Replace("'"," "),
                            row.Cells[4].Value.ToString().Trim()));

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
