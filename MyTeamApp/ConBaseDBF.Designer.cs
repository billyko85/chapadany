﻿namespace MyTeamApp
{
    partial class ConBaseDBF
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
            this.barCastelar = new System.Windows.Forms.ProgressBar();
            this.btnLoadDBF = new System.Windows.Forms.Button();
            this.grdDBF = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdDBF)).BeginInit();
            this.SuspendLayout();
            // 
            // barCastelar
            // 
            this.barCastelar.Location = new System.Drawing.Point(32, 57);
            this.barCastelar.Name = "barCastelar";
            this.barCastelar.Size = new System.Drawing.Size(905, 23);
            this.barCastelar.TabIndex = 6;
            // 
            // btnLoadDBF
            // 
            this.btnLoadDBF.Location = new System.Drawing.Point(822, 14);
            this.btnLoadDBF.Name = "btnLoadDBF";
            this.btnLoadDBF.Size = new System.Drawing.Size(115, 35);
            this.btnLoadDBF.TabIndex = 5;
            this.btnLoadDBF.Text = "Cargar";
            this.btnLoadDBF.UseVisualStyleBackColor = true;
            // 
            // grdDBF
            // 
            this.grdDBF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDBF.Location = new System.Drawing.Point(32, 85);
            this.grdDBF.Name = "grdDBF";
            this.grdDBF.Size = new System.Drawing.Size(905, 385);
            this.grdDBF.TabIndex = 4;
            // 
            // ConBaseDBF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 485);
            this.Controls.Add(this.barCastelar);
            this.Controls.Add(this.btnLoadDBF);
            this.Controls.Add(this.grdDBF);
            this.Name = "ConBaseDBF";
            this.Text = "ConBaseDBF";
            ((System.ComponentModel.ISupportInitialize)(this.grdDBF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar barCastelar;
        private System.Windows.Forms.Button btnLoadDBF;
        private System.Windows.Forms.DataGridView grdDBF;
    }
}