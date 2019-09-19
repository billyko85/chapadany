using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace MyTeamApp
{

    class espejosSqlServer
    {

            private string connectionString =
       "Data Source = chapadany.database.windows.net; Initial Catalog = chapadany_prueba1;" +
       " Integrated Security = False; User ID = daniel; Password=andenopA*1;" +
       "Connect Timeout = 60; Encrypt=False;TrustServerCertificate=False;" +
       "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void InsertarEspejosBulk(DataTable datatable)
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

            SqlCommand command = new SqlCommand("truncate table ProveedoresLmEspejosArticulos", conn);
            command.ExecuteNonQuery();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
            {
                bulkCopy.DestinationTableName =
                    "dbo.ProveedoresLmEspejosArticulos";

                try
                {
                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(datatable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Eror bulk Lm espejos");
                }
            }

            conn.Close();

        }





    }
}
