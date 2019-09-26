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
    public class ListaDmApp
    {
        public string Origen { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }

        public ListaDmApp(object _Codigo, object _Descripcion, object _Origen,   object _Precio)
        {

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

    class MyExcelDmApp
    {
        public static string DB_PATH = @"";
        public static BindingList<ListaDmApp> EmpList = new BindingList<ListaDmApp>();
        private static Excel.Workbook MyBook = null;
        private static Excel.Application MyApp = null;
        private static Excel.Worksheet MySheet = null;
        private static int lastRow=0;

        const string vacio = "VACIO";

        public static void InitializeExcel()
        {

            try
            { 
                MyApp = new Excel.Application();
                MyApp.Visible = false;
                MyBook = MyApp.Workbooks.Open(DB_PATH);
                MySheet = (Excel.Worksheet)MyBook.Sheets[1]; // Explict cast is not required here
                lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);  }
}


        public static DataTable ReadMyExcel_DataTable()
        {
            string colum1, colum2;

            DataTable registros = new DataTable("childTable");
            DataColumn column;
            DataRow row;
  
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Codigo";
            registros.Columns.Add(column);

            // Create first column and add to the DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Origen";
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

            colum1 = "A"; colum2 = "D";

            for (int index = 4; index <= lastRow; index++)
            {
                System.Array MyValues = (System.Array)MySheet.get_Range(colum1 + index.ToString(), colum2 + index.ToString()).Cells.Value;

                row = registros.NewRow();
                row[0] = MyValues.GetValue(1, 1);
                row[1] = MyValues.GetValue(1, 2);
                row[2] = MyValues.GetValue(1, 3);
                row[3] = MyValues.GetValue(1, 4).ToString().Trim().Replace('.',',');
      
                registros.Rows.Add(row);
            }
            return registros;

        }



        public static BindingList<ListaDmApp> ReadMyExcel()
        {
            string colum1, colum2;

            EmpList.Clear();

                colum1 = "A"; colum2 = "D"; 

                for (int index = 4; index <= lastRow; index++)
                {
                    System.Array MyValues = (System.Array)MySheet.get_Range(colum1 + index.ToString(), colum2 + index.ToString()).Cells.Value;

                EmpList.Add(new ListaDmApp(MyValues.GetValue(1, 1), 
                                               MyValues.GetValue(1, 2), 
                                               MyValues.GetValue(1, 3), 
                                               MyValues.GetValue(1, 4)));
                }
            return EmpList;

        }
    
        
       public static void WriteToExcel(ListaDmApp posicion)

        {
            try
            {
                lastRow += 1;
                //MySheet.Cells[lastRow, 1] = posicion.Fabrica;
                EmpList.Add(posicion);
                MyBook.Save();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);  }

        }

        public static List<Lista> FilterEmpList(string searchValue, string searchExpr)
        {
            List<Lista> FilteredList = new List<Lista>();
            switch (searchValue.ToUpper())
            {
//                case "NAME":
//                    FilteredList = EmpList.ToList().FindAll(emp => emp.Cod.ToLower().Contains(searchExpr));
//                    break;
//                case "MOBILE_NO":
//                    FilteredList = EmpList.ToList().FindAll(emp => emp.Descrip.ToLower().Contains(searchExpr));
//                    break;
//                case "Lista_ID":
//                    FilteredList = EmpList.ToList().FindAll(emp => emp.Precio.ToLower().Contains(searchExpr));
//                    break;
////                case "EMAIL_ID":
//                    FilteredList = EmpList.ToList().FindAll(emp => emp.Email_ID.ToLower().Contains(searchExpr));
//                    break;
                default:
                    break;
            }
            return FilteredList;
        }
        public static void CloseExcel()
        {
            MyBook.Saved = true;
            MyApp.Quit();

        }
        
    }
    
}
