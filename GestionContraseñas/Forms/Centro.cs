using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.Repositorios;
using CapaDatos.Cache;
using GestionContraseñas.Forms;

namespace GestionContraseñas
{
    public partial class Centro : Form
    {
        DataSitios sitios = new DataSitios();
        DataEmpleados obj = new DataEmpleados();
        public static string password;
        public Centro()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ContraseñaCorrecta())
            {
                sitios.estado = Valores.Editar;
                sitios.ID_Sitio = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                txtCorreo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                panel1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sitios.Nombre_S = txtCorreo.Text;
            sitios.Contraseña_s = txtContraseña.Text;
            sitios.Descripcion = txtDescripcion.Text;
            sitios.ID_empleado = CacheSoftware.id_usuario;
            MessageBox.Show(sitios.GuardarCambios());
            Limpiar();
            VerTabla();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (ContraseñaCorrecta())
            {
                sitios.estado = Valores.Eliminar;
                sitios.ID_Sitio = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                MessageBox.Show(sitios.GuardarCambios());
                password = ""
            }
        }


        private void Limpiar()
        {
            txtCorreo.Clear();
            txtContraseña.Clear();
            txtDescripcion.Clear();
            panel1.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sitios.estado = Valores.Agregar;
            panel1.Enabled = true;
        }

        private void VerTabla()
        {
            dataGridView1.DataSource = sitios.VerSitios();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int id_sitio = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            if (ContraseñaCorrecta())
            {
                MessageBox.Show("Tu contraseña es: \n " + sitios.DevolverContraseña(id_sitio));
            }

        }
        public bool ContraseñaCorrecta()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Form vc = new VerificarContraseña();
                vc.ShowDialog();
                if (obj.login(CacheSoftware.usuario, password))
                {
                    MessageBox.Show("Contraseña verificada");
                }
                else
                {
                    MessageBox.Show("Contraseña Incorrecta");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Selecciona unafilacompleta");
                return false;
            }
        }
    }
}
