using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.Cache;
using CapaDatos.Repositorios;

namespace GestionContraseñas
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataEmpleados obj = new DataEmpleados();
            obj.Nombre_e = txtNombre.Text;
            obj.Correo = txtCorreo.Text;
            obj.Direccion = txtDireccion.Text;
            obj.Usuario_e = txtUsuario.Text;
            obj.Contraseña = txtContraseña.Text;
            obj.ID = CacheSoftware.id_Empresa;
            MessageBox.Show(obj.GuardarCambios());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
