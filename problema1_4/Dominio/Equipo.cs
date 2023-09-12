using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace problema1_4.Dominio
{
    internal class Equipo
    {

        public int EquipoNro { get; set; }
        public string NombreEquipo { get; set; }
        public string DirectorTecnico { get; set; }

        public List<Jugador> Jugadores { get; set; }

        public Equipo()
        {
            Jugadores = new List<Jugador>();
        }

        public void AgregarJugador(Jugador jugador)
        {
            Jugadores.Add(jugador);
        }

        public void QuitarJugador(int posicion)
        {
            Jugadores.RemoveAt(posicion);
        }

        public bool Confirmar(int equipoNro)
        {

            bool resultado = true;

            SqlConnection cnn = new SqlConnection();
            SqlTransaction t = null;

            try
            {
                cnn.ConnectionString = @"Data Source=PCCESAR;Initial Catalog=ligaCordobesa;Integrated Security=True";
                cnn.Open();
                t = cnn.BeginTransaction();

                foreach (Jugador ju in Jugadores)
                {
                    SqlCommand cmdDet = new SqlCommand("sp_insertar_detalle", cnn,t);
                    cmdDet.CommandType = CommandType.StoredProcedure;
                    cmdDet.Parameters.AddWithValue("@dni_persona",ju.Persona.DniPersona);
                    cmdDet.Parameters.AddWithValue("@num_camiseta",ju.NroCamiseta);
                    cmdDet.Parameters.AddWithValue("@id_posicion", ju.Posicion.CodPosicion);
                    cmdDet.Parameters.AddWithValue("@id_equipo", equipoNro);
                    cmdDet.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (Exception)
            {
                t.Rollback();
                resultado = false;
            }
            finally {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            return resultado;
        }
    }
}
