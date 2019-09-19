namespace MyTeamApp
{
    partial class Espejos
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
            this.dgEspejos = new System.Windows.Forms.DataGridView();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgEspejos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgEspejos
            // 
            this.dgEspejos.AllowUserToOrderColumns = true;
            this.dgEspejos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgEspejos.Location = new System.Drawing.Point(12, 98);
            this.dgEspejos.Name = "dgEspejos";
            this.dgEspejos.RowHeadersWidth = 50;
            this.dgEspejos.Size = new System.Drawing.Size(776, 319);
            this.dgEspejos.TabIndex = 19;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(6, 15);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(307, 20);
            this.txtFileName.TabIndex = 17;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(6, 50);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 18;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Espejos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgEspejos);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnLoad);
            this.Name = "Espejos";
            this.Text = "Espejos";
            ((System.ComponentModel.ISupportInitialize)(this.dgEspejos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEspejos;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnLoad;
    }
}