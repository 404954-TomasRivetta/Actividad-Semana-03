using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problema1_4.Vistas
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void registrarJugadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarJugador nuevoJugador = new FrmRegistrarJugador();
            nuevoJugador.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro desea salir?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void equipoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarEquipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarEquipo nuevoEquipo = new FrmRegistrarEquipo();
            nuevoEquipo.ShowDialog();
        }
    }
}
