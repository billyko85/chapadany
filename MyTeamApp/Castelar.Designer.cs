﻿namespace MyTeamApp
{
    partial class Castelar
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
            this.grdDBF = new System.Windows.Forms.DataGridView();
            this.btnLoadDBF = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.barCastelar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.grdDBF)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDBF
            // 
            this.grdDBF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDBF.Location = new System.Drawing.Point(12, 95);
            this.grdDBF.Name = "grdDBF";
            this.grdDBF.Size = new System.Drawing.Size(905, 385);
            this.grdDBF.TabIndex = 0;
            // 
            // btnLoadDBF
            // 
            this.btnLoadDBF.Location = new System.Drawing.Point(802, 24);
            this.btnLoadDBF.Name = "btnLoadDBF";
            this.btnLoadDBF.Size = new System.Drawing.Size(115, 35);
            this.btnLoadDBF.TabIndex = 1;
            this.btnLoadDBF.Text = "Cargar";
            this.btnLoadDBF.UseVisualStyleBackColor = true;
            this.btnLoadDBF.Click += new System.EventHandler(this.btnLoadDBF_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Insertar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // barCastelar
            // 
            this.barCastelar.Location = new System.Drawing.Point(12, 67);
            this.barCastelar.Name = "barCastelar";
            this.barCastelar.Size = new System.Drawing.Size(905, 23);
            this.barCastelar.TabIndex = 3;
            // 
            // Castelar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 492);
            this.Controls.Add(this.barCastelar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLoadDBF);
            this.Controls.Add(this.grdDBF);
            this.Name = "Castelar";
            this.Text = "Castelar";
            ((System.ComponentModel.ISupportInitialize)(this.grdDBF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDBF;
        private System.Windows.Forms.Button btnLoadDBF;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar barCastelar;
    }
}