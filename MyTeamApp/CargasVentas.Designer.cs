namespace MyTeamApp
{
    partial class CargasVentas
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
            this.dataGridBusqueda = new System.Windows.Forms.DataGridView();
            this.textBusqueda = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridBusqueda
            // 
            this.dataGridBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBusqueda.Location = new System.Drawing.Point(23, 67);
            this.dataGridBusqueda.Name = "dataGridBusqueda";
            this.dataGridBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridBusqueda.Size = new System.Drawing.Size(974, 406);
            this.dataGridBusqueda.TabIndex = 33;
            // 
            // textBusqueda
            // 
            this.textBusqueda.Location = new System.Drawing.Point(23, 23);
            this.textBusqueda.Name = "textBusqueda";
            this.textBusqueda.Size = new System.Drawing.Size(565, 20);
            this.textBusqueda.TabIndex = 34;
            this.textBusqueda.TextChanged += new System.EventHandler(this.textBusqueda_TextChanged);
            this.textBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBusqueda_KeyDown);
            // 
            // CargasVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 502);
            this.Controls.Add(this.textBusqueda);
            this.Controls.Add(this.dataGridBusqueda);
            this.Name = "CargasVentas";
            this.Text = "Cargas Ventas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridBusqueda;
        private System.Windows.Forms.TextBox textBusqueda;
    }
}