﻿using System;
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
    
    class MyExcelGomezTanques
    {
        public static string DB_PATH = @"";
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
            string colum1, colum2, marca;

            DataTable registros = new DataTable("childTable");
            DataColumn column;
            DataRow row;
            object ind = (object)1;

            // Create first column and add to the DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Marca";
            registros.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Codigo";
            registros.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Modelo";
            registros.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Precio";
            registros.Columns.Add(column);


            //EmpList.Clear();

            colum1 = "A"; colum2 = "D";

            marca = string.Empty;

            for (int index = 16; index <= lastRow; index++)
            {
                System.Array MyValues = (System.Array)MySheet.get_Range(colum1 + index.ToString(), colum2 + index.ToString()).Cells.Value;

                string marca;

                if (MyValues.GetValue(1, 1) != null && MyValues.GetValue(1, 2) == null && MyValues.GetValue(1, 3) = null)
                {
                    marca = MyValues.GetValue(1, 1).ToString().Trim();
                }


                if (MyValues.GetValue(1, 1) != null && MyValues.GetValue(1, 2) != null && MyValues.GetValue(1, 4) != null )
                {     
                    row = registros.NewRow();
                    row[0] = marca;
                    row[1] = MyValues.GetValue(1, 1).ToString().Trim();
                    row[2] = MyValues.GetValue(1, 2).ToString().Trim();                    
                    row[3] = MyValues.GetValue(1, 7).ToString().Trim().Replace(".","");

                    registros.Rows.Add(row);
                }

                
            }
            return registros;

        }

        
        
    }
    
}