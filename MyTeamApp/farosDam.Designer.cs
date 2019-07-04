namespace MyTeamApp
{
    partial class farosDam
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.labUltimaVersionLista = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.labUltimaVersionActualizada = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bar = new System.Windows.Forms.ProgressBar();
            this.gridDam = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDam)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInsertar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labUltimaVersionLista, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnActualizar, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labUltimaVersionActualizada, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(908, 121);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(592, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 39);
            this.label4.TabIndex = 27;
            this.label4.Text = "Ultima Versión Actualizada";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(3, 3);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(123, 33);
            this.btnInsertar.TabIndex = 24;
            this.btnInsertar.Text = "Insertar Articulos";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // labUltimaVersionLista
            // 
            this.labUltimaVersionLista.AutoSize = true;
            this.labUltimaVersionLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labUltimaVersionLista.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUltimaVersionLista.Location = new System.Drawing.Point(752, 39);
            this.labUltimaVersionLista.Name = "labUltimaVersionLista";
            this.labUltimaVersionLista.Size = new System.Drawing.Size(153, 39);
            this.labUltimaVersionLista.TabIndex = 25;
            this.labUltimaVersionLista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(3, 42);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(123, 33);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar  Precios";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // labUltimaVersionActualizada
            // 
            this.labUltimaVersionActualizada.AutoSize = true;
            this.labUltimaVersionActualizada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labUltimaVersionActualizada.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUltimaVersionActualizada.Location = new System.Drawing.Point(752, 0);
            this.labUltimaVersionActualizada.Name = "labUltimaVersionActualizada";
            this.labUltimaVersionActualizada.Size = new System.Drawing.Size(153, 39);
            this.labUltimaVersionActualizada.TabIndex = 24;
            this.labUltimaVersionActualizada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(592, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 39);
            this.label3.TabIndex = 26;
            this.label3.Text = "Ultima Versión Lista";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bar
            // 
            this.bar.Location = new System.Drawing.Point(23, 139);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(908, 15);
            this.bar.TabIndex = 28;
            // 
            // gridDam
            // 
            this.gridDam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDam.Location = new System.Drawing.Point(23, 160);
            this.gridDam.Name = "gridDam";
            this.gridDam.Size = new System.Drawing.Size(908, 320);
            this.gridDam.TabIndex = 27;
            // 
            // farosDam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 532);
            this.Controls.Add(this.bar);
            this.Controls.Add(this.gridDam);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "farosDam";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.farosDam_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Label labUltimaVersionLista;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label labUltimaVersionActualizada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar bar;
        private System.Windows.Forms.DataGridView gridDam;
    }
}