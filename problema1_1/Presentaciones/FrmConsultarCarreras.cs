using problema1_1.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problema1_1.Presentaciones
{
    public partial class FrmConsultarCarreras : Form
    {
        public FrmConsultarCarreras()
        {
            InitializeComponent();

            txtNomCarrera.Text = string.Empty;
            txtTitulo.Text = string.Empty;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            List<Parametro> lista = new List<Parametro>();

            lista.Add(new Parametro("@nombre_carrera", txtNomCarrera.Text));
            lista.Add(new Parametro("@titulo", txtTitulo.Text));

            DataTable tabla = new DBHelper().ConsultarTabla("sp_carrera_filtro", lista);
            dgvCarrera.Rows.Clear();
            foreach (DataRow fila in tabla.Rows)
            {
                dgvCarrera.Rows.Add(new object[]
                {
                    fila["id_carrera"].ToString(),
                    fila["id_carrera"].ToString(),
                    fila["nombre_carrera"].ToString(),
                    fila["titulo"].ToString()
                });
            }

            txtNomCarrera.Text = string.Empty;
            txtTitulo.Text = string.Empty;

        }
    }
}
