using CapaNegocio;
using Entidades;
using System;
using System.IO;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
         


        }
        C_Entidades dates = new C_Entidades();
        Negocio metodo = new Negocio();


        private void classBtn2_Click(object sender, System.EventArgs e)
        {
            dates.Nombre = txt_nombre.Text.ToUpper();
            dates.Apellido = txt_apellido.Text.ToUpper();
            dates.Cedula = txt_cedula.Text.ToUpper();
            dates.Telefono = txt_telefono.Text.ToUpper();
            dates.Direccion = txt_direcion.Text.ToUpper();
            dates.Ciudad = txt_ciudad.Text.ToUpper();
            metodo.Insert(dates);
            MessageBox.Show("Agregados exitosamente", "Informacion");
            mostrarTabla("");
            clear();
             
        }
        private void clear()
        {
            txt_apellido.Text = "";
            txt_cedula.Text = "";
            txt_ciudad.Text = "";
            txt_direcion.Text="";
            txt_nombre.Text = "";
            txt_telefono.Text="";


        }
        public void mostrarTabla(string buscar)
        {
           
            Tabla.DataSource = metodo.listando(buscar);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            mostrarTabla("");
        }
        public void MostrarBusqueda(string buscar)
        {
            Tabla.DataSource = metodo.listando(buscar);







        }

        private void text_buscar_TextChanged(object sender, System.EventArgs e)
        {
            MostrarBusqueda(txt_buscar.Text);
        }

        private void label13_Click(object sender, System.EventArgs e)
        {

        }

        private void classBtn3_Click(object sender, System.EventArgs e)
        {
            if (Tabla.SelectedRows.Count > 0)
            {
                dates.Id = Convert.ToInt32(Tabla.CurrentRow.Cells[0].Value.ToString());
                metodo.Eliminando(dates);
                MessageBox.Show("Registro Eliminado");
                mostrarTabla("");

            }
            else
            {
                MessageBox.Show("Ha ocurrido un Error", "Informacion");
            }
        }
    }
}
