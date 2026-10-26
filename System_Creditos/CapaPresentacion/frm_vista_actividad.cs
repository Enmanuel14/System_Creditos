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
    public partial class frm_vista_actividad : Form
    {
        public frm_vista_actividad()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        public void mostrar()
        {
            this.dataGridView1.DataSource = CN_Actividad.Mostrar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buscar()
        {
            this.dataGridView1.DataSource = CN_Actividad.Buscar(this.txt_buscar.Text);
        }

        private void frm_vista_actividad_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           frm_Deatelle_Actividad frm = frm_Deatelle_Actividad.GetInstancia();
           string par1, par2, par3;
           par1 = Convert.ToString(dataGridView1.CurrentRow.Cells["Id_Actividad"].Value);
           par2 = Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre_Actividad"].Value);
            par3 = Convert.ToString(dataGridView1.CurrentRow.Cells["Tipo"].Value);
           frm.setActividad(par1, par2, par3);
           this.Hide();
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            this.buscar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
