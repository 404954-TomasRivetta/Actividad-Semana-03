using problema1_1.Datos;
using problema1_1.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problema1_1
{
    public partial class FrmNuevoPlanDeEstudio : Form
    {

        Carrera nueva;

        DBHelper gestor;

        public FrmNuevoPlanDeEstudio()
        {
            InitializeComponent();

            nueva = new Carrera();

            gestor = new DBHelper();
        }

        private void FrmNuevoPlanDeEstudio_Load(object sender, EventArgs e)
        {
            lblProximaCarrera.Text = lblProximaCarrera.Text + " " + gestor.ProximaCarrera().ToString();

            txtCarrera.Text = " ";
            txtTitulo.Text = " ";
            txtAnioCursado.Text = " ";
            numCuatrimestre.Value = 0;

            CargarProductos("sp_consultar_asignaturas", cboMateria);
        }

        private void CargarProductos(string nombreSP, ComboBox cbo)
        {
            DataTable tabla = new DataTable();
            tabla = gestor.ConsultarTabla(nombreSP);
            cbo.DataSource = tabla;
            cbo.ValueMember = tabla.Columns[0].ColumnName;
            cbo.DisplayMember = tabla.Columns[1].ColumnName;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro desea cancelar la operacion?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboMateria.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una materia..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtAnioCursado.Text == " ")
            {
                MessageBox.Show("Debe ingresar un año valido..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (numCuatrimestre.Value <= 0 || numCuatrimestre.Value > 2)
            {
                MessageBox.Show("Debe ingresar un cuatrimestre valido..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (DataGridViewRow fila in dgvDetalleCarrera.Rows)
            {
                if (fila.Cells["ColMateria"].Value.ToString().Equals(cboMateria.Text))
                {
                    MessageBox.Show("Esta materia ya fue registrada..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            DataRowView item = (DataRowView)cboMateria.SelectedItem;

            int nro = Convert.ToInt32(item.Row.ItemArray[0]);
            string nom = item.Row.ItemArray[1].ToString();

            Asignatura a = new Asignatura(nro, nom);

            int anioCursado = Convert.ToInt32(txtAnioCursado.Text);
            int numeroCuatrimestre = Convert.ToInt32(numCuatrimestre.Value);

            DetalleCarrera detalle = new DetalleCarrera(a,anioCursado,numeroCuatrimestre);

            nueva.AgregarDetalle(detalle);
            dgvDetalleCarrera.Rows.Add(detalle.Asignatura.CodAsignatura,
                detalle.Asignatura.NombreAsignatura,
                detalle.AnioCursado,
                detalle.Cuatrimestre,
                "Quitar");
        }

        private void dgvDetalleCarrera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleCarrera.CurrentCell.ColumnIndex == 4)
            {
                if (MessageBox.Show("Seguro desea quitar el elemento?","Control",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    nueva.QuitarDetalle(dgvDetalleCarrera.CurrentRow.Index);
                    dgvDetalleCarrera.Rows.RemoveAt(dgvDetalleCarrera.CurrentRow.Index);
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCarrera.Text == " ")
            {
                MessageBox.Show("Debe ingresar una carrera..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtTitulo.Text == " ")
            {
                MessageBox.Show("Debe ingresar un titulo..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GrabarCarrera();
        }

        private void GrabarCarrera()
        {
            nueva.NombreCarrera = txtCarrera.Text;
            nueva.TituloCarrera = txtTitulo.Text;

            if (gestor.ConfirmarCarrera(nueva))
            {
                MessageBox.Show("Se grabo con exito la carrera..",
                "Informe",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Error al registrar la carrera..",
                    "Control",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
