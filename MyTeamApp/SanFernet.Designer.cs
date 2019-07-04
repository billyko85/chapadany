namespace MyTeamApp
{
    partial class SanFernet
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
            this.btnActualizar = new System.Windows.Forms.Button();
            this.gridOtero = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.labUltimaVersionLista = new System.Windows.Forms.Label();
            this.labUltimaVersionActualizada = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.gridOtero)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(3, 44);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(123, 35);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar  Precios";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridOtero
            // 
            this.gridOtero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOtero.Location = new System.Drawing.Point(31, 166);
            this.gridOtero.Name = "gridOtero";
            this.gridOtero.Size = new System.Drawing.Size(1168, 421);
            this.gridOtero.TabIndex = 2;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(31, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1168, 127);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(852, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 41);
            this.label4.TabIndex = 27;
            this.label4.Text = "Ultima Versión Actualizada";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(3, 3);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(123, 35);
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
            this.labUltimaVersionLista.Location = new System.Drawing.Point(1012, 41);
            this.labUltimaVersionLista.Name = "labUltimaVersionLista";
            this.labUltimaVersionLista.Size = new System.Drawing.Size(153, 41);
            this.labUltimaVersionLista.TabIndex = 25;
            this.labUltimaVersionLista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labUltimaVersionActualizada
            // 
            this.labUltimaVersionActualizada.AutoSize = true;
            this.labUltimaVersionActualizada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labUltimaVersionActualizada.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUltimaVersionActualizada.Location = new System.Drawing.Point(1012, 0);
            this.labUltimaVersionActualizada.Name = "labUltimaVersionActualizada";
            this.labUltimaVersionActualizada.Size = new System.Drawing.Size(153, 41);
            this.labUltimaVersionActualizada.TabIndex = 24;
            this.labUltimaVersionActualizada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(852, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 41);
            this.label3.TabIndex = 26;
            this.label3.Text = "Ultima Versión Lista";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bar
            // 
            this.bar.Location = new System.Drawing.Point(31, 145);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(1168, 15);
            this.bar.TabIndex = 26;
            // 
            // SanFernet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 599);
            this.Controls.Add(this.bar);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.gridOtero);
            this.Name = "SanFernet";
            this.Text = "Otero";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Otero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridOtero)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridView gridOtero;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labUltimaVersionLista;
        private System.Windows.Forms.Label labUltimaVersionActualizada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.ProgressBar bar;
    }
}