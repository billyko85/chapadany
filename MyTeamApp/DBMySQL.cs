using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
//Add MySql Library
using MySql.Data.MySqlClient;

namespace MyTeamApp
{
    class DBMySQL
    {
        private MySqlConnection connection; 
        public int codProv = -1;
        public string desVersion;
        public int nroVersion = -1;
        public int DM;
        public int Cromo;
        public int BBA;
        public int DelViso;
        public int Otero;
        public int SanFernet;
        public int Chriva;
        public int codfarosDam;

        //Constructor
        public DBMySQL()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {

            string server = "70.39.248.227";
            string database = "chapad5_pos_pruebas";
            string uid = "chapad5_pos1";
            string password = "andenopA*1";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

            DM = setCodProv("DM");
            Cromo = setCodProv("Cromosol");
            BBA = setCodProv("BBA");
            Otero = setCodProv("Otero");
            DelViso = setCodProv("DelViso");
            SanFernet = setCodProv("San Fernet");
            Chriva = setCodProv("Chriva");
            codfarosDam = setCodProv("farosDam");

        }

        public class myQueryParameter
        {
            public MySqlDbType paramType { get; set; }
            public string paramValue { get; set; }
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
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

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void resetProv(string proveedor)
        {
            codProv = -1;
            nroVersion = -1;

            codProv = leerCodProv(proveedor);
            nroVersion = leerVersionNombre(proveedor);
        }


        public int setCodProv(string proveedor)
        {
            int codProv;

            if (this.OpenConnection() != true)
            { return -1; }

            MySqlCommand mycomand = new MySqlCommand("SELECT idProv FROM Proveedores WHERE nombre = '" + proveedor + "'", connection);
            codProv = (Int32)mycomand.ExecuteScalar();
            this.CloseConnection();

            if (!codProv.Equals(null))
                return codProv;

            return -1;
        }

        public int leerCodProv(string proveedor)
        {
            if (this.codProv >= 0)
                return this.codProv;

            if (this.OpenConnection() != true)
            { return -1; }

            MySqlCommand mycomand = new MySqlCommand("SELECT idProv FROM Proveedores WHERE nombre = '" + proveedor + "'", connection);
            MySqlDataReader myreader = mycomand.ExecuteReader();

            myreader.Read();
            this.codProv = myreader.GetInt32("idProv");
            this.CloseConnection();

            return this.codProv;

        }


        public string leerVersionID(int idProv)
        {
            string sql_query = " SELECT nro_version, des_version FROM ListasVersionProv " +
                                "WHERE idProv = @idProv and nro_version = (SELECT MAX(nro_version) AS nro FROM ListasVersionProv WHERE idProv = @idProv);";

            if (this.nroVersion >= 0)
                return this.desVersion;

            if (this.OpenConnection() != true)
            { return null; }

            MySqlCommand mycomand = new MySqlCommand(sql_query, connection);
            mycomand.Parameters.Add("@idProv", MySqlDbType.Int32);
            mycomand.Parameters["@idProv"].Value = idProv;

            MySqlDataReader myreader = mycomand.ExecuteReader();
            myreader.Read();

            if (myreader.HasRows)
            {
                this.nroVersion = Convert.ToInt32(myreader[0].ToString());
                this.desVersion = myreader[1].ToString();
            }
            else
            {
                this.nroVersion = 0;
            }

            this.CloseConnection();

            return this.desVersion;
        }

        public string leerUltimaVersionActualizada(string proveedor)
        {
            string des_version;
            string sql_query = "SELECT nro_version, des_version  FROM ListasVersionProv, Proveedores WHERE ListasVersionProv.idProv = Proveedores.idProv " +
                "AND nro_version = (SELECT MAX(nro_version) FROM ListasVersionProv WHERE ListasVersionProv.idProv = Proveedores.idProv) and " +
                "Proveedores.nombre = '" + proveedor + "';";
                
                
            if (this.OpenConnection() != true)
            { return null; }

            try
            {

                MySqlCommand mycomand = new MySqlCommand(sql_query, connection);
                MySqlDataReader myreader = mycomand.ExecuteReader();

                myreader.Read();

                if (myreader.HasRows)
                {
                    this.nroVersion = Convert.ToInt32(myreader[0].ToString());
                    des_version = myreader[1].ToString();
                }
                else
                {
                    this.nroVersion = 0;
                    des_version = null;
                }

                this.CloseConnection();

                return des_version;

            }


            catch (Exception ex)
            {
                this.CloseConnection();
                MessageBox.Show(ex.ToString());
                return null;
            }

       
        }


        public int leerVersionNombre(string proveedor)
        {
            string sql_query = "SELECT MAX(nro_version) FROM ListasVersionProv " +
                                "WHERE idProv = (SELECT idProv FROM Proveedores WHERE nombre = '" + proveedor + "')";

            if (this.nroVersion >= 0)
                return this.nroVersion;

            if (this.OpenConnection() != true)
            { return -1; }

            MySqlCommand mycomand = new MySqlCommand(sql_query, connection);
            MySqlDataReader myreader = mycomand.ExecuteReader();

            myreader.Read();

            if (myreader.HasRows)
            {
                this.nroVersion = Convert.ToInt32(myreader[0].ToString());
            }
            else { this.nroVersion = 0; }

            this.CloseConnection();

            return this.nroVersion;
        }

        public int insertarVersionCromo(string version, int idProv)
        {
            if (this.OpenConnection() != true)
            { return -1; }

            MySqlCommand comm = connection.CreateCommand();

            comm.CommandText = "DELETE FROM DM_empresas; DELETE FROM DM_productos_tipo; DELETE FROM DM_productos;" +
                                   "INSERT INTO ListasVersionProv (idProv, nro_version, des_version, fecha_lista, fecha_creacion) " +
                                   "SELECT @idProv,(SELECT MAX(nro_version) + 1 FROM ListasVersionProv WHERE idProv = @idProv), @desVersion, @fecha, NOW() " +
                                   "FROM ListasVersionProv WHERE NOT EXISTS(SELECT * FROM ListasVersionProv WHERE des_version = @desVersion) LIMIT 1; " +
                                   "SELECT MAX(nro_version) FROM ListasVersionProv where idProv = @idProv;";

            comm.Parameters.Add("@desVersion", MySqlDbType.VarChar);
            comm.Parameters["@desVersion"].Value = version;

            comm.Parameters.Add("@idProv", MySqlDbType.Int32);
            comm.Parameters["@idProv"].Value = idProv;

            comm.Parameters.Add("@fecha", MySqlDbType.Date);
            comm.Parameters["@fecha"].Value = DateTime.ParseExact(version, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            //try
            //{
                nroVersion = (int)comm.ExecuteScalar();
                this.CloseConnection();
                return nroVersion;
            //}


            //catch (Exception ex)
            //{
            //    this.CloseConnection();
            //    MessageBox.Show(ex.ToString());
            //    return -1;
            //}

        }


        public int InsertVersion(string txtVer, DateTime date, string proveedor)
        {
            int NroVersion = -1;

            if (this.OpenConnection() != true)
            { return -1; }

            MySqlCommand comm = connection.CreateCommand();

            //comm.CommandText = "INSERT INTO ListasVersionProv(idProv, nro_version, des_version, fecha_lista, fecha_creacion) " +
            //                   "SELECT Proveedores.idProv AS idProv, MAX(ListasVersionProv.nro_version) + 1 AS nro_version,'@desVersion' AS des_version, NOW(), NOW() AS fecha_creacion " +
            //                   "FROM ListasVersionProv, Proveedores WHERE ListasVersionProv.idProv = Proveedores.idProv and nombre = '@nombreProv' GROUP BY ListasVersionProv.idProv;";
            ////"SELECT MAX(nro_version) from ListasVersionProv, Proveedores WHERE ListasVersionProv.idProv = Proveedores.idProv and nombre = '@nombreProv';";
            /*@fecha AS fecha_lista*/


            comm.CommandText = "INSERT INTO ListasVersionProv(idProv, nro_version, des_version, fecha_lista, fecha_creacion) " +
                      "SELECT Proveedores.idProv AS idProv, MAX(ListasVersionProv.nro_version) + 1 AS nro_version, '" + proveedor + "', NOW(), NOW() AS fecha_creacion " +
                      "FROM ListasVersionProv, Proveedores WHERE ListasVersionProv.idProv = Proveedores.idProv and nombre = '" + proveedor + "' GROUP BY ListasVersionProv.idProv;" +
                      "SELECT MAX(nro_version) from ListasVersionProv, Proveedores WHERE ListasVersionProv.idProv = Proveedores.idProv and nombre = '" + proveedor + "';";

            //comm.Parameters.Add("@nombreProv", MySqlDbType.VarChar);
            //comm.Parameters["@nombreProv"].Value = proveedor;

            //comm.Parameters.Add("@desVersion", MySqlDbType.VarChar);
            //comm.Parameters["@desVersion"].Value = txtVer;

            //comm.Parameters.Add("@fecha", MySqlDbType.Date);
            //comm.Parameters["@fecha"].Value = date;

            try
            {
                NroVersion = (int)comm.ExecuteScalar();
                //comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            this.CloseConnection();
            return NroVersion;

        }


        public void InsertarEquivalencias(DataGridView dataGridEmpList, ProgressBar bar, int prov)
        {

            bar.Minimum = 0;
            bar.Maximum = dataGridEmpList.Rows.Count;

            this.OpenConnection();

            try
            {
                IDbCommand command = connection.CreateCommand();
                int initTime = Environment.TickCount;
                IDbTransaction t = connection.BeginTransaction(IsolationLevel.RepeatableRead);
                command.Transaction = t;

                StringBuilder buid_listaProv = new StringBuilder();

                foreach (DataGridViewRow row in dataGridEmpList.Rows)
                {
                    this.asignarCamposEquivalentes(buid_listaProv, prov, row);

                    bar.Increment(1);
                }

                command.CommandText = buid_listaProv.ToString();
                command.ExecuteNonQuery();
                t.Commit();


                MessageBox.Show("Tiempo transcurrido: " + (Environment.TickCount - initTime) + " ms");
            }

            catch (Exception ex_trans)
            {
                MessageBox.Show("Error en transacción: " + ex_trans.Message);
            }
            finally
            {
                connection.Close();
            }


        }

        public void asignarCamposEquivalentes(StringBuilder builder, int prov, DataGridViewRow row)
        {

            switch (prov)
            {
                case 2: //"Cromosol":
                case 3: // "BBA":
                    if (row.Index == 0)
                    {
                        builder.Append(string.Format("INSERT INTO ListasEquivalentesProveedores" +
                                  "(idProv, codProv, codProv2, descrip, rubro, fabricante, codFabricante, imagen, unidadxBulto) " +
                                  "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                                  prov,
                                  row.Cells[0].Value.ToString().Trim(),
                                  row.Cells[1].Value.ToString().Trim(),
                                  row.Cells[2].Value.ToString().Trim(),
                                  row.Cells[3].Value.ToString().Trim(),
                                  row.Cells[4].Value.ToString().Trim(),
                                  row.Cells[5].Value.ToString().Trim(),
                                  row.Cells[6].Value.ToString().Trim(),
                                  row.Cells[7].Value));
                    }
                    else {
                        builder.Append(string.Format(
                                   ", ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                                   prov,
                                  row.Cells[0].Value.ToString().Trim(),
                                  row.Cells[1].Value.ToString().Trim(),
                                  row.Cells[2].Value.ToString().Trim(),
                                  row.Cells[3].Value.ToString().Trim(),
                                  row.Cells[4].Value.ToString().Trim(),
                                  row.Cells[5].Value.ToString().Trim(),
                                  row.Cells[6].Value.ToString().Trim(),
                                  row.Cells[7].Value));
                    }

                    break;

            }
        }



        public void InsertArticulos(DataGridView dataGridEmpList, ProgressBar bar, int prov, bool insertarArt)
        {

            //int vueltas = 0;

            bar.Minimum = 0;
            bar.Maximum = dataGridEmpList.Rows.Count;

            this.OpenConnection();

            //try
            //{
                IDbCommand command = connection.CreateCommand();
                int initTime = Environment.TickCount;
                IDbTransaction t = connection.BeginTransaction(IsolationLevel.RepeatableRead);
                command.Transaction = t;
                command.CommandTimeout = 6000;

                StringBuilder buid_listaProv = new StringBuilder();
                StringBuilder buid_listaPreciosProv = new StringBuilder();

                foreach (DataGridViewRow row in dataGridEmpList.Rows)
                {
                    if (insertarArt)
                        this.asignarCamposBuilder(buid_listaProv, prov, row);

                    this.asignarCamposPrecios(buid_listaPreciosProv, prov, row);

                    bar.Increment(1);

                }

                if (insertarArt)
                {
                    command.CommandText = buid_listaProv.ToString().Remove(buid_listaProv.ToString().Length - 1) ;
                    command.ExecuteNonQuery();
                    t.Commit();
                    t.Dispose();

                    t = connection.BeginTransaction(IsolationLevel.RepeatableRead);
                    command.Transaction = t;
                }

                buid_listaPreciosProv.AppendFormat(" ON DUPLICATE KEY UPDATE fecha_mod = VALUES(fecha_mod), precio1 = VALUES(precio1), precio2=VALUES(precio2)");
                command.CommandText = buid_listaPreciosProv.ToString();
                command.ExecuteNonQuery();
                t.Commit();


            



            MessageBox.Show("Tiempo transcurrido: " + (Environment.TickCount - initTime) + " ms");

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


        public void asignarCamposBuilder(StringBuilder builder, int prov, DataGridViewRow row)
        {

            
            if ((prov == Cromo) || (prov == BBA))
            {

                if (row.Index == 0)
                {
                    builder.Append(string.Format("INSERT IGNORE INTO ListasProveedores" +
                              "(idProv, codProv, codProv2, descrip, rubro, fabricante, codFabricante, imagen, unidadxBulto) " +
                              "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                              prov,
                              row.Cells[0].Value.ToString().Trim(),
                              row.Cells[1].Value.ToString().Trim(),
                              row.Cells[2].Value.ToString().Trim(),
                              row.Cells[3].Value.ToString().Trim(),
                              row.Cells[4].Value.ToString().Trim(),
                              row.Cells[5].Value.ToString().Trim(),
                              row.Cells[6].Value.ToString().Trim(),
                              row.Cells[7].Value));
                }
                else {
                    builder.Append(string.Format(
                               ", ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}') ",
                              prov,
                              row.Cells[0].Value.ToString().Trim(),
                              row.Cells[1].Value.ToString().Trim(),
                              row.Cells[2].Value.ToString().Trim(),
                              row.Cells[3].Value.ToString().Trim(),
                              row.Cells[4].Value.ToString().Trim(),
                              row.Cells[5].Value.ToString().Trim(),
                              row.Cells[6].Value.ToString().Trim(),
                              row.Cells[7].Value));
                }
            }

            if (prov == DM && row.Cells[0].Value != null)
            { 
                if (row.Index == 0)
                    {
                    //id 1 ,descripcion 2,codigo 3,precio 4,imagen 5,empresa 6,id_categoria 7,origen 8,pesado 
                    builder.Append(string.Format("INSERT INTO ListasProveedores" +
                                  "(idProv, codProv, codProv2, descrip, rubro, fabricante, imagen, unidadxBulto,marca) " +
                                  "VALUES ('{0}','{1}','{3}','{2}','{7}','{8}','{5}',1,'{6}')",
                                  prov,
                                  row.Cells[0].Value.ToString().Trim(),
                                  row.Cells[1].Value.ToString().Trim(),
                                  row.Cells[2].Value.ToString().Trim(),
                                  row.Cells[3].Value.ToString().Trim(),
                                  row.Cells[4].Value.ToString().Trim(),
                                  row.Cells[5].Value.ToString().Trim(),
                                  row.Cells[6].Value.ToString().Trim(),
                                  row.Cells[7].Value,
                                  row.Cells[8].Value.ToString().Trim()
                                  ));
                    }
                    else {
                        builder.Append(string.Format(
                                   ", ('{0}','{1}','{3}','{2}','{7}','{8}','{5}',1,'{6}') ",
                                   prov,
                                  row.Cells[0].Value.ToString().Trim(),
                                  row.Cells[1].Value.ToString().Trim(),
                                  row.Cells[2].Value.ToString().Trim(),
                                  row.Cells[3].Value.ToString().Trim(),
                                  row.Cells[4].Value.ToString().Trim(),
                                  row.Cells[5].Value.ToString().Trim(),
                                  row.Cells[6].Value.ToString().Trim(),
                                  row.Cells[7].Value));
                    }
            }


            if (prov == Otero && row.Cells[2].Value != null)
            {
                if (row.Index == 0)
                {
                    //rubro 0 auto 1 codProv 2 codProv 3 descrip 4 precio 5
                    builder.Append(string.Format("INSERT INTO ListasProveedores" +
                                  "(idProv, codProv, codProv2, descrip,  auto, rubro) VALUES "));
                }
                
                    builder.Append(string.Format(
                               " ('{0}','{3}','{4}','{5}','{1}','{2}'),",
                                  prov,
                                  row.Cells[0].Value.ToString().Trim(),
                                  row.Cells[1].Value.ToString().Trim(),
                                  row.Cells[2].Value.ToString().Trim(),
                                  row.Cells[3].Value.ToString().Trim(),
                                  row.Cells[4].Value.ToString().Trim()
                             ));
                
            }

            if (prov == DelViso && row.Cells[0].Value != null)
            {
                if (row.Index == 0)
                {
                    builder.Append(string.Format("INSERT INTO ListasProveedores" +
                                  "(idProv, auto, codProv, codProv2, descrip ) VALUES "));

                }


                builder.Append(string.Format("('{0}','{1}','{2}','{3}','{4}'),",
                              prov,
                              row.Cells[0].Value.ToString().Trim(),
                              row.Cells[1].Value.ToString().Trim(),
                              row.Cells[2].Value.ToString().Trim(),
                              row.Cells[3].Value.ToString().Trim()
                               ));

            }


            if (prov == SanFernet && row.Cells[0].Value != null)
            {

                if (row.Index == 0)
                {
                    builder.Append(string.Format("INSERT INTO ListasProveedores" +
                                  "(idProv, codProv, marca, auto, descrip) VALUES "));
                }


                builder.Append(string.Format("('{0}','{1}','{2}','{3}','{4}'),",
                              prov,
                              row.Cells[0].Value.ToString().Trim(),
                              row.Cells[1].Value.ToString().Trim(),
                              row.Cells[2].Value.ToString().Trim(),
                              row.Cells[3].Value.ToString().Trim()
                               ));

            }

            if (prov == Chriva && row.Cells[0].Value != null)
            {

                if (row.Index == 0)
                {
                    builder.Append(string.Format("INSERT INTO ListasProveedores" +
                                  "(idProv, codProv,codprov2, auto, descrip) VALUES "));
                }


                builder.Append(string.Format("('{0}','{1}','{2}','{3}','{4}'),",
                              prov,
                              row.Cells[0].Value.ToString().Trim(),
                              row.Cells[1].Value.ToString().Trim(),
                              row.Cells[2].Value.ToString().Trim(),
                              row.Cells[3].Value.ToString().Trim()
                               ));

            }

            if (prov == codfarosDam && row.Cells[0].Value != null)
            {

                if (row.Index == 0)
                {
                    builder.Append(string.Format("INSERT INTO ListasProveedores" +
                                  "(idProv, auto, codProv,codProv2, unidadxBulto,descrip) VALUES "));
                }


                builder.Append(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}'),",
                              prov,
                              row.Cells[0].Value.ToString().Trim(),
                              row.Cells[1].Value.ToString().Trim(),
                              row.Cells[2].Value.ToString().Trim(),
                              row.Cells[3].Value.ToString().Trim(),
                              row.Cells[4].Value.ToString().Trim(),
                              row.Cells[5].Value.ToString().Trim()
                               ));

            }




        }

        public void asignarCamposPrecios(StringBuilder builder, int prov, DataGridViewRow row)
        {

            if ((prov == Cromo) || (prov == BBA))
            {
                if (row.Index == 0)
                {
                    builder.Append(string.Format("INSERT INTO ListasPreciosProveedores" +
                              "(idProv,codProv,nro_version,fecha_mod,precio1,precio2) " +
                              "VALUES ('{0}','{1}','{2}',NOW(),'{3}','{4}')",
                              prov,
                              row.Cells[0].Value.ToString().Trim(),
                              nroVersion,
                              row.Cells[8].Value,
                              row.Cells[9].Value));
                }
                else {
                    builder.Append(string.Format(
                               ", ('{0}','{1}','{2}',NOW(),'{3}','{4}')",
                               prov,
                              row.Cells[0].Value.ToString().Trim(),
                              nroVersion,
                              row.Cells[8].Value,
                              row.Cells[9].Value));
                }
            }

            if (prov == DM && row.Cells[3].Value != null)
            {

                if (row.Index == 0)
                {
                    builder.Append(string.Format("INSERT INTO ListasPreciosProveedores" +
                              "(idProv,codProv,nro_version,fecha_mod,precio1,precio2) " +
                              "VALUES ('{0}','{1}','{2}',NOW(),'{3}','{4}')",
                              prov,
                              row.Cells[2].Value.ToString().Trim(),
                              nroVersion,
                              row.Cells[3].Value,
                              row.Cells[3].Value));
                }
                else {
                    builder.Append(string.Format(
                               ", ('{0}','{1}','{2}',NOW(),'{3}','{4}')",
                               prov,
                              row.Cells[2].Value.ToString().Trim(),
                              nroVersion,
                              row.Cells[3].Value,
                              row.Cells[3].Value));
                }

            }


            if (prov == Otero && row.Cells[2].Value != null)
            {
                //auto 0 rubro 1 codProv 2 codProv 3 descrip 4 precio 5

                if (row.Index == 0 )
                {
                    builder.Append(string.Format("INSERT INTO ListasPreciosProveedores" +
                              "(idProv,codProv,codProv2,nro_version,fecha_mod,precio1,precio2) " +
                              "VALUES ('{0}','{1}','{2}','{3}',NOW(),'{4}','{4}')",
                              prov,
                              row.Cells[2].Value.ToString().Trim(),
                              row.Cells[3].Value.ToString().Trim(),
                              nroVersion,
                              row.Cells[5].Value,
                              row.Cells[5].Value));
                }
                else {
                    builder.Append(string.Format(
                               ", ('{0}','{1}','{2}','{3}',NOW(),'{4}','{4}')",
                               prov,
                              row.Cells[2].Value.ToString().Trim(),
                              row.Cells[3].Value.ToString().Trim(),
                              nroVersion,
                              row.Cells[5].Value,
                              row.Cells[5].Value));
                }


               }


            if (prov == DelViso && row.Cells[0].Value != null)
            {

                if (row.Index == 0 )
                {
                    builder.Append(string.Format("INSERT INTO ListasPreciosProveedores" +
                              "(idProv,codProv,codProv2,nro_version,fecha_mod,precio1,precio2) " +
                              "VALUES ('{0}','{1}','{2}','{3}',NOW(),'{4}','{4}')",
                              prov,
                              row.Cells[1].Value.ToString().Trim(),
                              row.Cells[2].Value.ToString().Trim(),
                              nroVersion,
                              row.Cells[4].Value));
                }
                else {
                    builder.Append(string.Format(
                               ", ('{0}','{1}','{2}','{3}',NOW(),'{4}','{4}')",
                               prov,
                              row.Cells[1].Value.ToString().Trim(),
                              row.Cells[2].Value.ToString().Trim(),
                              nroVersion,
                              row.Cells[4].Value));
                }

            }

            if (prov == SanFernet && row.Cells[0].Value != null)
            {

                if (row.Index == 0)
                {
                    builder.Append(string.Format("INSERT INTO ListasPreciosProveedores" +
                              "(idProv,codProv,codProv2,nro_version,fecha_mod,precio1,precio2) " +
                              "VALUES ('{0}','{1}','{2}','{3}',NOW(),'{4}','{4}')",
                              prov,
                              row.Cells[0].Value.ToString().Trim(),
                              row.Cells[0].Value.ToString().Trim(),
                              nroVersion,
                              row.Cells[4].Value.ToString()));
                }
                else {
                    builder.Append(string.Format(
                               ", ('{0}','{1}','{2}','{3}',NOW(),'{4}','{4}')",
                               prov,
                              row.Cells[0].Value.ToString().Trim(),
                              row.Cells[0].Value.ToString().Trim(),
                              nroVersion,
                              row.Cells[4].Value.ToString()));
                }

            }

            if (prov == Chriva && row.Cells[0].Value != null)
            {

                if (row.Index == 0)
                {
                    builder.Append(string.Format("INSERT INTO ListasPreciosProveedores" +
                              "(idProv,codProv,codProv2,nro_version,fecha_mod,precio1,precio2) " +
                              "VALUES ('{0}','{1}','{2}','{3}',NOW(),'{4}','{4}')",
                              prov,
                              row.Cells[0].Value.ToString().Trim(),
                              row.Cells[1].Value.ToString().Trim(),
                              nroVersion,
                              row.Cells[4].Value));
                }
                else {
                    builder.Append(string.Format(
                               ", ('{0}','{1}','{2}','{3}',NOW(),'{4}','{4}')",
                               prov,
                              row.Cells[0].Value.ToString().Trim(),
                              row.Cells[1].Value.ToString().Trim(),
                              nroVersion,
                              row.Cells[4].Value));
                }

            }


            if (prov == codfarosDam && row.Cells[0].Value != null)
            {

                if (row.Index == 0)
                {
                    builder.Append(string.Format("INSERT INTO ListasPreciosProveedores" +
                              "(idProv,codProv,codProv2,nro_version,fecha_mod,precio1,precio2) " +
                              "VALUES ('{0}','{1}','{2}','{3}',NOW(),'{4}','{4}')",
                              prov,
                              row.Cells[0].Value.ToString().Trim(),
                              row.Cells[1].Value.ToString().Trim(),
                              nroVersion,
                              row.Cells[5].Value));
                }
                else {
                    builder.Append(string.Format(
                               ", ('{0}','{1}','{2}','{3}',NOW(),'{4}','{4}')",
                               prov,
                              row.Cells[0].Value.ToString().Trim(),
                              row.Cells[1].Value.ToString().Trim(),
                              nroVersion,
                              row.Cells[5].Value));
                }

            }




        }

        public void InsertMassive(DataGridView dataGridEmpList, ProgressBar bar, string prov, int rowindex)
        {
            if (this.OpenConnection() == true)
            {

                MySqlCommand comm_prov = connection.CreateCommand();

                comm_prov.CommandText = "INSERT INTO ListasProveedores(idProv, codProv,codProv2,marca, auto, descrip, rubro, fabricante,codFabricante,imagen,unidadxBulto,stockOrigen) " +
                          "VALUES (@idProv,@codProv,@codProv2,@marca,@auto,@descrip,@rubro,@fabricante,@codFabricante,@imagen,@unidadxBulto,@stockOrigen)";

                comm_prov.Parameters.Add("@idProv", MySqlDbType.Int64);
                comm_prov.Parameters.Add("@codProv", MySqlDbType.VarChar);
                comm_prov.Parameters.Add("@codProv2", MySqlDbType.Int32);
                comm_prov.Parameters.Add("@marca", MySqlDbType.VarChar);
                comm_prov.Parameters.Add("@auto", MySqlDbType.VarChar);
                comm_prov.Parameters.Add("@descrip", MySqlDbType.VarChar);
                comm_prov.Parameters.Add("@rubro", MySqlDbType.VarChar);
                comm_prov.Parameters.Add("@fabricante", MySqlDbType.VarChar);
                comm_prov.Parameters.Add("@codFabricante", MySqlDbType.VarChar);
                comm_prov.Parameters.Add("@imagen", MySqlDbType.VarChar);
                comm_prov.Parameters.Add("@unidadxBulto", MySqlDbType.Int32);
                comm_prov.Parameters.Add("@stockOrigen", MySqlDbType.Int32);

                MySqlCommand comm_precios = connection.CreateCommand();

                comm_precios.CommandText = "INSERT INTO ListasPreciosProveedores(idProv,nro_version, codProv, fecha_mod, precio1, precio2) " +
                          "VALUES (@idProv,@nro_version,@codProv,NOW(),@precio1,@precio2)";

                comm_precios.Parameters.Add("@idProv", MySqlDbType.Int64);
                comm_precios.Parameters.Add("@nro_version", MySqlDbType.Int32);
                comm_precios.Parameters.Add("@codProv", MySqlDbType.VarChar);
                comm_precios.Parameters.Add("@precio1", MySqlDbType.Float);
                comm_precios.Parameters.Add("@precio2", MySqlDbType.Float);

                bar.Minimum = (int)rowindex;
                bar.Maximum = dataGridEmpList.Rows.Count;

                foreach (DataGridViewRow row in dataGridEmpList.Rows)
                {

                    if (row.Cells[1].Value.ToString() != "VACIO" && row.Index >= rowindex)
                    {

                        MySqlTransaction sqlTran = connection.BeginTransaction();
                        comm_prov.Transaction = sqlTran;
                        comm_precios.Transaction = sqlTran;

                        this.asignarCampos(comm_prov, comm_precios, prov, row);

                        try
                        {
                            comm_prov.ExecuteNonQuery();
                            comm_precios.ExecuteNonQuery();

                            sqlTran.Commit();
                            sqlTran.Dispose();

                            bar.Increment(1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Excepcion mySQL_Trans: " + ex.Message);

                            try
                            {
                                sqlTran.Rollback();
                            }
                            catch (Exception ex_trans)
                            {
                                MessageBox.Show("Error en transacción: " + ex_trans.Message);

                                try { this.OpenConnection(); }
                                catch (Exception ex_conn)
                                { MessageBox.Show("Error al crear conexión: " + ex_conn.Message); }

                            }

                        }
                    }
                }

                this.CloseConnection();
                MessageBox.Show("Fin Registros");

            }
        }

        public void asignarCampos(MySqlCommand comm_prov, MySqlCommand comm_precios, string prov, DataGridViewRow row)
        {

            switch (prov)
            {
                case "Cromosol":
                case "BBA":
                    comm_prov.Parameters["@idProv"].Value = this.leerCodProv(prov);
                    comm_prov.Parameters["@codProv"].Value = row.Cells[0].Value.ToString().Trim();
                    comm_prov.Parameters["@codProv2"].Value = row.Cells[1].Value.ToString().Trim();
                    comm_prov.Parameters["@descrip"].Value = row.Cells[2].Value.ToString().Trim();
                    comm_prov.Parameters["@rubro"].Value = row.Cells[3].Value.ToString().Trim();
                    comm_prov.Parameters["@fabricante"].Value = row.Cells[4].Value.ToString().Trim();
                    comm_prov.Parameters["@codFabricante"].Value = row.Cells[5].Value.ToString().Trim();
                    comm_prov.Parameters["@imagen"].Value = row.Cells[6].Value.ToString().Trim();
                    comm_prov.Parameters["@unidadxBulto"].Value = row.Cells[7].Value;

                    comm_precios.Parameters["@idProv"].Value = this.leerCodProv(prov);
                    comm_precios.Parameters["@codProv"].Value = row.Cells[0].Value.ToString().Trim();
                    comm_precios.Parameters["@nro_version"].Value = this.leerVersionNombre(prov);
                    comm_precios.Parameters["@precio1"].Value = row.Cells[8].Value;
                    comm_precios.Parameters["@precio2"].Value = row.Cells[9].Value;

                    break;

                case "DelViso":
                    comm_prov.Parameters["@idProv"].Value = this.leerCodProv(prov);
                    comm_prov.Parameters["@codProv"].Value = row.Cells[0].Value.ToString().Trim();
                    comm_prov.Parameters["@marca"].Value = row.Cells[1].Value.ToString().Trim();
                    comm_prov.Parameters["@auto"].Value = row.Cells[2].Value.ToString().Trim();
                    comm_prov.Parameters["@descrip"].Value = row.Cells[3].Value.ToString().Trim();

                    comm_precios.Parameters["@idProv"].Value = this.leerCodProv(prov);
                    comm_precios.Parameters["@codProv"].Value = row.Cells[0].Value.ToString().Trim();
                    comm_precios.Parameters["@nro_version"].Value = this.leerVersionNombre(prov);
                    comm_precios.Parameters["@precio1"].Value = row.Cells[4].Value;
                    comm_precios.Parameters["@precio2"].Value = row.Cells[5].Value;

                    break;

            }


        }


       

        public void InsertarComprasDelViso(DataGridView dataGrid, ProgressBar bar, int idProv, DataGridViewSelectedCellCollection cells)
        {

            int initTime = Environment.TickCount;

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            this.OpenConnection();

            //try
            //{
            IDbCommand command = connection.CreateCommand();

            IDbTransaction t = connection.BeginTransaction(IsolationLevel.RepeatableRead);
            command.Transaction = t;

            StringBuilder builder = new StringBuilder();

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.Cells[4].Value == null)
                    break;




                //cells[0].Value
                //"PASARR TRAS INT F/DUNA D/I"
                //? cells[1].Value
                //"FIAT UNO-DUNA-FIORUNO"
                //? cells[2].Value
                //"FI201874"
                //? cells[3].Value
                //"2285"
                //? cells[4].Value
                //500

                // ?Rows[0].Cells[0].Value
                //"duna"
                //? Rows[0].Cells[1].Value
                // fiat
                //? Rows[0].Cells[2].Value
                //"pasarrueda int. duna c/acc tras. der."
                //? Rows[0].Cells[3].Value
                // N
                //? Rows[0].Cells[4].Value
                //469
                //? Rows[0].Cells[5].Value
                //1
                //? Rows[0].Cells[6].Value
                //{ 21 / 07 / 2005 12:00:00 a.m.}
                //? Rows[0].Cells[7].Value
                //"Chiva"

                if (row.Index == 0)
                {
                    builder.Append(string.Format("INSERT INTO ChapadanyEquivalencias" +
                        "(idProv,CodProv,CodProv2,autoProv," +
                        " descripProv,ChapadanyCodProd,ChapadanyDescrip," +
                        "ChapadanyAuto,ChapadanyMarca,ChapadanyMarcaProd, " + 
                        "ChapadanyVentas,ChapadanyStock) " +
                        "values (" + idProv + ",'"+ cells[2].Value + "','" + cells[3].Value + "','" + cells[1].Value +
                        "','" + cells[0].Value + "','" + row.Cells[4].Value + "','" + row.Cells[2].Value +
                        "','" + row.Cells[0].Value + "','" + row.Cells[1].Value + "','" + row.Cells[3].Value +
                        "','" + row.Cells[8].Value + "','" + row.Cells[9].Value + "');" +
                        " INSERT INTO chapadanyCompras(idProv, CodProv, CodProv2, Fecha, cant, precio) VALUES "));


                }
                
                    builder.Append(string.Format(
                               " ('{0}','{1}','{2}',{3},'{4}','{5}'),",
                              idProv,
                              cells[2].Value,
                              cells[3].Value, 
                              row.Cells[6].Value.ToString().Substring(6,4)+ row.Cells[6].Value.ToString().Substring(3, 2)+ row.Cells[6].Value.ToString().Substring(0, 2),
                              row.Cells[5].Value.ToString(),
                              cells[4].Value));
                

                bar.Increment(1);
            }

            //buid_listaPreciosProv.AppendFormat(" ON DUPLICATE KEY UPDATE fecha_mod = VALUES(fecha_mod), precio1 = VALUES(precio1), precio2=VALUES(precio2)");
            command.CommandText = builder.ToString().Remove(builder.ToString().Length - 1,1);
            command.ExecuteNonQuery();
            t.Commit();

            MessageBox.Show("Tiempo transcurrido: " + (Environment.TickCount - initTime) + " ms");

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




        public void InsertarDmArticulos(DataTable datatable, ProgressBar bar)
        {
            const int maxRows = 5000;
            int limite;

            bar.Minimum = 0;
            bar.Maximum = datatable.Rows.Count;

            this.OpenConnection();

            for (int i = 0; i <= datatable.Rows.Count; i = i + maxRows)
            {

                IDbCommand command = connection.CreateCommand();
                IDbTransaction t = connection.BeginTransaction(IsolationLevel.RepeatableRead);
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






        public void InsertarDmProductos_TipoTrans(DataTable dataGrid, ProgressBar bar)
        {

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            this.OpenConnection();
            IDbCommand command = connection.CreateCommand();
            IDbTransaction t = connection.BeginTransaction(IsolationLevel.RepeatableRead);
            StringBuilder builder = new StringBuilder();

            command.Transaction = t;

            builder.Append(string.Format("DELETE FROM DM_productos_tipo ; INSERT INTO DM_productos_tipo(id, tipo, coeficiente, fecha_alta, fecha_modificacion) VALUES "));

            foreach (DataRow row in dataGrid.Rows)
            {

                builder.Append(string.Format(" ('{0}','{1}','{2}','{3}','{4}') ,",
                              row[0],
                              row[1].ToString(),
                              row[2].ToString(),
                              row[3].ToString(),
                              row[4].ToString()
                          ));

                bar.Increment(1);
            }

            command.CommandText = builder.ToString().Remove(builder.ToString().Length - 1);
            command.ExecuteNonQuery();
            t.Commit();

            this.CloseConnection();

        }

        public void InsertarDmEmpresasTrans(DataTable dataGrid, ProgressBar bar)
        {
 
            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            this.OpenConnection();
            IDbCommand command = connection.CreateCommand();
            IDbTransaction t = connection.BeginTransaction(IsolationLevel.RepeatableRead);
            StringBuilder builder = new StringBuilder();

            command.Transaction = t;

            builder.Append(string.Format("DELETE FROM DM_empresas; INSERT INTO DM_empresas(id, empresa, fecha_alta, fecha_modificacion) VALUES "));

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

            this.CloseConnection();
        }


        public bool InsertarModelos(DataGridView dataGrid, ProgressBar bar)
        {

            //open connection
            if (!OpenConnection())
            {
                return false;
            }

            MySqlCommand cmd_modelos = connection.CreateCommand();

            cmd_modelos.CommandText = "INSERT INTO AutosModelos(idAutosModelos, idMarcas, modelo, anio_inicio, anio_fin) " +
                        "VALUES (@idAutosModelos,@idMarcas, @modelo, @anio_inicio, @anio_fin)";

            cmd_modelos.Parameters.Add("@idAutosModelos", MySqlDbType.Int32);
            cmd_modelos.Parameters.Add("@idMarcas", MySqlDbType.Int32);
            cmd_modelos.Parameters.Add("@modelo", MySqlDbType.VarChar);
            cmd_modelos.Parameters.Add("@anio_inicio", MySqlDbType.UInt16);
            cmd_modelos.Parameters.Add("@anio_fin", MySqlDbType.UInt16);

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (Convert.ToBoolean(row.Cells[8].Value))
                    continue;

                cmd_modelos.Parameters["@idAutosModelos"].Value = row.Cells[0].Value;
                cmd_modelos.Parameters["@idMarcas"].Value = row.Cells[1].Value;
                cmd_modelos.Parameters["@modelo"].Value = row.Cells[2].Value.ToString().Trim();
                cmd_modelos.Parameters["@anio_inicio"].Value = row.Cells[3].Value;
                cmd_modelos.Parameters["@anio_fin"].Value = row.Cells[4].Value;

                try
                {
                    cmd_modelos.ExecuteNonQuery(); bar.Increment(1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepcion mySQL: " + ex.Message);
                }

            }

            CloseConnection(); return true;
        }

        public bool InsertarRubros(DataGridView dataGrid, ProgressBar bar)
        {

            //open connection
            if (!OpenConnection())
            {
                return false;
            }

            MySqlCommand cmd_modelos = connection.CreateCommand();

            cmd_modelos.CommandText = "INSERT INTO Rubros(idRubro, rubro) " +
                        "VALUES (@idRubro,@rubro)";

            cmd_modelos.Parameters.Add("@idRubro", MySqlDbType.Int32);
            cmd_modelos.Parameters.Add("@rubro", MySqlDbType.VarChar);

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (Convert.ToBoolean(row.Cells[6].Value))
                    continue;

                cmd_modelos.Parameters["@idRubro"].Value = row.Cells[0].Value;
                cmd_modelos.Parameters["@rubro"].Value = row.Cells[2].Value;

                try
                {
                    cmd_modelos.ExecuteNonQuery(); bar.Increment(1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepcion mySQL: " + ex.Message);
                }

            }

            CloseConnection(); return true;
        }

        public bool InsertarFabricantes(DataGridView dataGrid, ProgressBar bar)
        {

            //open connection
            if (!OpenConnection())
            {
                return false;
            }

            MySqlCommand cmd_modelos = connection.CreateCommand();

            cmd_modelos.CommandText = "INSERT INTO Fabricantes(idFabricantes, Fabricante) " +
                        "VALUES (@idFabricantes,@Fabricante)";

            cmd_modelos.Parameters.Add("@idFabricantes", MySqlDbType.Int32);
            cmd_modelos.Parameters.Add("@Fabricante", MySqlDbType.VarChar);

            bar.Minimum = 0;
            bar.Maximum = dataGrid.Rows.Count;

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (Convert.ToBoolean(row.Cells[5].Value))
                    continue;

                cmd_modelos.Parameters["@idFabricantes"].Value = row.Cells[0].Value;
                cmd_modelos.Parameters["@Fabricante"].Value = row.Cells[2].Value;

                try
                {
                    cmd_modelos.ExecuteNonQuery(); bar.Increment(1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepcion mySQL: " + ex.Message);
                }

            }

            CloseConnection(); return true;
        }

        public void cargarComboBox(ComboBox combo)
        {

            if (OpenConnection())
            {
                MySqlDataAdapter da_res = null;
                DataSet ds_res = null;
                ds_res = new DataSet();
                da_res = new MySqlDataAdapter("SELECT * from Proveedores", connection);
                da_res.Fill(ds_res, "Proveedores");

                combo.DataSource = ds_res.Tables[0];
                combo.ValueMember = "idProv";
                combo.DisplayMember = "nombre";

            }

            CloseConnection();
        }


        //public void cargarBusquedaRPM(DataGridView grid, string busqueda)
        //{
          

        //}

        public void cargarBusquedaRPM(DataGridView grid, string queryOnTable, List<string> reqColumns = null, List<myQueryParameter> conditionalParams = null)
    {

            StringBuilder sqlQueryBuilder = new StringBuilder();
        sqlQueryBuilder.Append("SELECT RpmArticulo.arterc, RpmArticulo.armode, RpmFamilias.fadesc,RpmFamilias.farazo,RpmRubros.rbdesc, RpmArticulo.ardesc, RpmArticulo.aroo ");
        //sqlQueryBuilder.Append(String.Join(",", reqColumns));
        sqlQueryBuilder.Append(String.Format(" FROM {0} WHERE ", "RpmArticulo,RpmFamilias,RpmRubros"));

            //          SELECT RpmArticulo.arterc, RpmArticulo.armode, RpmFamilias.fadesc,RpmFamilias.farazo,
            //  RpmRubros.rbdesc, RpmArticulo.ardesc,RpmArticulo.aroo FROM RpmArticulo,RpmFamilias,RpmRubros
            //WHERE RpmArticulo.arflia = RpmFamilias.facodi and
            //      RpmArticulo.arrub2 = RpmRubros.rbcodi
            //    AND(RpmArticulo.arterc LIKE '%lca-394%'OR RpmFamilias.fadesc LIKE '%cilindro%' OR RpmFamilias.fadesc LIKE '%147%')
            //   AND(RpmFamilias.fadesc LIKE '%lca-394%' OR RpmFamilias.fadesc LIKE '%cilindro%' OR RpmFamilias.fadesc LIKE '%147%')
            //  AND(RpmFamilias.fadesc LIKE '%lca-394%' OR RpmArticulo.ardesc LIKE '%cilindro%' or  RpmArticulo.ardesc LIKE '%147%')




            if (conditionalParams != null)
        {
            foreach (myQueryParameter param in conditionalParams)
            {
                sqlQueryBuilder.Append(String.Format(" AND `{0}` = @{0}", param.paramValue));
                
            }
        }

        
            var data = new DataSet();

            if (OpenConnection())
            {

            using (var MySqlCmd = new MySqlCommand(sqlQueryBuilder.ToString(), connection))
            {
                if (conditionalParams != null)
                {
                    foreach (myQueryParameter condition in conditionalParams)
                    {
                        MySqlCmd.Parameters.Add(String.Format("@{0}",condition.paramValue),condition.paramType).Value = condition.paramValue; 
                    }
                }
                using (var Adapter = new MySqlDataAdapter(MySqlCmd))
                {
                    Adapter.Fill(data);
                    }
                }
            }
            grid.DataSource = data.Tables[0];
    }



        public void cargarGrid(DataGridView grid, string sql,string tabla)
        {

            if (OpenConnection())
            {
                MySqlDataAdapter da_res = null;
                DataSet ds_res = null;
                ds_res = new DataSet();
                da_res = new MySqlDataAdapter(sql, connection);
                da_res.Fill(ds_res, tabla);

                grid.DataSource = ds_res.Tables[0];

            }

            CloseConnection();
        }

        public void cargarTablaListaProveedores(DataGridView grid, string sql)
        {

            if (OpenConnection())
            {
                MySqlDataAdapter da_res = null;
                DataSet ds_res = null;
                ds_res = new DataSet(); 
                da_res = new MySqlDataAdapter(sql, connection);
                da_res.Fill(ds_res, "ListaProveedores");

                grid.DataSource = ds_res.Tables[0];

            }

            CloseConnection();
        }


        public void cargarTabla(DataGridView grid, int idprov)
        {

            if (OpenConnection())
            {
                MySqlDataAdapter da_res = null;
                DataSet ds_res = null;
                ds_res = new DataSet();
                da_res = new MySqlDataAdapter("SELECT * FROM ListasProveedores WHERE idProv = " + idprov.ToString() + " AND descrip LIKE 'OPTICA%TAUNUS%'", connection);
                da_res.Fill(ds_res, "ListasProveedores");

                grid.DataSource = ds_res.Tables[0];

            }

            CloseConnection();
        }


        public void cargarArticulosDelVisoTrans(DataGridView grid)
        {
            const int col_id = 0;
            const int col_auto = 1;
            const int col_codprov = 2;
            const int col_codprov2 = 3;
            const int col_descrip = 4;
            const int col_precio = 5;


            grid.Columns.Add("auto", "auto");
            grid.Columns.Add("codProv", "codProv");
            grid.Columns.Add("codProv2", "codProv2");
            grid.Columns.Add("descrip", "descrip");
            grid.Columns.Add("precio", "precio");


            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT Column4 AS posicion, (SELECT TRIM(Column1) FROM PreciosMetdelViso " +
                                                    "WHERE column2 IS NULL and column4 < posicion ORDER BY column4 desc LIMIT 1) AS auto, " +
                                                    "Column1 AS codprov, Column4 AS codprov2, Column2 AS descrip, Column3 AS precio " +
                                                     "FROM PreciosMetdelViso WHERE column2 IS NOT NULL and Column4 > 1", connection);

                cmd.CommandTimeout = 100;
                MySqlDataReader read = cmd.ExecuteReader();
                
                while (read.Read())
                {
                    
                        grid.Rows.Add(
                            //read.GetValue(col_id).ToString().Trim(),
                            read.GetValue(col_auto).ToString().Trim(),
                            read.GetValue(col_codprov).ToString().Trim(),
                            read.GetValue(col_codprov2).ToString().Trim(),
                            read.GetValue(col_descrip).ToString().Trim(),
                            read.GetValue(col_precio).ToString().Trim());
                    

                }

                CloseConnection();

            }

            grid.Sort(grid.Columns["codProv"], System.ComponentModel.ListSortDirection.Descending);
        }



        public void cargarArticulosOtero(DataGridView grid)
        {
            const int col_auto = 1;
            const int col_rubro = 2;
            const int col_codProv = 3;
            const int col_codProv2 = 4;
            const int col_descrip = 5;
            const int col_precio = 6;

            grid.Columns.Add("auto", "auto");
            grid.Columns.Add("rubro", "rubro");
            grid.Columns.Add("codProv", "codProv");
            grid.Columns.Add("codProv2", "codProv2");
            grid.Columns.Add("descrip", "descrip");
            grid.Columns.Add("precio", "precio");


            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT id AS posicion, SUBSTRING_INDEX((SELECT TRIM(Codigo) FROM Autopartes_Otero_Lista_Precios " +
                                        "WHERE descrip IS NULL and id < posicion ORDER BY id desc LIMIT 1), '......', 1) AS auto, " +
                                         " SUBSTRING_INDEX((SELECT TRIM(Codigo) FROM Autopartes_Otero_Lista_Precios " +
                                        "WHERE descrip IS NULL and id < posicion ORDER BY id desc LIMIT 1), '......', -1) AS rubro, " +
                                        "Codigo AS codprov, id AS codprov2, descrip AS descrip, precio AS precio " +
                                          "FROM Autopartes_Otero_Lista_Precios WHERE descrip IS NOT NULL and id > 1", connection);

                cmd.CommandTimeout = int.MaxValue;
                MySqlDataReader read = cmd.ExecuteReader(  );

                while (read.Read())
                {
                    
                        grid.Rows.Add(
                            read.GetValue(col_auto).ToString().Trim(),
                            read.GetValue(col_rubro).ToString().Trim(),
                            read.GetValue(col_codProv).ToString().Trim(),
                            read.GetValue(col_codProv2).ToString().Trim(),
                            read.GetValue(col_descrip).ToString().Trim(), 
                            read.GetValue(col_precio).ToString().Trim()) ;
                    }

                }

                CloseConnection();

            //grid.Sort(grid.Columns["codProv"], System.ComponentModel.ListSortDirection.Descending);
        }

        

        public void cargarArticulosChriva(DataGridView grid)
        {
            const int col_codProv = 0;
            const int col_codProv2 = 1;
            const int col_auto = 2;
            const int col_descrip = 3;
            const int col_precio = 4;

            grid.Columns.Add("codProv", "codProv");
            grid.Columns.Add("codProv2", "codProv2");
            grid.Columns.Add("auto", "auto");
            grid.Columns.Add("descrip", "descrip");
            grid.Columns.Add("precio", "precio");


            if (OpenConnection())
            {

                MySqlCommand cmd = new MySqlCommand("SELECT idPos AS codprov, Column2 AS codprov2, " +
  "(SELECT column5 FROM ListaInicialChriva WHERE Column2 IS NULL AND Column3 IS NULL AND Column5 IS NOT null AND idPos < codprov " +
    "ORDER BY idPos desc LIMIT 1) AS auto, Column3 AS descrip, Column8 AS precio " +
  "FROM ListaInicialChriva WHERE Column2 IS NOT NULL AND Column3 IS NOT null", connection);

                MySqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {

                    grid.Rows.Add(
                        read.GetValue(col_codProv).ToString().Trim(),
                        read.GetValue(col_codProv2).ToString().Trim(),
                        read.GetValue(col_auto).ToString().Trim(),
                        read.GetValue(col_descrip).ToString().Trim(),
                        read.GetValue(col_precio).ToString().Trim());
                }

                CloseConnection();

            }

        }


        public void cargarArticulosfarosDam(DataGridView grid)
        {
            //const int col_rubro = 2;
            const int col_codProv2 = 0;
            const int col_auto = 1;
            const int col_codProv = 2;
            const int col_cantCaja = 3;
            const int col_descrip = 4;
            const int col_precio = 5;

            grid.Columns.Add("auto", "auto");
            grid.Columns.Add("codigo", "codigo");
            grid.Columns.Add("CodProv2", "CodProv2");
            grid.Columns.Add("cantCaja", "cantCaja");
            grid.Columns.Add("descrip", "descrip");
            grid.Columns.Add("precio", "precio");


            if (OpenConnection())
            {

                MySqlCommand cmd = new MySqlCommand("SELECT column5 AS posicion, (SELECT Column3 FROM farosDam WHERE Column1 IS NULL and Column2 IS NULL AND Column3 IS NOT NULL and " +
                           " column5 < posicion ORDER BY column5 desc LIMIT 1) AS descrip, Column1 AS codigo, Column2 AS cantCaja, Column3 AS descrip, Column4 AS precio " +
                          " FROM farosDam WHERE column5 > 12 AND Column2 IS not NULL AND Column3 IS not NULL ", connection);
                MySqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {

                    grid.Rows.Add(
                        read.GetValue(col_auto).ToString().Trim(),
                        read.GetValue(col_codProv).ToString().Trim(),
                        read.GetValue(col_codProv2).ToString().Trim(),
                        read.GetValue(col_cantCaja).ToString().Trim(),
                        read.GetValue(col_descrip).ToString().Trim(),
                        read.GetValue(col_precio).ToString().Trim());
                }

                CloseConnection();

            }

            grid.Sort(grid.Columns[0], System.ComponentModel.ListSortDirection.Descending);
        }



        public void cargarArticulosSanFernet(DataGridView grid)
        {
            //const int col_rubro = 2;
            //const int col_codProv2 = 4;
            const int col_codProv = 0;
            const int col_marca = 1;
            const int col_auto = 2;
            const int col_descrip = 3;
            const int col_precio = 4;

            grid.Columns.Add("codProv", "codProv");
            grid.Columns.Add("marca", "marca");
            grid.Columns.Add("auto", "auto");
            grid.Columns.Add("descrip", "descrip");
            grid.Columns.Add("precio", "precio");


            if (OpenConnection())
            {

                MySqlCommand cmd = new MySqlCommand("SELECT id as posicion, (SELECT TRIM(Column1) FROM SanFernet " +
                                                    "WHERE LENGTH(TRIM(Column1)) > 3 AND LENGTH(TRIM(Column1)) < 20 " +
                                                    "AND id < posicion ORDER BY id desc  LIMIT 1) AS marca, " +
                                                    "TRIM(SUBSTRING_INDEX(Column1, '     ', 1)) AS auto, " +
                                                    "SUBSTRING_INDEX(TRIM(SUBSTRING_INDEX(Column1, '     ', 8)), '     ', -1) AS descrip, " +
                                                    "REPLACE(SUBSTRING_INDEX(TRIM(SUBSTRING_INDEX(TRIM(Column1), '    ', -1)),'.',1),'$','') AS precio " + 
                                                    "FROM SanFernet WHERE LENGTH(TRIM(Column1)) > 80", connection);

                MySqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {

                    grid.Rows.Add(
                        read.GetValue(col_codProv).ToString().Trim(),
                        read.GetValue(col_marca).ToString().Trim(),
                        read.GetValue(col_auto).ToString().Trim(),
                        read.GetValue(col_descrip).ToString().Trim(),
                        read.GetValue(col_precio).ToString().Trim());
                }

            CloseConnection();

            }

            grid.Sort(grid.Columns["codProv"], System.ComponentModel.ListSortDirection.Descending);
        }


        public void cargarArticulosProveedor(DataGridView grid, ComboBox combo)
        {

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT  idProv, codProv, codProv2, marca, auto,descrip,rubro,fabricante,codFabricante,imagen,unidadxBulto,stockOrigen " +
                                                    "from ListasProveedores where idProv = " + combo.SelectedValue + " and activo = 1 LIMIT 20", connection);

                MySqlDataReader read = cmd.ExecuteReader();

                grid.Columns.Add("idProv", "idProv");
                grid.Columns.Add("codProv", "codProv");
                grid.Columns.Add("codProv2", "codProv2");
                grid.Columns.Add("marca", "marca");
                grid.Columns.Add("auto", "auto");
                grid.Columns.Add("descrip", "descrip");
                grid.Columns.Add("rubro", "rubro");
                grid.Columns.Add("fabricante", "fabricante");
                grid.Columns.Add("codFabricante", "codFabricante");
                grid.Columns.Add("imagen", "imagen");
                grid.Columns.Add("unidadxBulto", "unidadxBulto");
                grid.Columns.Add("stockOrigen", "stockOrigen");

                DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();

                cmb.HeaderText = "COMBOS";
                cmb.Name = "cmb";
                cmb.MaxDropDownItems = 4;
                cmb.Items.Add("CASO1");
                cmb.Items.Add("CASO2");
                grid.Columns.Add(cmb);

                while (read.Read())
                {

                    grid.Rows.Add(read.GetValue(0), read.GetValue(1), read.GetValue(2), read.GetValue(3), read.GetValue(4), read.GetValue(5), read.GetValue(6),
                                  read.GetValue(7), read.GetValue(8), read.GetValue(9), read.GetValue(10), read.GetValue(11));

                }
            }
            CloseConnection();
        }


        public void cargarColumnaExiste(DataGridView grid, ComboBox combo, string query)
        {

            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            col.HeaderText = "EXISTE";
            grid.Columns.Add(col);

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (Convert.ToInt64(row.Cells[0].Value) == read.GetInt64(0))
                        { row.Cells[col.Index].Value = true; break; }

                    }


                }

            }
            CloseConnection();
        }


       


        public void consultaInsertar(string query)
        {

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();
                
            }

            CloseConnection();
        }

    }


        

    }
