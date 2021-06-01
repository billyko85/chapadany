namespace MyTeamApp
{
    partial class ActualizarDelViso
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtPathFile = new System.Windows.Forms.TextBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.dgFal = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgFal)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(28, 87);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(909, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // txtPathFile
            // 
            this.txtPathFile.Location = new System.Drawing.Point(12, 15);
            this.txtPathFile.Name = "txtPathFile";
            this.txtPathFile.Size = new System.Drawing.Size(313, 20);
            this.txtPathFile.TabIndex = 13;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(414, 35);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(75, 23);
            this.btnCargar.TabIndex = 12;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // dgFal
            // 
            this.dgFal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFal.Location = new System.Drawing.Point(28, 116);
            this.dgFal.Name = "dgFal";
            this.dgFal.Size = new System.Drawing.Size(909, 339);
            this.dgFal.TabIndex = 11;
            // 
            // ActualizarDelViso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 488);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtPathFile);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.dgFal);
            this.Name = "ActualizarDelViso";
            this.Text = "ActualizarDelViso";
            ((System.ComponentModel.ISupportInitialize)(this.dgFal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtPathFile;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.DataGridView dgFal;
    }
}