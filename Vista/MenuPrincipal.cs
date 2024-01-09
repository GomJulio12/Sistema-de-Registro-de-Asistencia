using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Asistencia.Presentacion
{
    public partial class Menu_Principal : Form
    {
        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Menu_Principal_Load(object sender, EventArgs e)
        {
            panel_bienvenida.Dock = DockStyle.Fill;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Personal_Click(object sender, EventArgs e)
        {
            Panel_Principal.Controls.Clear();
            Personal control = new Personal();
            control.Dock = DockStyle.Fill;
            Panel_Principal.Controls.Add(control);
            btn_Personal.BackColor = SystemColors.ActiveCaption;

        }
    }
}
