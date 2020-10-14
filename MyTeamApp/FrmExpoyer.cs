using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;


namespace MyTeamApp
{
    public partial class FrmExpoyer : Form
    {
        private Proveedores_SQLSERVER dbConnect;

        public FrmExpoyer()
        {
            InitializeComponent();
            dbConnect = new Proveedores_SQLSERVER();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.InitialDirectory = @"C:\Users\usuario\Desktop\Listas Expoyer";
            Dialog.Title = "Elegir Directorio";

            if (Dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                    txtPathFile.Text = Dialog.FileName;
                    txtPathFile.ReadOnly = true;
                    btnCargar.Enabled = false;

                    string directorio = Dialog.InitialDirectory;

                //string articulos = directorio + "\\articulos_v3.txt";
                //DataTable datosArticulo = ReadText_DataTableArticulos(articulos);
                //dbConnect.InsertarPreciosBulk(datosArticulo, progressBar1, "Expoyer");

                //string marcas = directorio + "\\marcas_principales_v3.txt";
                //DataTable datosMarcas = ReadText_DataTableMarcas(marcas);
                //dbConnect.InsertarPreciosBulk(datosMarcas, progressBar1, "ExpoyerMarcas");

                string rubros = directorio + "\\rubros_v3.txt";
                DataTable datosRubros = ReadText_DataTableRubros(rubros);
                dbConnect.InsertarPreciosBulk(datosRubros, progressBar1, "ExpoyerRubros");

                //dataGridExpoyer.DataSource = datos;
            }
        }

        private static DataTable ReadText_DataTableRubros(string textFile)
        {

            DataTable registros = new DataTable("childTable");
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Codigo";
            registros.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Marca";
            registros.Columns.Add(column);


            string[] lines = File.ReadAllLines(textFile);

            int index = 0;

            foreach (string line in lines)
            {
                index++;
                if (index == 1)
                    continue;

                string[] words = line.Split('|');

                row = registros.NewRow();

                row[0] = words[0];
                row[1] = words[1];

                registros.Rows.Add(row);
            }

            return registros;


        }


        private static DataTable ReadText_DataTableMarcas(string textFile)
        {

            DataTable registros = new DataTable("childTable");
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Codigo";
            registros.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Marca";
            registros.Columns.Add(column);


            string[] lines = File.ReadAllLines(textFile);

            int index = 0;

            foreach (string line in lines)
            {
                index++;
                if (index == 1)
                    continue;

                string[] words = line.Split('|');

                row = registros.NewRow();

                row[0] = words[0];
                row[1] = words[1];

                registros.Rows.Add(row);
            }

            return registros;


        }

        private static DataTable ReadText_DataTableArticulos(string textFile)
        {
                        
            DataTable registros = new DataTable("childTable");
            DataColumn column;
            DataRow row;

            for(int a = 0; a <= 29; a++){ 
                column = new DataColumn();

                if (a == 0){
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "Codigo";
                    registros.Columns.Add(column);
                }else if(a == 4){
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "Descripcion";
                    registros.Columns.Add(column);
                }
                else if (a == 6)
                {
                    column.DataType = System.Type.GetType("System.Double");
                    column.ColumnName = "PrecioLista";
                    registros.Columns.Add(column);
                }else if (a == 8)
                {
                   column.DataType = System.Type.GetType("System.DateTime");
                    column.ColumnName = "Column9";
                    registros.Columns.Add(column);
                }
                else if (a == 12)
                {
                    column.DataType = System.Type.GetType("System.DateTime");
                    column.ColumnName = "Column13";
                    registros.Columns.Add(column);
                }
                else if (a == 18)
                {
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "Descripcion2";
                    registros.Columns.Add(column);
                }
                else if (a == 25)
                {
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "Descripcion3";
                    registros.Columns.Add(column);
                }
                else if (a == 28)
                {
                    column.DataType = System.Type.GetType("System.DateTime");
                    column.ColumnName = "Column29";
                    registros.Columns.Add(column);
                }
                else
                {
                    column.DataType = System.Type.GetType("System.String");
                    //column.ColumnName = "Marca";
                    registros.Columns.Add(column);
                }
            }

            string categoria = string.Empty;

                string[] lines = File.ReadAllLines(textFile);

            int index = 0;

            foreach (string line in lines)
            {
                index++;
                if (index == 1)
                    continue;

                string[] words = line.Split('|');

                row = registros.NewRow();

                if (words.Length < 2)
                    continue;
                for (int a = 0; a <= 29; a++)
                {
                    if (words[a].ToString() == string.Empty || words[a] == ".00" )
                        words[a] = "0";
                    
                    if (words[a].ToString().Trim().Length > 1) { 
                        if (words[a].ToString().Trim()[0] == '.')
                        {
                            words[a] = "0" + words[a].ToString().Trim();
                        }
                    }


                    if (registros.Columns[a].DataType == System.Type.GetType("System.DateTime"))
                    {
                        row[a] = DateTime.Today;
                    }
                    else
                    {
                        row[a] = words[a];

                    }


                }

                registros.Rows.Add(row);
            }

            return registros;

        }
    }
}
