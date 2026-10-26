using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frm_vista_carrera : Form
    {
        public frm_vista_carrera()
        {
            InitializeComponent();
        }
        public void Mostrar()
        {
            this.dataGridView1.DataSource = CN_Carrera.Mostrar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_vista_carrera_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frm_alumno frm = frm_alumno.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataGridView1.CurrentRow.Cells[0].Value);
            par2 = Convert.ToString(this.dataGridView1.CurrentRow.Cells[1].Value);
            frm.setCarrera(par1, par2);
            this.Hide();
        }
    }
}
