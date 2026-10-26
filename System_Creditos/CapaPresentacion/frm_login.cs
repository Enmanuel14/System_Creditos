using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        private void frm_login_Load(object sender, EventArgs e)
        {
           
            
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
           
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable Datos = CapaNegocio.NTrabajador.Login(this.txt_user.Text, this.txt_contraseña.Text);
            //Evaluar si existe el Usuario
            if (Datos.Rows.Count == 0)
            {
                MessageBox.Show("No Tiene Acceso al Sistema", "System Creditos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frm_Menu frm = new frm_Menu();
                /*frm.Idtrabajador = Datos.Rows[0][0].ToString();
                frm.Apellidos = Datos.Rows[0][1].ToString();
                frm.Nombre = Datos.Rows[0][2].ToString();
                frm.Acceso = Datos.Rows[0][3].ToString();*/
                MessageBox.Show("Bienvenido al Sistema \n" + Datos.Rows[0][1].ToString() + " " + Datos.Rows[0][2].ToString(), "System Creditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm.Show();
                this.Hide();

            }
        }

        private void txt_user_Enter(object sender, EventArgs e)
        {
            if(txt_user.Text == "USUARIO")
            {
                txt_user.Text = "";
            }
        }

        private void txt_user_Leave(object sender, EventArgs e)
        {
            if(txt_user.Text == "")
            {
                txt_user.Text = "USUARIO";
            }
        }

        private void txt_contraseña_Enter(object sender, EventArgs e)
        {
            if (txt_contraseña.Text == "CONTRASEÑA")
            {
                txt_contraseña.Text = "";
                txt_contraseña.UseSystemPasswordChar = true;
            }
        }

        private void txt_contraseña_Leave(object sender, EventArgs e)
        {
            if (txt_contraseña.Text == "")
            {
                txt_contraseña.Text = "CONTRASEÑA";
                txt_contraseña.UseSystemPasswordChar = false;
            }
        }
    }
}
