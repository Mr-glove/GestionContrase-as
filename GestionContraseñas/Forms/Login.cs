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

namespace GestionContraseñas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataEmpleados obj = new DataEmpleados();
            bool valido = obj.login(txtUsuario.Text, txtContrseña.Text);
            if(valido)
            {
                Centro cs = new Centro();
                cs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario/Contraseña incorrecto");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro reg = new Registro();
            reg.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Centro cs = new Centro();
            cs.Show();
            this.Hide();
        }
    }
}
