﻿namespace MyTeamApp
{
    partial class Rpm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.baseRPM2DataSet = new MyTeamApp.BaseRPM2DataSet();
            this.baseRPM2DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.proveedoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.proveedoTableAdapter = new MyTeamApp.BaseRPM2DataSetTableAdapters.proveedoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseRPM2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseRPM2DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.baseRPM2DataSetBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(28, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(952, 382);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cargar de Archivo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(61, 13);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(291, 20);
            this.txtFileName.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(28, 45);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(952, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // baseRPM2DataSet
            // 
            this.baseRPM2DataSet.DataSetName = "BaseRPM2DataSet";
            this.baseRPM2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // baseRPM2DataSetBindingSource
            // 
            this.baseRPM2DataSetBindingSource.DataSource = this.baseRPM2DataSet;
            this.baseRPM2DataSetBindingSource.Position = 0;
            // 
            // proveedoBindingSource
            // 
            this.proveedoBindingSource.DataMember = "proveedo";
            this.proveedoBindingSource.DataSource = this.baseRPM2DataSetBindingSource;
            // 
            // proveedoTableAdapter
            // 
            this.proveedoTableAdapter.ClearBeforeFill = true;
            // 
            // Rpm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 495);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Rpm";
            this.Text = "Rpm";
            this.Load += new System.EventHandler(this.Rpm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseRPM2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseRPM2DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.BindingSource baseRPM2DataSetBindingSource;
        private BaseRPM2DataSet baseRPM2DataSet;
        private System.Windows.Forms.BindingSource proveedoBindingSource;
        private BaseRPM2DataSetTableAdapters.proveedoTableAdapter proveedoTableAdapter;
    }
}