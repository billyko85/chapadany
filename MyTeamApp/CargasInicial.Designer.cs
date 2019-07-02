namespace MyTeamApp
{
    partial class CargasInicial
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnInsertarArt = new System.Windows.Forms.Button();
            this.txtCodProd = new System.Windows.Forms.TextBox();
            this.txtMDB = new System.Windows.Forms.TextBox();
            this.cromosolBar = new System.Windows.Forms.ProgressBar();
            this.dataGridVB = new System.Windows.Forms.DataGridView();
            this.comboProveedores = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridProveedores = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.41495F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.079646F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.357916F));
            this.tableLayoutPanel1.Controls.Add(this.btnInsertarArt, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCodProd, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMDB, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1017, 60);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // btnInsertarArt
            // 
            this.btnInsertarArt.Location = new System.Drawing.Point(341, 3);
            this.btnInsertarArt.Name = "btnInsertarArt";
            this.btnInsertarArt.Size = new System.Drawing.Size(109, 38);
            this.btnInsertarArt.TabIndex = 0;
            this.btnInsertarArt.Text = "Buscar";
            this.btnInsertarArt.Click += new System.EventHandler(this.btnInsertarArt_Click);
            // 
            // txtCodProd
            // 
            this.txtCodProd.Location = new System.Drawing.Point(172, 3);
            this.txtCodProd.Name = "txtCodProd";
            this.txtCodProd.Size = new System.Drawing.Size(149, 20);
            this.txtCodProd.TabIndex = 27;
            // 
            // txtMDB
            // 
            this.txtMDB.Location = new System.Drawing.Point(510, 3);
            this.txtMDB.Name = "txtMDB";
            this.txtMDB.Size = new System.Drawing.Size(266, 20);
            this.txtMDB.TabIndex = 28;
            this.txtMDB.Text = "C:\\Users\\billyko\\Drive ChapaDany\\Listas\\db1.mdb";
            // 
            // cromosolBar
            // 
            this.cromosolBar.Location = new System.Drawing.Point(12, 320);
            this.cromosolBar.Name = "cromosolBar";
            this.cromosolBar.Size = new System.Drawing.Size(1058, 24);
            this.cromosolBar.TabIndex = 25;
            this.cromosolBar.Click += new System.EventHandler(this.cromosolBar_Click);
            // 
            // dataGridVB
            // 
            this.dataGridVB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVB.Location = new System.Drawing.Point(12, 353);
            this.dataGridVB.Name = "dataGridVB";
            this.dataGridVB.Size = new System.Drawing.Size(1058, 155);
            this.dataGridVB.TabIndex = 24;
            // 
            // comboProveedores
            // 
            this.comboProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboProveedores.FormattingEnabled = true;
            this.comboProveedores.Location = new System.Drawing.Point(1103, 133);
            this.comboProveedores.Name = "comboProveedores";
            this.comboProveedores.Size = new System.Drawing.Size(160, 21);
            this.comboProveedores.TabIndex = 26;
            this.comboProveedores.SelectedIndexChanged += new System.EventHandler(this.comboProveedores_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1103, 178);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 49);
            this.button3.TabIndex = 30;
            this.button3.Text = "Insertar Compras";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridProveedores
            // 
            this.dataGridProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProveedores.Location = new System.Drawing.Point(12, 133);
            this.dataGridProveedores.Name = "dataGridProveedores";
            this.dataGridProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProveedores.Size = new System.Drawing.Size(1058, 178);
            this.dataGridProveedores.TabIndex = 32;
            this.dataGridProveedores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProveedores_CellContentClick);
            // 
            // CargasInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 646);
            this.Controls.Add(this.dataGridProveedores);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboProveedores);
            this.Controls.Add(this.cromosolBar);
            this.Controls.Add(this.dataGridVB);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CargasInicial";
            this.Text = "Carga Inicial";
            this.Load += new System.EventHandler(this.CargasInicial_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ProgressBar cromosolBar;
        private System.Windows.Forms.DataGridView dataGridVB;
        private System.Windows.Forms.Button btnInsertarArt;
        private System.Windows.Forms.TextBox txtCodProd;
        private System.Windows.Forms.TextBox txtMDB;
        private System.Windows.Forms.ComboBox comboProveedores;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridProveedores;
    }
}