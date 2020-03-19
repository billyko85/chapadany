namespace MyTeamApp
{
    partial class ListasExcel
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
            this.dgFal = new System.Windows.Forms.DataGridView();
            this.btnCargar = new System.Windows.Forms.Button();
            this.txtPathFile = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.RadioFal = new System.Windows.Forms.RadioButton();
            this.radioSenesa = new System.Windows.Forms.RadioButton();
            this.rbDelviso = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgFal)).BeginInit();
            this.SuspendLayout();
            // 
            // dgFal
            // 
            this.dgFal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFal.Location = new System.Drawing.Point(12, 146);
            this.dgFal.Name = "dgFal";
            this.dgFal.Size = new System.Drawing.Size(909, 339);
            this.dgFal.TabIndex = 0;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(386, 26);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(75, 23);
            this.btnCargar.TabIndex = 1;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // txtPathFile
            // 
            this.txtPathFile.Location = new System.Drawing.Point(21, 26);
            this.txtPathFile.Name = "txtPathFile";
            this.txtPathFile.Size = new System.Drawing.Size(313, 20);
            this.txtPathFile.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 120);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(909, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // RadioFal
            // 
            this.RadioFal.AutoSize = true;
            this.RadioFal.Location = new System.Drawing.Point(56, 69);
            this.RadioFal.Name = "RadioFal";
            this.RadioFal.Size = new System.Drawing.Size(71, 17);
            this.RadioFal.TabIndex = 4;
            this.RadioFal.TabStop = true;
            this.RadioFal.Text = "Faros Fal ";
            this.RadioFal.UseVisualStyleBackColor = true;
            // 
            // radioSenesa
            // 
            this.radioSenesa.AutoSize = true;
            this.radioSenesa.Location = new System.Drawing.Point(133, 69);
            this.radioSenesa.Name = "radioSenesa";
            this.radioSenesa.Size = new System.Drawing.Size(61, 17);
            this.radioSenesa.TabIndex = 5;
            this.radioSenesa.TabStop = true;
            this.radioSenesa.Text = "Senesa";
            this.radioSenesa.UseVisualStyleBackColor = true;
            // 
            // rbDelviso
            // 
            this.rbDelviso.AutoSize = true;
            this.rbDelviso.Location = new System.Drawing.Point(200, 69);
            this.rbDelviso.Name = "rbDelviso";
            this.rbDelviso.Size = new System.Drawing.Size(60, 17);
            this.rbDelviso.TabIndex = 6;
            this.rbDelviso.TabStop = true;
            this.rbDelviso.Text = "Delviso";
            this.rbDelviso.UseVisualStyleBackColor = true;
            // 
            // ListasExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 500);
            this.Controls.Add(this.rbDelviso);
            this.Controls.Add(this.radioSenesa);
            this.Controls.Add(this.RadioFal);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtPathFile);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.dgFal);
            this.Name = "ListasExcel";
            this.Text = "Faros_Fal";
            ((System.ComponentModel.ISupportInitialize)(this.dgFal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgFal;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.TextBox txtPathFile;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton RadioFal;
        private System.Windows.Forms.RadioButton radioSenesa;
        private System.Windows.Forms.RadioButton rbDelviso;
    }
}