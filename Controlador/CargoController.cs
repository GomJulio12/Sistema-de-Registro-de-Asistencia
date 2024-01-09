using Sistema_de_Asistencia.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Asistencia.Controlador
{
    public class CargoController
    {
        public bool InsertarCargo (CargoModel Parametros)
        {
			try
			{
				Conexion.abrir();
				SqlCommand cmd = new SqlCommand("InsertarCargo", Conexion.conectar);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Cargo", Parametros.Cargo);
				cmd.Parameters.AddWithValue("@SueldoporHora", Parametros.SueldoporHora);
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
			finally
			{
				Conexion.cerrar();
			}
        }

        public bool EditarCargo(CargoModel Parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarCargo", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", Parametros.id_cargo);
                cmd.Parameters.AddWithValue("@Cargo", Parametros.Cargo);
                cmd.Parameters.AddWithValue("@SueldoporHora", Parametros.SueldoporHora);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }

        public void BuscarCargo(ref DataTable dt, string buscador)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter data = new SqlDataAdapter("BuscarCargo", Conexion.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@Buscador", buscador);
                data.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
