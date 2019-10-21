using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyTeamApp
{
    public partial class MdiFrmMenu : Form
    {
        private int childFormNumber = 0;

        public MdiFrmMenu()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void insertarArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new FrmCromosol();

            f.MdiParent = this;

            f.Show();
        }

        private void MdiFrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void equivalenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formularioEquivalenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Equivalencias();
            f.MdiParent = this;
            f.Show();
        }

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Espejos();
            f.MdiParent = this;
            f.Show();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Otero();
            f.MdiParent = this;
            f.Show();
        }

        private void cargasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new CargasInicial();
            f.MdiParent = this;
            f.Show();
        }

        private void delVisoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void delVisoTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new DelVisoTrans();
            f.MdiParent = this;
            f.Show();

        }

        private void actualizarSanfernetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new SanFernet();
            f.MdiParent = this;
            f.Show();
        }

        private void insertarChrivaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Chriva();
            f.MdiParent = this;
            f.Show();
        }

        private void dAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Dam();
            f.MdiParent = this;
            f.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new CargasVentas();
            f.MdiParent = this;
            f.Show();
        }


        private void castelarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form f = new Castelar();
            f.MdiParent = this;
            f.Show();
        }

        private void distrimarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form f = new Distrimar();
            f.MdiParent = this;
            f.Show();
        }

        private void lamToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form f = new Lam();
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Form f = new Dm_AppWeb();
            f.MdiParent = this;
            f.Show();

        }
    }
}
