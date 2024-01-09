using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Asistencia.Controlador
{
    public class PersonalModel
    {
        public int id_personal { get; set; }
        public String Nombre { get; set; }
        public String Identificacion { get; set; }
        public String Pais { get; set; }
        public int id_cargo { get; set; }
        public double SueldoPorHora { get; set; }
        public String Estado { get; set; }
        public String Codigo { get; set; }
    }
}
