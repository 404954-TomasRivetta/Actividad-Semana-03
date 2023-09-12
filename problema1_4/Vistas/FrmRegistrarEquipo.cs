using problema1_4.Dominio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace problema1_4.Vistas
{
    public partial class FrmRegistrarEquipo : Form
    {

        Equipo nuevo;

        public FrmRegistrarEquipo()
        {
            InitializeComponent();

            nuevo = new Equipo();
        }

        private void FrmRegistrarEquipo_Load(object sender, EventArgs e)
        {

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
            if (txtNomEquipo.Text == "")
            {
                MessageBox.Show("Debe ingresar el Nombre del equipo..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtNomDT.Text == "")
            {
                MessageBox.Show("Debe ingresar el Director Tecnico..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string nombreEquipo = Convert.ToString(txtNomEquipo.Text);
            string nombreDT = Convert.ToString(txtNomDT.Text);

            if (AgregarEquipo(nombreEquipo, nombreDT))
            {
                MessageBox.Show("Equipo registrado con exito", "Informe",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("ERROR. No se logro registrar al equipo", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

        }

        private bool AgregarEquipo(string nombreEquipo, string nombreDT)
        {
            bool resultado = true;

            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(@"Data Source=PCCESAR;Initial Catalog=ligaCordobesa;Integrated Security=True");
                conexion.Open();

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "insert into Equipo VALUES (@nombreEquipo,@directorTecnico)";
                comando.Parameters.AddWithValue("@nombreEquipo", nombreEquipo);
                comando.Parameters.AddWithValue("@directorTecnico", nombreDT);
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return resultado;
        }
    }
}
