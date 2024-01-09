using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_Asistencia.Modelo;
using Sistema_de_Asistencia.Controlador;
using System.Drawing.Text;

namespace Sistema_de_Asistencia.Presentacion
{
    public partial class Personal : UserControl
    {
        public Personal()
        {
            InitializeComponent();
        }

        int idCargo;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Boton Agregar Personal
        private void button1_Click(object sender, EventArgs e)
        {
            panel_cargo.Visible = false;
            panel_Paginado.Visible = false;
            panel_registroPersonal.Visible = true;
            panel_registroPersonal.Dock = DockStyle.Fill;
            btn_AgregarPersonal.Visible = true;
            btn_GuardarCambiosPersonal.Visible = false;
            LocalizarDataTableViewCargos();
            limpiar();
        }

        private void LocalizarDataTableViewCargos()
        {
            DataEscogerCargo.Location = new Point(363, 188);
            DataEscogerCargo.Size = new Size(183, 99);
            DataEscogerCargo.Visible = true;
            panel_GuardadoPersonal.Visible = false;
            label_SueldoXHora.Visible = false;
            input_Sueldo.Visible = false;
        }

        private void limpiar()
        {
            input_Nombres.Clear();
            input_Identificacion.Clear();
            input_Cargo.Clear();
            input_Sueldo.Clear();
            MostrarCargos();
        }

        private void btn_AgregarCargo_Click(object sender, EventArgs e)
        {

            panel_cargo.Visible = true;
            panel_cargo.Dock = DockStyle.Fill;
            panel_Paginado.Visible = false;
            panel_registroPersonal.Visible = false;
            btn_AgregarCargo.Visible = true;
            btn_GuardarCambiosCargo.Visible = false;
            btn_MostrarTodos.Visible = false;
            input_nuevoCargo.Clear();
            input_NuevoSueldoxHora.Clear();
        }

        private void btn_GuardarPersonal_Click(object sender, EventArgs e)
        {

        }

   

        private void InsertarPersonal()
        {
            PersonalModel parametros = new PersonalModel();
            PersonalController funcion = new PersonalController();
            parametros.Nombre = input_Nombres.Text;
            parametros.Identificacion = input_Identificacion.Text;
            parametros.Pais = cbx_Pais.Text;
            parametros.id_cargo = idCargo;
            parametros.SueldoPorHora = Convert.ToDouble(input_Sueldo.Text);

        }

        private void InsertarCargos()
        {
            if (!string.IsNullOrEmpty(input_nuevoCargo.Text))
            {
                if (!string.IsNullOrEmpty(input_NuevoSueldoxHora.Text))
                {
                    CargoModel parametros = new CargoModel();
                    CargoController funcion = new CargoController();
                    parametros.Cargo = input_nuevoCargo.Text;
                    parametros.SueldoporHora = Convert.ToDouble(input_NuevoSueldoxHora.Text);
                    if (funcion.InsertarCargo(parametros) == true)
                    {
                        input_Cargo.Clear();
                        MostrarCargos();
                        panel_cargo.Visible = false;
                    }
                }
                else { MessageBox.Show("¡Por favor!, Ingresa un Sueldo del Cargo", "Por favor llena todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            }
            else { MessageBox.Show("¡Por favor!, Ingresa un Nuevo Cargo", "Por favor llena todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            
        }

        private void MostrarCargos()
        {
            DataTable dt = new DataTable();
            CargoController funcion = new CargoController();
            funcion.BuscarCargo(ref dt, input_Cargo.Text);
            DataListadoCargos.DataSource = dt;
            DataEscogerCargo.DataSource = dt;
            Bases.DisenioDataView(ref DataEscogerCargo);
            Bases.DisenioDataView(ref DataListadoCargos);
            DataEscogerCargo.Columns[1].Visible = false;
            DataEscogerCargo.Columns[3].Visible = false;
            DataEscogerCargo.Visible = true;
        }

        private void input_Cargo_TextChanged(object sender, EventArgs e)
        {
            MostrarCargos();
        }

        private void btn_GuardarCargo_Click(object sender, EventArgs e)
        {
            InsertarCargos();
        }

        private void input_nuevoCargo_TextChanged(object sender, EventArgs e)
        {

        }

        private void input_NuevoSueldoxHora_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void input_NuevoSueldoxHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Decimal(input_NuevoSueldoxHora, e);
        }

        private void input_Sueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Decimal(input_Sueldo, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataListadoCargos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataEscogerCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == DataEscogerCargo.Columns["EditarCa"].Index)
            {
                ObtenerCargosEditar();
            }
            if(e.ColumnIndex == DataEscogerCargo.Columns["Cargo"].Index)
            {
                ObtenerDatosCargos();
            }
        }

        private void ObtenerDatosCargos()
        {
            idCargo = Convert.ToInt32(DataEscogerCargo.SelectedCells[1].Value);
            input_Cargo.Text = DataEscogerCargo.SelectedCells[2].Value.ToString();
            input_Sueldo.Text = DataEscogerCargo.SelectedCells[3].Value.ToString();
            DataEscogerCargo.Visible = false;
            label_SueldoXHora.Visible = true;
            input_Sueldo.Visible = true;
            panel_GuardadoPersonal.Visible = true;


        }
        
        private void ObtenerCargosEditar()
        {
            idCargo = Convert.ToInt32(DataEscogerCargo.SelectedCells[1].Value);
            input_nuevoCargo.Text = DataEscogerCargo.SelectedCells[2].Value.ToString();
            input_NuevoSueldoxHora.Text = DataEscogerCargo.SelectedCells[3].Value.ToString();
            btn_GuardarCargo.Visible = false;
            btn_GuardarCambiosCargo.Visible = true;
            input_nuevoCargo.Focus();
            input_nuevoCargo.SelectAll();
            panel_cargo.Visible = true;
            panel_cargo.Dock = DockStyle.Fill;
            panel_cargo.BringToFront();
        }

        private void btn_ReturnPersonal_Click(object sender, EventArgs e)
        {
            panel_registroPersonal.Visible = false;
        }

        private void btn_returnCargos_Click(object sender, EventArgs e)
        {
            panel_cargo.Visible=false;
        }

        private void btn_GuardarCambiosCargo_Click(object sender, EventArgs e)
        {
            Editar_Cargos();
        }

        private void Editar_Cargos()
        {
            CargoModel parametros = new CargoModel();
            CargoController funcion = new CargoController();
            parametros.id_cargo = idCargo;
            parametros.Cargo = input_nuevoCargo.Text;
            parametros.SueldoporHora = Convert.ToDouble(input_NuevoSueldoxHora.Text);
            if(funcion.EditarCargo(parametros) == true) {
                input_Cargo.Clear();
                MostrarCargos();
                panel_cargo.Visible = false;

            }

        }
    }
}
