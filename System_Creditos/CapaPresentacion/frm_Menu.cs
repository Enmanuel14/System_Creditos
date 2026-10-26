using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frm_Menu : Form
    {
        public frm_Menu()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_maximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.btn_maximizar.Visible = false;
            this.btn_restaurar.Visible = true;
        }

        private void btn_restaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.btn_maximizar.Visible = true;
            this.btn_restaurar.Visible = false;
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public void AbrirFormHijo(object formhijo)
        {
            if (this.panel_principal.Controls.Count > 0)
            {
                this.panel_principal.Controls.RemoveAt(0);
            }
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel_principal.Controls.Add(fh);
            this.panel_principal.Tag = fh;
            fh.Show();

        }

        private void btn_alumno_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(frm_alumno.GetInstancia());
        }

        private void btn_Actividad_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new frm_Actividad());
        }

        private void btn_detalle_a_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(frm_Deatelle_Actividad.GetInstancia());
        }

        private void panel_lateral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_Menu_Load(object sender, EventArgs e)
        {
            AbrirFormHijo(new Form1());
        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Form1());
            frm_Actividad frm = new frm_Actividad();
            frm_alumno frma = new frm_alumno();
            frm_Deatelle_Actividad frmd = new frm_Deatelle_Actividad(); 
            frma.Close();
            frm.Close();
            frmd.Close();
        }

        private void panel_top_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
