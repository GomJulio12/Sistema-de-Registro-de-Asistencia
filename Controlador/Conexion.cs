using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Sistema_de_Asistencia.Modelo
{
    public class Conexion
    {
        public static string conexion = "Data source=DESKTOP-875SDH9; Initial Catalog=Sistema_Asistencias; Integrated Security=true";
        public static SqlConnection conectar = new SqlConnection(conexion);

        public static void abrir()
        {
            if(conectar.State == ConnectionState.Closed)
            {
                conectar.Open();
            }
        }

        public static void cerrar()
        {
            if(conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}
