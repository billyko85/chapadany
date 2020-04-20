using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using DbfDataReader;

namespace MyTeamApp
{
    public partial class DerEncendido : Form
    {
        public DerEncendido()
        {
            InitializeComponent();
        }

        private static Encoding GetEncoding()
        {
            return Encoding.GetEncoding(1252);
        }

        public Type getNetType(DbfColumnType tipoCol)
        {
            switch (tipoCol)
            {
                case DbfColumnType.Boolean:
                    return typeof(bool);

                case DbfColumnType.Character:
                    return typeof(string);

                case DbfColumnType.Currency:
                    return typeof(decimal);

                case DbfColumnType.Date:
                    return typeof(DateTime);

                case DbfColumnType.DateTime:
                    return typeof(DateTime);

                case DbfColumnType.Double:
                    return typeof(double);

                case DbfColumnType.Float:
                    return typeof(float);

                case DbfColumnType.General:
                    return typeof(string);

                case DbfColumnType.Memo:
                    return typeof(string);

                case DbfColumnType.Number:
                    return typeof(int);

                case DbfColumnType.SignedLong:
                    return typeof(long);

                default:
                    return typeof(string);
            }

        }

        private void cargarArchivo(string FileName, string nombreTablaDer)
        {

            var options = new DbfDataReaderOptions
            {
                SkipDeletedRecords = true
            };

            if (FileName.Length > 0)
            {
                var encoding = GetEncoding();

                using (var dbfTable = new DbfTable(FileName, encoding))
                {
                    DataTable datos = new DataTable();

                    foreach (var dbfColumn in dbfTable.Columns)
                    {
                        datos.Columns.Add(dbfColumn.Name, getNetType(dbfColumn.ColumnType));
                    }

                    var dbfRecord = new DbfRecord(dbfTable);

                    while (dbfTable.Read(dbfRecord))
                    {
                        var values = dbfRecord.Values;

                        DataRow row = datos.NewRow();


                        for (int col = 0; col <= dbfRecord.Values.Count - 1; col++)
                        {
                            if (values[col].GetValue() != null)
                                row[col] = values[col].GetValue();
                        }

                        datos.Rows.Add(row);

                    }

                    Proveedores_SQLSERVER sql = new Proveedores_SQLSERVER();
                    sql.InsertarPreciosBulk(datos, barCastelar, nombreTablaDer);

                }
            }



        }

        public class archivosTablas
        {
            // obviously you find meaningful names of the 2 properties
            public string archivo { get; set; }
            public string tabla { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string directorio = "C:\\DERCLI6\\DATOS\\";

            List<archivosTablas> _items = new List<archivosTablas>();
            _items.Add(new archivosTablas { archivo = "articulos.dbf", tabla = "DerArticulos" });
            _items.Add(new archivosTablas { archivo = "codiprod.dbf", tabla = "DerCodipro" });
            _items.Add(new archivosTablas { archivo = "Equivs.dbf", tabla = "DerEquivs" });
            _items.Add(new archivosTablas { archivo = "subrubros.dbf", tabla = "DerSubrubros" });
            _items.Add(new archivosTablas { archivo = "prov.dbf", tabla = "DerProv" });
            _items.Add(new archivosTablas { archivo = "prov.dbf", tabla = "DerMarcas" });

            foreach (var fi in _items)
            {
                textBox1.Text = fi.archivo;
                cargarArchivo(directorio + fi.archivo, fi.tabla);
            }

           

        }


    }
}
