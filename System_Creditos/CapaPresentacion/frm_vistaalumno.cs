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
    public partial class frm_vistaalumno : Form
    {
        public frm_vistaalumno()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void mostrar()
        {
            this.dataGridView1.DataSource = CN_Alumno.Mostrar();
        }
        private void buscar()
        {
            this.dataGridView1.DataSource = CN_Alumno.Buscar(this.txt_buscar.Text);
        }

        private void frm_vistaalumno_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            this.buscar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frm_Deatelle_Actividad frm = frm_Deatelle_Actividad.GetInstancia();
            string par1, par2, par3;
            par1 = Convert.ToString(dataGridView1.CurrentRow.Cells["Id_Alumno"].Value);
            par2 = Convert.ToString(dataGridView1.CurrentRow.Cells["Carnet"].Value);
            par3 = Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre"].Value);
            frm.setAlumno(par1, par2, par3);
            this.Hide();
        }
    }
}
