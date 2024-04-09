using CapaDatos.Repositorios;
namespace GestionContraseñas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataEmpresa obj = new DataEmpresa();
            bool valido = obj.login(txtUsuario.Text, txtContraseña.Text);
            if (valido)
            {
                Login log = new Login();
                log.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario/Contraseña incorrecto")
            }
        }
    }
}
