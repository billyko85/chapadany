namespace MyTeamApp
{
    partial class DM
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
            this.labUltimaVersionLista = new System.Windows.Forms.Label();
            this.labUltimaVersionActualizada = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EmpresaBar = new System.Windows.Forms.ProgressBar();
            this.btnInsertarArt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Productos_tipo_Bar = new System.Windows.Forms.ProgressBar();
            this.ProductosLabel = new System.Windows.Forms.Label();
            this.productos_Bar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.productos_Bar, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ProductosLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Productos_tipo_Bar, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.EmpresaBar, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labUltimaVersionLista, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labUltimaVersionActualizada, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(51, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(765, 217);
            this.tableLayoutPanel1.TabIndex = 23;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(376, 34);
            this.label4.TabIndex = 27;
            this.label4.Text = "Ultima Versión Actualizada";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labUltimaVersionLista
            // 
            this.labUltimaVersionLista.AutoSize = true;
            this.labUltimaVersionLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labUltimaVersionLista.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUltimaVersionLista.Location = new System.Drawing.Point(385, 34);
            this.labUltimaVersionLista.Name = "labUltimaVersionLista";
            this.labUltimaVersionLista.Size = new System.Drawing.Size(377, 34);
            this.labUltimaVersionLista.TabIndex = 25;
            this.labUltimaVersionLista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labUltimaVersionActualizada
            // 
            this.labUltimaVersionActualizada.AutoSize = true;
            this.labUltimaVersionActualizada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labUltimaVersionActualizada.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUltimaVersionActualizada.Location = new System.Drawing.Point(385, 0);
            this.labUltimaVersionActualizada.Name = "labUltimaVersionActualizada";
            this.labUltimaVersionActualizada.Size = new System.Drawing.Size(377, 34);
            this.labUltimaVersionActualizada.TabIndex = 24;
            this.labUltimaVersionActualizada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labUltimaVersionActualizada.Click += new System.EventHandler(this.labUltimaVersionActualizada_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(376, 34);
            this.label3.TabIndex = 26;
            this.label3.Text = "Ultima Versión Lista";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmpresaBar
            // 
            this.EmpresaBar.Location = new System.Drawing.Point(385, 71);
            this.EmpresaBar.Name = "EmpresaBar";
            this.EmpresaBar.Size = new System.Drawing.Size(377, 47);
            this.EmpresaBar.TabIndex = 25;
            // 
            // btnInsertarArt
            // 
            this.btnInsertarArt.Location = new System.Drawing.Point(51, 289);
            this.btnInsertarArt.Name = "btnInsertarArt";
            this.btnInsertarArt.Size = new System.Drawing.Size(128, 40);
            this.btnInsertarArt.TabIndex = 26;
            this.btnInsertarArt.Text = "Actualizar / Insertar";
            this.btnInsertarArt.UseVisualStyleBackColor = true;
            this.btnInsertarArt.Click += new System.EventHandler(this.btnInsertarArt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 53);
            this.label1.TabIndex = 28;
            this.label1.Text = "Empresas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(376, 50);
            this.label2.TabIndex = 29;
            this.label2.Text = "Productos_tipo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Productos_tipo_Bar
            // 
            this.Productos_tipo_Bar.Location = new System.Drawing.Point(385, 124);
            this.Productos_tipo_Bar.Name = "Productos_tipo_Bar";
            this.Productos_tipo_Bar.Size = new System.Drawing.Size(377, 44);
            this.Productos_tipo_Bar.TabIndex = 30;
            // 
            // ProductosLabel
            // 
            this.ProductosLabel.AutoSize = true;
            this.ProductosLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductosLabel.Location = new System.Drawing.Point(3, 171);
            this.ProductosLabel.Name = "ProductosLabel";
            this.ProductosLabel.Size = new System.Drawing.Size(376, 50);
            this.ProductosLabel.TabIndex = 31;
            this.ProductosLabel.Text = "Productos";
            this.ProductosLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // productos_Bar
            // 
            this.productos_Bar.Location = new System.Drawing.Point(385, 174);
            this.productos_Bar.Name = "productos_Bar";
            this.productos_Bar.Size = new System.Drawing.Size(377, 44);
            this.productos_Bar.TabIndex = 33;
            // 
            // DM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 426);
            this.Controls.Add(this.btnInsertarArt);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DM";
            this.Text = "DM";
            this.Load += new System.EventHandler(this.DM_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labUltimaVersionLista;
        private System.Windows.Forms.Label labUltimaVersionActualizada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar EmpresaBar;
        private System.Windows.Forms.Button btnInsertarArt;
        private System.Windows.Forms.Label ProductosLabel;
        private System.Windows.Forms.ProgressBar Productos_tipo_Bar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar productos_Bar;
    }
}