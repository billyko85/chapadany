using System;
using System.Windows.Forms;

namespace MyTeamApp
{
    partial class DelViso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.in_rowIndex = new System.Windows.Forms.NumericUpDown();
            this.lab_cod_prov = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lab_nro_version = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFileHeader = new System.Windows.Forms.Panel();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.dateVersion = new System.Windows.Forms.DateTimePicker();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.btnInsertarVersion = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dataGridEmpList = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.empConstantsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.in_rowIndex)).BeginInit();
            this.pnlFileHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmpList)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empConstantsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.in_rowIndex);
            this.tabPage2.Controls.Add(this.lab_cod_prov);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.lab_nro_version);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.pnlFileHeader);
            this.tabPage2.Controls.Add(this.txtFileName);
            this.tabPage2.Controls.Add(this.btnLoad);
            this.tabPage2.Controls.Add(this.dataGridEmpList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1199, 478);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DelViso";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Index de Inicio";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // in_rowIndex
            // 
            this.in_rowIndex.Location = new System.Drawing.Point(120, 124);
            this.in_rowIndex.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.in_rowIndex.Name = "in_rowIndex";
            this.in_rowIndex.Size = new System.Drawing.Size(120, 20);
            this.in_rowIndex.TabIndex = 11;
            this.in_rowIndex.Value = new decimal(new int[] {
            3707,
            0,
            0,
            0});
            // 
            // lab_cod_prov
            // 
            this.lab_cod_prov.AutoSize = true;
            this.lab_cod_prov.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lab_cod_prov.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_cod_prov.Location = new System.Drawing.Point(999, 37);
            this.lab_cod_prov.Name = "lab_cod_prov";
            this.lab_cod_prov.Size = new System.Drawing.Size(64, 46);
            this.lab_cod_prov.TabIndex = 9;
            this.lab_cod_prov.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(983, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "COD PROV";
            // 
            // lab_nro_version
            // 
            this.lab_nro_version.AutoSize = true;
            this.lab_nro_version.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lab_nro_version.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_nro_version.Location = new System.Drawing.Point(999, 114);
            this.lab_nro_version.Name = "lab_nro_version";
            this.lab_nro_version.Size = new System.Drawing.Size(64, 46);
            this.lab_nro_version.TabIndex = 7;
            this.lab_nro_version.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(967, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "NRO VERSIÓN ";
            // 
            // pnlFileHeader
            // 
            this.pnlFileHeader.Controls.Add(this.txtVersion);
            this.pnlFileHeader.Controls.Add(this.dateVersion);
            this.pnlFileHeader.Controls.Add(this.btnActualizar);
            this.pnlFileHeader.Controls.Add(this.progressBar2);
            this.pnlFileHeader.Controls.Add(this.btnInsertarVersion);
            this.pnlFileHeader.Controls.Add(this.btnInsertar);
            this.pnlFileHeader.Controls.Add(this.progressBar1);
            this.pnlFileHeader.Location = new System.Drawing.Point(343, 17);
            this.pnlFileHeader.Name = "pnlFileHeader";
            this.pnlFileHeader.Size = new System.Drawing.Size(541, 147);
            this.pnlFileHeader.TabIndex = 5;
            this.pnlFileHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFileHeader_Paint);
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(18, 13);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(166, 20);
            this.txtVersion.TabIndex = 8;
            // 
            // dateVersion
            // 
            this.dateVersion.Location = new System.Drawing.Point(204, 13);
            this.dateVersion.Name = "dateVersion";
            this.dateVersion.Size = new System.Drawing.Size(200, 20);
            this.dateVersion.TabIndex = 9;
            this.dateVersion.ValueChanged += new System.EventHandler(this.dateVersion_ValueChanged);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(411, 100);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(117, 35);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar Precios";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(18, 107);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(386, 23);
            this.progressBar2.TabIndex = 7;
            // 
            // btnInsertarVersion
            // 
            this.btnInsertarVersion.Location = new System.Drawing.Point(411, 9);
            this.btnInsertarVersion.Name = "btnInsertarVersion";
            this.btnInsertarVersion.Size = new System.Drawing.Size(117, 32);
            this.btnInsertarVersion.TabIndex = 7;
            this.btnInsertarVersion.Text = "Crear Nueva Versión";
            this.btnInsertarVersion.UseVisualStyleBackColor = true;
            this.btnInsertarVersion.Click += new System.EventHandler(this.btnInsertarVersion_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(411, 52);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(117, 36);
            this.btnInsertar.TabIndex = 3;
            this.btnInsertar.Text = "Insertar Nuevos articulos";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 59);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(386, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(16, 41);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(307, 20);
            this.txtFileName.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(16, 75);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click_1);
            // 
            // dataGridEmpList
            // 
            this.dataGridEmpList.AllowUserToOrderColumns = true;
            this.dataGridEmpList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridEmpList.Location = new System.Drawing.Point(16, 181);
            this.dataGridEmpList.Name = "dataGridEmpList";
            this.dataGridEmpList.RowHeadersWidth = 50;
            this.dataGridEmpList.Size = new System.Drawing.Size(1177, 291);
            this.dataGridEmpList.TabIndex = 0;
            this.dataGridEmpList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEmpList_CellContentClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1207, 504);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabPage1_Click);
            // 
            // empConstantsBindingSource
            // 
            this.empConstantsBindingSource.DataSource = typeof(MyTeamApp.EmpConstants);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 522);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Carga de Archivos Proveedores";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.in_rowIndex)).EndInit();
            this.pnlFileHeader.ResumeLayout(false);
            this.pnlFileHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmpList)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.empConstantsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridEmpList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void pnlFileHeader_Paint(object sender, PaintEventArgs e)
        {
            
        }

        #endregion

        private System.Windows.Forms.BindingSource empConstantsBindingSource;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnlFileHeader;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.DataGridView dataGridEmpList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnInsertarVersion;
        private System.Windows.Forms.DateTimePicker dateVersion;
        private System.Windows.Forms.TextBox txtVersion;
        private Button btnActualizar;
        private ProgressBar progressBar2;
        private Label lab_nro_version;
        private Label label1;
        private Label lab_cod_prov;
        private Label label3;
        private Label label2;
        private NumericUpDown in_rowIndex;
    }
}

