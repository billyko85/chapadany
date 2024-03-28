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
            this.rbOtero = new System.Windows.Forms.RadioButton();
            this.rbGomez = new System.Windows.Forms.RadioButton();
            this.rbVovchuck = new System.Windows.Forms.RadioButton();
            this.rbCavila = new System.Windows.Forms.RadioButton();
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
            // rbOtero
            // 
            this.rbOtero.AutoSize = true;
            this.rbOtero.Location = new System.Drawing.Point(267, 69);
            this.rbOtero.Name = "rbOtero";
            this.rbOtero.Size = new System.Drawing.Size(60, 17);
            this.rbOtero.TabIndex = 7;
            this.rbOtero.TabStop = true;
            this.rbOtero.Text = "rbOtero";
            this.rbOtero.UseVisualStyleBackColor = true;
            // 
            // rbGomez
            // 
            this.rbGomez.AutoSize = true;
            this.rbGomez.Location = new System.Drawing.Point(333, 69);
            this.rbGomez.Name = "rbGomez";
            this.rbGomez.Size = new System.Drawing.Size(97, 17);
            this.rbGomez.TabIndex = 8;
            this.rbGomez.TabStop = true;
            this.rbGomez.Text = "GomezTorralba";
            this.rbGomez.UseVisualStyleBackColor = true;
            // 
            // rbVovchuck
            // 
            this.rbVovchuck.AutoSize = true;
            this.rbVovchuck.Location = new System.Drawing.Point(436, 69);
            this.rbVovchuck.Name = "rbVovchuck";
            this.rbVovchuck.Size = new System.Drawing.Size(74, 17);
            this.rbVovchuck.TabIndex = 9;
            this.rbVovchuck.TabStop = true;
            this.rbVovchuck.Text = "Vovchuck";
            this.rbVovchuck.UseVisualStyleBackColor = true;
            // 
            // rbCavila
            // 
            this.rbCavila.AutoSize = true;
            this.rbCavila.Location = new System.Drawing.Point(516, 69);
            this.rbCavila.Name = "rbCavila";
            this.rbCavila.Size = new System.Drawing.Size(54, 17);
            this.rbCavila.TabIndex = 10;
            this.rbCavila.TabStop = true;
            this.rbCavila.Text = "Cavila";
            this.rbCavila.UseVisualStyleBackColor = true;
            this.rbCavila.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // ListasExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 500);
            this.Controls.Add(this.rbCavila);
            this.Controls.Add(this.rbVovchuck);
            this.Controls.Add(this.rbGomez);
            this.Controls.Add(this.rbOtero);
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
        private System.Windows.Forms.RadioButton rbOtero;
        private System.Windows.Forms.RadioButton rbGomez;
        private System.Windows.Forms.RadioButton rbVovchuck;
        private System.Windows.Forms.RadioButton rbCavila;
    }
}