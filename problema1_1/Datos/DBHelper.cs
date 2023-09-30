using problema1_1.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema1_1.Datos
{
    public class DBHelper
    {
        private SqlConnection conexion;

        public DBHelper()
        {
            conexion = new SqlConnection(@"Data Source=PCCESAR;Initial Catalog=carrera_planes_de_estudio;Integrated Security=True");
        }

        public int ProximaCarrera() {

            conexion.Open();

            //creo el comando
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            //que tipo de comando ejecuta
            comando.CommandType = CommandType.StoredProcedure;
            //le paso el nombre del sp a ejecutar
            comando.CommandText = "sp_proximo_id";

            //PARA RECIBIR EL PARAMETRO ª DEFINO EL PARAMETRO
            SqlParameter parametro = new SqlParameter();

            //TIENE QUE LLAMARSE IGUAL QUE EN EL SP
            parametro.ParameterName = "@next";
            parametro.SqlDbType = SqlDbType.Int;
            parametro.Direction = ParameterDirection.Output;

            //añado el parametro al comando
            comando.Parameters.Add(parametro);

            comando.ExecuteNonQuery();

            conexion.Close();

            return (int)parametro.Value;
        }

        public DataTable ConsultarTabla(string nombreSP) {

            conexion.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conexion;

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = nombreSP;

            DataTable dt = new DataTable();

            dt.Load(cmd.ExecuteReader());

            conexion.Close();

            return dt;
        }

        public bool ConfirmarCarrera(Carrera oCarrera)
        {
            bool resultado = true;

            SqlTransaction t = null;

            try
            {
                conexion.Open();

                t = conexion.BeginTransaction();

                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;

                comando.Transaction = t;

                comando.CommandType = CommandType.StoredProcedure;

                comando.CommandText = "sp_insertar_maestro";

                comando.Parameters.AddWithValue("@nombre_carrera", oCarrera.NombreCarrera);
                comando.Parameters.AddWithValue("@titulo", oCarrera.TituloCarrera);

                SqlParameter parametro = new SqlParameter();

                parametro.ParameterName = "@id_carrera";

                parametro.SqlDbType = SqlDbType.Int;

                parametro.Direction = ParameterDirection.Output;

                comando.Parameters.Add(parametro);

                comando.ExecuteNonQuery();

                int idCarrera = (int)parametro.Value;

                int detalleNro = 1;

                SqlCommand cmdDetalle;

                foreach (DetalleCarrera dc in oCarrera.Detalles)
                {
                    cmdDetalle = new SqlCommand("sp_insertar_detalle", conexion,t);

                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                    cmdDetalle.Parameters.AddWithValue("@id_carrera",idCarrera);
                    cmdDetalle.Parameters.AddWithValue("@id_detalle", detalleNro);
                    cmdDetalle.Parameters.AddWithValue("@anioCursado", dc.AnioCursado);
                    cmdDetalle.Parameters.AddWithValue("@cuatrimestre", dc.Cuatrimestre);
                    cmdDetalle.Parameters.AddWithValue("@id_asignatura", dc.Asignatura.CodAsignatura);

                    cmdDetalle.ExecuteNonQuery();

                    detalleNro++;
                }

                t.Commit();
            }
            catch
            {
                t.Rollback();
                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resultado;

        }

        public DataTable ConsultarTabla(string nombreSP, List<Parametro> lstParametros)
        {
            conexion.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = nombreSP;

            foreach (Parametro p in lstParametros)
            {
                comando.Parameters.AddWithValue(p.Nombre, p.Valor);
            }

            DataTable dt = new DataTable();

            dt.Load(comando.ExecuteReader());

            conexion.Close();

            return dt;

        }
    }
}
