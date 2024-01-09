using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Asistencia.Modelo
{
    public class Bases
    {
        public static void DisenioDataView(ref DataGridView Listado)
        {
            Listado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
        }

        public static object Decimal(TextBox inputdecimal, KeyPressEventArgs K)
        {
            if((K.KeyChar ==  '.') || (K.KeyChar == ','))
            {
                K.KeyChar = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

            }
            if(char.IsDigit(K.KeyChar))
            {
                K.Handled = false;
            }
            else if(char.IsControl(K.KeyChar))
            {
                K.Handled = false;
            }
            else if(K.KeyChar == '.' && (~inputdecimal.Text.IndexOf(".")) != 0)
            {
                K.Handled = true;
            }
            else if(K.KeyChar == '.')
            {
                K.Handled = false;
            }
            else if(K.KeyChar == ',') {
                K.Handled = false;
            }
            else
            {
                K.Handled = true;
            }
            return null;
        }
    }
}
