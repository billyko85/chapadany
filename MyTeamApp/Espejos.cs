﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTeamApp
{
    public partial class Espejos : Form
    {

        private espejosSqlServer dbConnect;

        DataTable dt;

        public Espejos()
        {
            InitializeComponent();
            dbConnect = new espejosSqlServer();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ExcelDialog = new OpenFileDialog();
            //            ExcelDialog.Filter = "Excel Files (*.xlsx) | *.xlsx";
            ExcelDialog.InitialDirectory = @"C:\Users\billyko\Downloads";
            ExcelDialog.Title = "Elegir archivo";
            if (ExcelDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MyExcelEspejos.DB_PATH = ExcelDialog.FileName;
                txtFileName.Text = ExcelDialog.FileName;
                txtFileName.ReadOnly = true;
                txtFileName.Click -= btnLoad_Click;
                btnLoad.Enabled = false;
                MyExcelEspejos.InitializeExcel();
                //dataGridEmpList.DataSource = MyExcelDmApp.ReadMyExcel();
                dt = MyExcelEspejos.ReadMyExcel_DataTable();
                dgEspejos.DataSource = dt;
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            DataRow row = dt.Rows[0];

            if (row.ItemArray[4].ToString() == "C/B")
                dbConnect.InsertarEspejosBulk(dt, "C/B");

            if (row.ItemArray[4].ToString() == "LU")
                dbConnect.InsertarEspejosBulk(dt, "LU");

        }
    }
}
    
