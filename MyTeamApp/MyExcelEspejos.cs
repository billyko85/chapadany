using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Excel=Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;

namespace MyTeamApp
{
    public class ListaEspejos
    {

//        codigo nvarchar(50)    Checked
//decripcion  nvarchar(50)    Checked
//marca   nvarchar(50)    Checked
//auto    nvarchar(50)    Checked
//tipo    nchar(10)   Checked
//lado    nchar(10)   Checked
//curvatura   nchar(10)   Checked
//precio  decimal (18, 2)	Checked


        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string auto { get; set; }
        public string tipo { get; set; }
        public string lado { get; set; }
        public string curvatura { get; set; }
        public double precio { get; set; }

        public ListaEspejos()
        {

        }
    }

    class MyExcelEspejos
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

            Type type = typeof(ListaEspejos);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }


         
           
            colum1 = "A"; colum2 = "G";
            ListaEspejos row = new ListaEspejos();
            DataRow values = dataTable.NewRow();


            for (int index = 8; index <= lastRow; index++)
            {
                System.Array MyValues = (System.Array)MySheet.get_Range(colum1 + index.ToString(), colum2 + index.ToString()).Cells.Value;

                if  (MyValues.GetValue(1, 1) == null && MyValues.GetValue(1, 2) == null && MyValues.GetValue(1, 3) != null)
                    row.Marca = MyValues.GetValue(1, 3).ToString().Trim();
                else if (MyValues.GetValue(1, 1) != null && MyValues.GetValue(1, 2) == null && MyValues.GetValue(1, 3) == null)
                 row.Marca = MyValues.GetValue(1, 1).ToString().Trim(); 
                else if (MyValues.GetValue(1, 2) != null)
                {
                    if (MyValues.GetValue(1, 1) != null)
                        row.Codigo = MyValues.GetValue(1, 1).ToString().Trim();

                    row.tipo = MyValues.GetValue(1, 2).ToString().Trim();
                    
                    if (row.tipo == "C/B")
                        row.Descripcion = "VIDRIOS ESPEJOS CON BASE";

                    if (row.tipo == "LU")
                        row.Descripcion = "VIDRIOS ESPEJOS SIN BASE";

                    row.auto = MyValues.GetValue(1, 3).ToString().Trim();//Descrip

                    try { 
                    if (MyValues.GetValue(1, 4) != null)
                        row.precio = Convert.ToDouble(MyValues.GetValue(1, 4));//planoizq
                    }
                    catch(Exception ms)
                    {
                        row.precio = 0;
                    }

                    row.lado = "IZQUIERDO";
                    row.curvatura = "PLANO";

                    values = dataTable.NewRow();
                    for (int i = 0; i < properties.Length; i++)
                    {
                         values[i] = properties[i].GetValue(row);
                    }

                    dataTable.Rows.Add(values);
                    try { 
                        if (MyValues.GetValue(1, 5) != null)
                        row.precio = Convert.ToDouble(MyValues.GetValue(1, 5));//curvoizq
                    }
                        catch (Exception ms)
                    {
                        row.precio = 0;
                    }

                row.lado = "IZQUIERDO";
                    row.curvatura = "CURVO";
            
                    values = dataTable.NewRow();
                    for (int i = 0; i < properties.Length; i++)
                    {
                        values[i] = properties[i].GetValue(row);
                    }

                    dataTable.Rows.Add(values);

                    try
                    {
                     if (MyValues.GetValue(1, 6) != null)
                        row.precio = Convert.ToDouble(MyValues.GetValue(1, 6));//planoDER
                    }
                    catch (Exception ms)
                    {
                        row.precio = 0;
                    }

                row.lado = "DERECHO";
                    row.curvatura = "PLANO";
                   
                    values = dataTable.NewRow();
                    for (int i = 0; i < properties.Length; i++)
                    {
                        values[i] = properties[i].GetValue(row);
                    }

                    dataTable.Rows.Add(values);

                    try
                    {
                        if (MyValues.GetValue(1, 7) != null)
                        row.precio = Convert.ToDouble(MyValues.GetValue(1, 7));//planoDER
                    }
                    catch (Exception ms)
                    {
                       row.precio = 0;
                    }

                   row.lado = "DERECHO";
                    row.curvatura = "CURVO";

                    values = dataTable.NewRow();
                    for (int i = 0; i < properties.Length; i++)
                    {
                        values[i] = properties[i].GetValue(row);
                    }

                    dataTable.Rows.Add(values);

                }
                    

            }
            return dataTable;
        }

        private static DataRow mapearCampos(ListaEspejos row, PropertyInfo[] properties)
        {
            Type type = typeof(ListaEspejos);

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            DataRow values = dataTable.NewRow(); 
            
            //object[] values = new object[properties.Length];
            for (int i = 0; i < properties.Length; i++)
            {
                values[i] = properties[i].GetValue(row);
            }

            return values;
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
