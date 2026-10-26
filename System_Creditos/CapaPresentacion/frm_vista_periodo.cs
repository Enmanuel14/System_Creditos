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
    public partial class frm_vista_periodo : Form
    {
        public frm_vista_periodo()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Mostrar()
        {
            this.dataGridView1.DataSource = CN_Periodo.Mostrar();
        }

        private void frm_vista_periodo_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frm_Deatelle_Actividad frm = frm_Deatelle_Actividad.GetInstancia();
            string par1, par2, par3;
            par1 = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            par2 = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            //par3 = Convert.ToString(dataGridView1.CurrentRow.Cells["Tipo"].Value);
            frm.setPeriodo(par1, par2);
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
