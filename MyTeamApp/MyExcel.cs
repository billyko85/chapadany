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
     class MyExcel
    {
        public static string DB_PATH = @"";
        public static BindingList<Lista> EmpList = new BindingList<Lista>();
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


        public static BindingList<Lista> ReadMyExcel()
        {
            string locCod, locDescrip, locPrecio, locAuto, locMarca, colum1, colum2;

            EmpList.Clear();

            for (int times = 1; times <= 1; times++)
            {
                if (times == 1)
                { colum1 = "A"; colum2 = "C"; }
                else
                { colum1 = "E"; colum2 = "G"; }

                locAuto = locMarca = vacio;

                for (int index = 15; index <= lastRow; index++)
                {
                    System.Array MyValues = (System.Array)MySheet.get_Range(colum1 + index.ToString(), colum2 + index.ToString()).Cells.Value;

                    locCod = locDescrip = locPrecio = vacio;

                    if (MyValues.GetValue(1, 2) != null)
                    {
                        locCod = MyValues.GetValue(1, 1).ToString();
                        locDescrip = MyValues.GetValue(1, 2).ToString();
                        locPrecio = MyValues.GetValue(1, 3).ToString();
                    }
                    else
                    {
                        if (MyValues.GetValue(1, 1) != null)
                            locAuto = locMarca = MyValues.GetValue(1, 1).ToString();

                        continue;
                    }

                    if (MyValues.GetValue(1, 2) != null)

                        if (MyValues.GetValue(1, 3) != null)

                            EmpList.Add(new Lista
                            {
                                Cod = locCod,
                                Descrip = locDescrip,
                                Precio = locPrecio,
                                Marca = locMarca,
                                Auto = locAuto,
                            });
                }

            }
            return EmpList;
        }
        
       public static void WriteToExcel(Lista emp)

        {
            try
            {
                lastRow += 1;
                MySheet.Cells[lastRow, 1] = emp.Cod;
                MySheet.Cells[lastRow, 2] = emp.Descrip;
                MySheet.Cells[lastRow, 3] = emp.Precio;
                EmpList.Add(emp);
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
                case "NAME":
                    FilteredList = EmpList.ToList().FindAll(emp => emp.Cod.ToLower().Contains(searchExpr));
                    break;
                case "MOBILE_NO":
                    FilteredList = EmpList.ToList().FindAll(emp => emp.Descrip.ToLower().Contains(searchExpr));
                    break;
                case "Lista_ID":
                    FilteredList = EmpList.ToList().FindAll(emp => emp.Precio.ToLower().Contains(searchExpr));
                    break;
//                case "EMAIL_ID":
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
