using problema1_4.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problema1_4
{
    public partial class FrmRegistrarJugador : Form
    {

        Equipo nuevo;

        public FrmRegistrarJugador()
        {
            InitializeComponent();

            nuevo = new Equipo();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Today.ToString("d");
            cboPersona.SelectedIndex = -1;
            cboPosicion.SelectedIndex = -1;
            cboEquipo.SelectedIndex = -1;
            btnAceptar.Enabled = false;
            CargarPersonas();
            CargarPosiciones();
            CargarEquipos();
            cboEquipo.Enabled = true;
        }

        private void CargarEquipos()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=PCCESAR;Initial Catalog=ligaCordobesa;Integrated Security=True";

            conexion.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;

            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = "sp_consultar_equipo";

            DataTable tabla = new DataTable();

            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            cboEquipo.DataSource = tabla;
            cboEquipo.ValueMember = "id_equipo";
            cboEquipo.DisplayMember = "nombre_equipo";
        }

        private void CargarPosiciones()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=PCCESAR;Initial Catalog=ligaCordobesa;Integrated Security=True";

            conexion.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;

            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = "sp_consultar_posicion";

            DataTable tabla = new DataTable();

            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            cboPosicion.DataSource = tabla;
            cboPosicion.ValueMember = "id_posicion";
            cboPosicion.DisplayMember = "nom_posicion";
        }

        private void CargarPersonas()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=PCCESAR;Initial Catalog=ligaCordobesa;Integrated Security=True";

            conexion.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;

            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = "sp_consultar_persona";

            DataTable tabla = new DataTable();

            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            cboPersona.DataSource = tabla;
            cboPersona.ValueMember = "dni_persona";
            cboPersona.DisplayMember = "nombre_completo";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboPersona.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una persona..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboPosicion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una posicion..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtNroCamiseta.Text) || !int.TryParse(txtNroCamiseta.Text, out _) || Convert.ToInt32(txtNroCamiseta.Text) <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad valida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (DataGridViewRow fila in dgvJugadores.Rows)
            {
                if (fila.Cells["ColJugador"].Value.ToString().Equals(cboPersona.Text))
                {
                    MessageBox.Show("Ya agrego esta persona..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            foreach (DataGridViewRow fila in dgvJugadores.Rows)
            {
                if (fila.Cells["ColNroCamiseta"].Value.ToString().Equals(txtNroCamiseta.Text))
                {
                    MessageBox.Show("Esta ocupado ese Num. De camiseta..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            DataRowView item = (DataRowView)cboPersona.SelectedItem;
            DataRowView posicion = (DataRowView)cboPosicion.SelectedItem;

            int nro = Convert.ToInt32(item.Row.ItemArray[0]);
            string nom = item.Row.ItemArray[1].ToString();
            DateTime fecha = Convert.ToDateTime(item.Row.ItemArray[2]);

            Persona p = new Persona(nro, nom, fecha);

            int nroPos = Convert.ToInt32(posicion.Row.ItemArray[0]);
            string nomPos = posicion.Row.ItemArray[1].ToString();

            int numCamiseta = Convert.ToInt32(txtNroCamiseta.Text);

            Posicion pos = new Posicion(nroPos, nomPos);

            Jugador jugador = new Jugador(p,numCamiseta,pos);

            nuevo.AgregarJugador(jugador);
            dgvJugadores.Rows.Add(
                jugador.Persona.DniPersona,
                jugador.Persona.ToString(),
                jugador.NroCamiseta,
                jugador.Posicion.ToString(),
                "QUITAR"
                );

            btnAceptar.Enabled = true;
            cboEquipo.Enabled = false;
        }

        private void dgvJugadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvJugadores.CurrentCell.ColumnIndex == 4)
            {
                if (MessageBox.Show("Seguro desea quitar el elemento?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    nuevo.QuitarJugador(dgvJugadores.CurrentRow.Index);
                    dgvJugadores.Rows.RemoveAt(dgvJugadores.CurrentRow.Index);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro desea cancelar la operacion?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cboEquipo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un equipo!", "Control",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvJugadores.Rows.Count == 0) {
                MessageBox.Show("Debe ingresar al menos un jugador!","Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            GuardarJugadores();
        }

        private void GuardarJugadores()
        {
            DataRowView equipo = (DataRowView)cboEquipo.SelectedItem;
            int nroEquipo = Convert.ToInt32(equipo.Row.ItemArray[0]);

            if (nuevo.Confirmar(nroEquipo))
            {
                MessageBox.Show("Jugadores registrados", "Informe",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("ERROR. No se lograron registrar jugadores al equipo", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
