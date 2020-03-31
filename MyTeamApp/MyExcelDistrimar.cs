using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Excel=Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Windows.Forms;

namespace MyTeamApp
{
    public class ListaDistrimar
    {
        public string Fabrica { get; set; }
        public string Codigo { get; set; }
        public string Descrip { get; set; }
        public string Modelo { get; set; }
        public string Descuento { get; set; }
        public string Precio { get; set; }

        public ListaDistrimar(object _Fabrica, object _Codigo, object _Descrip, object _Modelo,object _Descuento, object _Precio)
        {

            if (_Fabrica != null) { 
                Fabrica = _Fabrica.ToString();
            }
            else
            {
                Fabrica = string.Empty;
            }

            if (_Descuento != null)
            {
                Descuento = _Descuento.ToString();
            }
            else
            {
                Descuento = string.Empty;
            }


            if (_Codigo != null)
            { 
                Codigo = _Codigo.ToString();
            }
            else
            {
                Codigo = string.Empty;
            }

            if (_Descrip != null){
                Descrip = _Descrip.ToString();
          }
            else
            {
                Descrip = string.Empty;
            }

            if (_Modelo != null){
                Modelo = _Modelo.ToString();
          }
            else
            {
                Modelo = string.Empty;
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

    class MyExcelDistrimar
    {
        public static string DB_PATH = @"";
        public static BindingList<ListaDistrimar> EmpList = new BindingList<ListaDistrimar>();
        private static Excel.Workbook MyBook = null;
        private static Excel.Application MyApp = null;
        private static Excel.Worksheet MySheet = null;
        private static int lastRow=0;

        const string vacio = "VACIO";

        public static void InitializeExcel()
        {
            MyApp = new Excel.Application();
            MyApp.Visible = false;
            MyBook = MyApp.Workbooks.Open(DB_PATH);
            MySheet = (Excel.Worksheet)MyBook.Sheets[1]; // Explict cast is not required here
            lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
        }


        public static BindingList<ListaDistrimar> ReadMyExcel()
        {
            string colum1, colum2;

            EmpList.Clear();

                colum1 = "A"; colum2 = "F"; 

                for (int index = 6; index <= lastRow; index++)
                {
                    System.Array MyValues = (System.Array)MySheet.get_Range(colum1 + index.ToString(), colum2 + index.ToString()).Cells.Value;

                EmpList.Add(new ListaDistrimar(MyValues.GetValue(1, 1), 
                                               MyValues.GetValue(1, 2), 
                                               MyValues.GetValue(1, 3), 
                                               MyValues.GetValue(1, 4), 
                                               MyValues.GetValue(1, 6),
                                               MyValues.GetValue(1, 5)));
                }
            return EmpList;

        }
    
        
       public static void WriteToExcel(ListaDistrimar posicion)

        {
          

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
