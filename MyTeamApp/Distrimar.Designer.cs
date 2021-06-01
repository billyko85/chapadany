using System;
using System.Windows.Forms;

namespace MyTeamApp
{
    partial class Distrimar
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
            this.Bar = new System.Windows.Forms.ProgressBar();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dataGridEmpList = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.empConstantsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmpList)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empConstantsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Bar);
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
            // 
            // Bar
            // 
            this.Bar.Location = new System.Drawing.Point(16, 119);
            this.Bar.Name = "Bar";
            this.Bar.Size = new System.Drawing.Size(1163, 42);
            this.Bar.TabIndex = 13;
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
            this.dataGridEmpList.Location = new System.Drawing.Point(17, 164);
            this.dataGridEmpList.Name = "dataGridEmpList";
            this.dataGridEmpList.RowHeadersWidth = 50;
            this.dataGridEmpList.Size = new System.Drawing.Size(1163, 266);
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
            // 
            // empConstantsBindingSource
            // 
            this.empConstantsBindingSource.DataSource = typeof(MyTeamApp.EmpConstants);
            // 
            // Distrimar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 522);
            this.Controls.Add(this.tabControl1);
            this.Name = "Distrimar";
            this.Text = "Carga de Archivos Proveedores";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.DataGridView dataGridEmpList;
        private System.Windows.Forms.TabControl tabControl1;
        private ProgressBar Bar;
    }
}

