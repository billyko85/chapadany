using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Excel=Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MyTeamApp
{
    public class ListaFal
    {
        public string Marca { get; set; }
        public string Categoria  { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }

        public ListaFal(object _Marca, object _Categoria, object _Codigo, object _Descripcion, object _Precio)
        {

            if (_Marca != null)
            {
                Marca = _Marca.ToString();
            }
            else
            {
                Marca = string.Empty;
            }

            if (_Categoria != null)
            {
                Categoria = _Categoria.ToString();
            }
            else
            {
                Categoria = string.Empty;
            }

            if (_Codigo != null)
            { 
                Codigo = _Codigo.ToString();
            }
            else
            {
                Codigo = string.Empty;
            }

            if (_Descripcion != null){
                Descripcion = _Descripcion.ToString();
            }
            else
            {
                Descripcion = string.Empty;
            }

            if(_Precio != null){
                Precio = _Precio.ToString();
          }
            else
            {
                Precio = string.Empty;
            }

        }
    }

    class MyExcelFal
    {
        public static string DB_PATH = @"";
        public static BindingList<ListaDmApp> EmpList = new BindingList<ListaDmApp>();
        private static Excel.Workbook MyBook = null;
        private static Excel.Application MyApp = null;
        
        const string vacio = "VACIO";

        public static void InitializeExcel()
        {

            try
            { 
                MyApp = new Excel.Application();
                MyApp.Visible = false;
                MyBook = MyApp.Workbooks.Open(DB_PATH);
             
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);  }
}


        public static DataTable ReadMyExcel_DataTable()
        {
            string colum1, colum2;

        //         public string Marca { get; set; }
        //public string Categoria { get; set; }
        //public string Codigo { get; set; }
        //public string Descripcion { get; set; }
        //public string Precio { get; set; }


        DataTable registros = new DataTable("childTable");
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Marca";
            registros.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Categoria";
            registros.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Codigo";
            registros.Columns.Add(column);
               
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Descripcion";
            registros.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Precio";
            registros.Columns.Add(column);

            //EmpList.Clear();

            for (int sheet = 2; sheet <  11; sheet++)
            {
        
                Excel.Worksheet MySheet = (Excel.Worksheet)MyBook.Sheets[sheet]; // Explict cast is not required here

                string marca = MySheet.Name;
                int lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;


                colum1 = "A"; colum2 = "E";

                for (int index = 5; index <= lastRow; index++)
                {
                    System.Array MyValues = (System.Array)MySheet.get_Range(colum1 + index.ToString(), colum2 + index.ToString()).Cells.Value;

                    string columA = MyValues.GetValue(1, 0) != null ? MyValues.GetValue(1, 0).ToString().Trim() : string.Empty;
                    string columB = MyValues.GetValue(1, 1) != null ? MyValues.GetValue(1, 1).ToString().Trim() : string.Empty;
                    string columC = MyValues.GetValue(1, 2) != null ? MyValues.GetValue(1, 2).ToString().Trim() : string.Empty;
                    string columD = MyValues.GetValue(1, 3) != null ? MyValues.GetValue(1, 3).ToString().Trim() : string.Empty;
                    E

                    if ()
                    
                    row = registros.NewRow();
                    row[0] = marca;
                    row[1] = MyValues.GetValue(1, 0) != null ? MyValues.GetValue(1, 1).ToString().Trim() : string.Empty;
                    row[1] = MyValues.GetValue(1, 2) != null ? MyValues.GetValue(1, 2).ToString().Trim() : string.Empty;
                    row[2] = MyValues.GetValue(1, 3) != null ? MyValues.GetValue(1, 3).ToString().Trim() : string.Empty;

                    //row[3] = MyValues.GetValue(1, 4).ToString().Trim().Replace('.',',');
      
                    registros.Rows.Add(row);
                }

            }

            return registros;

        }



        
    }
    
}
