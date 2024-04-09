using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionContraseñas.Forms
{
    public partial class VerificarContraseña : Form
    {
        public VerificarContraseña()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Centro.password = txtContreseña.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Centro.password = "";
            this.Close ();
        }
    }
}
