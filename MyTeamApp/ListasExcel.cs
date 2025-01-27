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
    public partial class ListasExcel : Form
    {
        private Proveedores_SQLSERVER dbConnect;

        public ListasExcel()
        {
            InitializeComponent();
            dbConnect = new Proveedores_SQLSERVER();
        }

        
        private void btnCargar_Click(object sender, EventArgs e)
        {
            DataTable datos;
            OpenFileDialog ExcelDialog = new OpenFileDialog();
            //            ExcelDialog.Filter = "Excel Files (*.xlsx) | *.xlsx";
            ExcelDialog.InitialDirectory = @"C:\Users\billyko\Downloads";
            ExcelDialog.Title = "Elegir archivo";
            if (ExcelDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                if (RadioFal.Checked == true)
                {
                    MyExcelFal.DB_PATH = ExcelDialog.FileName;
                    txtPathFile.Text = ExcelDialog.FileName;
                    txtPathFile.ReadOnly = true;
                    btnCargar.Enabled = false;
                    MyExcelFal.InitializeExcel();
                    datos = MyExcelFal.ReadMyExcel_DataTable();
                    dgFal.DataSource = datos;
                    dbConnect.InsertarPreciosBulk(datos, progressBar1, "FarosFal");
                }
                if (radioSenesa.Checked == true)
                {
                    MyExcelSenesa.DB_PATH = ExcelDialog.FileName;

                    txtPathFile.Text = ExcelDialog.FileName;
                    txtPathFile.ReadOnly = true;
                    btnCargar.Enabled = false;
                    MyExcelSenesa.InitializeExcel();
                    datos = MyExcelSenesa.ReadMyExcel_DataTable();
                    dgFal.DataSource = datos;
                    dbConnect.InsertarPreciosBulk(datos, progressBar1, "Senesa");

                }

                if (rbDelviso.Checked == true)
                {
                    MyExcelDelviso.DB_PATH = ExcelDialog.FileName;

                    txtPathFile.Text = ExcelDialog.FileName;
                    txtPathFile.ReadOnly = true;
                    btnCargar.Enabled = false;
                    MyExcelDelviso.InitializeExcel();
                    datos = MyExcelDelviso.ReadMyExcel_DataTable();
                    dgFal.DataSource = datos;
                    dbConnect.InsertarPreciosBulk(datos, progressBar1, "DelvisoExcel");

                }

                if (rbOtero.Checked == true)
                {
                    MyExcelOtero.DB_PATH = ExcelDialog.FileName;

                    txtPathFile.Text = ExcelDialog.FileName;
                    txtPathFile.ReadOnly = true;
                    btnCargar.Enabled = false;
                    MyExcelOtero.InitializeExcel();
                    datos = MyExcelOtero.ReadMyExcel_DataTable();
                    dgFal.DataSource = datos;
                    dbConnect.InsertarPreciosBulk(datos, progressBar1, "Otero");

                }


                if (rbGomez.Checked == true)
                {
                    MyExcelGomezTanques.DB_PATH = ExcelDialog.FileName;

                    txtPathFile.Text = ExcelDialog.FileName;
                    txtPathFile.ReadOnly = true;
                    btnCargar.Enabled = false;
                    MyExcelGomezTanques.InitializeExcel();
                    datos = MyExcelGomezTanques.ReadMyExcel_DataTable();
                    dgFal.DataSource = datos;
                    dbConnect.InsertarPreciosBulk(datos, progressBar1, "TanquesGomezTorralba");

                }

                if (rbCavila.Checked == true)
                {
                    MyExcelCavila.DB_PATH = ExcelDialog.FileName;

                    txtPathFile.Text = ExcelDialog.FileName;
                    txtPathFile.ReadOnly = true;
                    btnCargar.Enabled = false;
                    MyExcelCavila.InitializeExcel();
                    datos = MyExcelCavila.ReadMyExcel_DataTable();
                    dgFal.DataSource = datos;
                    dbConnect.InsertarPreciosBulk(datos, progressBar1, "Cavila");


                }



            }
         }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
