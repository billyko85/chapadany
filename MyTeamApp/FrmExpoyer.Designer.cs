namespace MyTeamApp
{
    partial class FrmExpoyer
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
            this.dataGridExpoyer = new System.Windows.Forms.DataGridView();
            this.txtPathFile = new System.Windows.Forms.TextBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpoyer)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridExpoyer
            // 
            this.dataGridExpoyer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridExpoyer.Location = new System.Drawing.Point(24, 117);
            this.dataGridExpoyer.Name = "dataGridExpoyer";
            this.dataGridExpoyer.Size = new System.Drawing.Size(854, 359);
            this.dataGridExpoyer.TabIndex = 0;
            // 
            // txtPathFile
            // 
            this.txtPathFile.Location = new System.Drawing.Point(24, 40);
            this.txtPathFile.Name = "txtPathFile";
            this.txtPathFile.Size = new System.Drawing.Size(313, 20);
            this.txtPathFile.TabIndex = 4;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(357, 24);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(107, 39);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 88);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(854, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // FrmExpoyer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 488);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtPathFile);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.dataGridExpoyer);
            this.Name = "FrmExpoyer";
            this.Text = "FrmExpoyer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpoyer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridExpoyer;
        private System.Windows.Forms.TextBox txtPathFile;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}