using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyTeamApp
{
    public class Proveedores_SQLSERVER
    {

        private string connectionString =
            "Data Source = chapadany.database.windows.net; Initial Catalog = chapadany_prueba1;" +
            " Integrated Security = False; User ID = daniel; Password=andenopA*1;" +
            "Connect Timeout = 0; Encrypt=False;TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";



        public void eliminarRepetidos()
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


        }

   
        public void InsertarPreciosBulk(DataTable dataGrid, ProgressBar bar, string tabla)
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
            

            SqlCommand command = new SqlCommand("truncate table dbo." + tabla, conn);
            command.ExecuteNonQuery();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
            {
                bulkCopy.DestinationTableName =
                    "dbo." + tabla;

                bulkCopy.BulkCopyTimeout = 0;

                try
                {
                    // Write from the source to the destination.

                    bulkCopy.WriteToServer(dataGrid);
                }
                catch (Exception ex)
                {
                    MessageBox.Show( ex.Message + "\r\r" + ex.StackTrace, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            bar.Value = bar.Maximum;

            conn.Close();

        }


        public void InsertarBulk(DataTable dataGrid, string tabla)
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


            SqlCommand command = new SqlCommand("truncate table " + tabla, conn);
            command.ExecuteNonQuery();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
            {
                bulkCopy.DestinationTableName =
                    "dbo." + tabla;

                bulkCopy.BulkCopyTimeout = 0;

                try
                {
                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(dataGrid);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\r\r" + ex.StackTrace, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            conn.Close();

        }




    }
}
