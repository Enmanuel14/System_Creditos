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
    public partial class frm_Actividad : Form
    {
        public frm_Actividad()
        {
            InitializeComponent();
        }
        bool isNuevo = false;
        bool isEditar = false;

        public void mostrar()
        {
            this.dataGridView1.DataSource = CN_Actividad.Mostrar();
        }
        private void buscar()
        {
            this.dataGridView1.DataSource = CN_Actividad.Buscar(this.txt_buscar.Text);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "System Creditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "System Creditos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Limpiar()
        {
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
            this.txt_lugar.Text = string.Empty;
            this.txt_nombre_ac.Text = string.Empty;
            this.txt_id.Text = string.Empty;
            this.textBox1.Text = string.Empty;
            //this.comboBox1.Text = "...";
        }
        private void Habilitar(bool valor)
        {
            this.txt_lugar.ReadOnly = !valor;
            this.txt_nombre_ac.ReadOnly = !valor;
            this.dateTimePicker1.Enabled = valor;
            this.dateTimePicker2.Enabled = valor;
        }
        private void Botones()
        {
            if (this.isNuevo || this.isEditar)
            {
                this.Habilitar(true);
                this.btn_nuevo.Enabled = false;
                this.btn_guardar.Enabled = true;
                this.btn_Editar.Enabled = false;
                this.btn_cancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btn_nuevo.Enabled = true;
                this.btn_guardar.Enabled = false;
                this.btn_Editar.Enabled = true;
                this.btn_cancelar.Enabled = false;
            }
        }

        private void frm_Actividad_Load(object sender, EventArgs e)
        {
            this.mostrar();
            this.Habilitar(false);
            this.Botones();
            //creditos();
           
           
        }
        public void creditos()
        {
            string[,] creditos = new string[18, 2];
            
            creditos[0, 0] = "Participación en ferias organizadas por la universidad.";
            creditos[0, 1] = "N° C. = 1";

            
            creditos[1, 0] = "Presentación de proyectos de emprendimiento.";
            creditos[1, 1] = "N° C. = 3";

            
            creditos[2, 0] = "Participación en ferias científicas.";
            creditos[2, 1] = "N° C. = 1";

            
            creditos[3, 0] = "Promoción de la Universidad.";
            creditos[3, 1] = "N° C. = 1";

            
            creditos[4, 0] = "Participación en charlas, seminarios, cursos organizados o no por la Universidad.";
            creditos[4, 1] = "N° C. = 1";

            
            creditos[5, 0] = "Deportes o cultura.";
            creditos[5, 1] = "N° C. = 2";

            
            creditos[6, 0] = "Proyección Social (Jornadas de salud, mas sociales).";
            creditos[6, 1] = "N° C. = 2";

            
            creditos[7, 0] = "Promoción de carreras.";
            creditos[7, 1] = "N° C. = 2";

            
            creditos[8, 0] = "Atención en biblioteca.";
            creditos[8, 1] = "N° C. = 2";

            
            creditos[9, 0] = "Soporte a Dirección de Campus.";
            creditos[9, 1] = "N° C. = 2";

            
            creditos[10, 0] = "Programa Movimiento Alumno Ayudante.";
            creditos[10, 1] = "N° C. = 2";

            
            creditos[11, 0] = "Voluntariado UCN.";
            creditos[11, 1] = "N° C. = 2";

           
            creditos[12, 0] = "Edecanes.";
            creditos[12, 1] = "N° C. = 2";

            
            creditos[13, 0] = "Organización de eventos científicos.";
            creditos[13, 1] = "N° C. = 2";

            
            creditos[14, 0] = "Organización de eventos culturales.";
            creditos[14, 1] = "N° C. = 2";

            
            creditos[15, 0] = "Organización de eventos verdes.";
            creditos[15, 1] = "N° C. = 2";

           
            creditos[16, 0] = "Participación en el curso de inducción.";
            creditos[16, 1] = "N° C. = 2";

            
            creditos[17, 0] = "Participar en eventos, verdes, culturales o científicos.";
            creditos[17, 1] = "N° C. = 1";

            for (int i= 0; i<18; i++)
            {
                comboBox1.Items.Add(creditos[i, 0] + "\n");
            }

           
        }
        private void creditos_cbo()
        {
            string[,] creditos = new string[18, 3];
            creditos[0, 0] = "1";
            creditos[0, 1] = "Participación en ferias organizadas por la universidad.";
            creditos[0, 2] = "N° C. = 1";

            creditos[1, 0] = "2";
            creditos[1, 1] = "Presentación de proyectos de emprendimiento.";
            creditos[1, 2] = "N° C. = 3";

            creditos[2, 0] = "3";
            creditos[2, 1] = "Participación en ferias científicas.";
            creditos[2, 2] = "N° C. = 1";

            creditos[3, 0] = "4";
            creditos[3, 1] = "Promoción de la Universidad.";
            creditos[3, 2] = "N° C. = 1";

            creditos[4, 0] = "5";
            creditos[4, 1] = "Participación en charlas, seminarios, cursos organizados o no por la Universidad.";
            creditos[4, 2] = "N° C. = 1";

            creditos[5, 0] = "6";
            creditos[5, 1] = "Deportes o cultura.";
            creditos[5, 2] = "N° C. = 2";

            creditos[6, 0] = "7. ";
            creditos[6, 1] = "Proyección Social (Jornadas de salud, mas sociales.";
            creditos[6, 2] = "N° C. = 2";

            creditos[7, 0] = "8";
            creditos[7, 1] = "Promoción de carreras.";
            creditos[7, 2] = "N° C. = 2";

            creditos[8, 0] = "9";
            creditos[8, 1] = "Atención en biblioteca.";
            creditos[8, 2] = "N° C. = 2";

            creditos[9, 0] = "10";
            creditos[9, 1] = "Soporte a Dirección de Campus.";
            creditos[9, 2] = "N° C. = 2";

            creditos[10, 0] = "11";
            creditos[10, 1] = "Programa Movimiento Alumno Ayudante.";
            creditos[10, 2] = "N° C. = 2";

            creditos[11, 0] = "12";
            creditos[11, 1] = "Voluntariado UCN.";
            creditos[11, 2] = "N° C. = 2";

            creditos[12, 0] = "13";
            creditos[12, 1] = "Edecanes.";
            creditos[12, 2] = "N° C. = 2";

            creditos[13, 0] = "14";
            creditos[13, 1] = "Organización de eventos científicos.";
            creditos[13, 2] = "N° C. = 2";

            creditos[14, 0] = "15";
            creditos[14, 1] = "Organización de eventos culturales.";
            creditos[14, 2] = "N° C. = 2";

            creditos[15, 0] = "16";
            creditos[15, 1] = "Organización de eventos verdes.";
            creditos[15, 2] = "N° C. = 2";

            creditos[16, 0] = "17";
            creditos[16, 1] = "Participación en el curso de inducción.";
            creditos[16, 2] = "N° C. = 2";

            creditos[17, 0] = "18";
            creditos[17, 1] = "Participar en eventos, verdes, culturales o científicos.";
            creditos[17, 2] = "N° C. = 1";

            comboBox1.Text = creditos[0, 1];
            for (int i = 0; i < 18; i++)
            {
                comboBox1.Items.Add(creditos[i, 0]);
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.isEditar = false;
            this.Botones();
            this.Habilitar(true);
            this.Limpiar();
            creditos();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            bool error;
            try
            {
                string consulta = "";
                if (this.txt_lugar.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos Datos.");
                    errorProvider1.Clear();
                    error = true;
                    errorProvider1.SetError(txt_lugar, "Ingrese el Lugar");
                }
                else if (this.txt_nombre_ac.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos Datos.");
                    errorProvider1.Clear();
                    error = true;
                    errorProvider1.SetError(this.txt_nombre_ac, "Ingrese el Nombre");
                }
                else if(comboBox1.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos Datos.");
                    errorProvider1.Clear();
                    error = true;
                    
                    errorProvider1.SetError(comboBox1, "Seleccione el Tipo de Actividad");
                }
                
                else
                {
                    if (this.isNuevo)
                    {
                        consulta = CN_Actividad.Insertar(this.dateTimePicker1.Value, this.dateTimePicker2.Value, this.txt_lugar.Text, this.txt_nombre_ac.Text, this.comboBox1.Text);
                    }
                    else
                    {
                        consulta = CN_Actividad.Editar(int.Parse(txt_id.Text),this.dateTimePicker1.Value, this.dateTimePicker2.Value, this.txt_lugar.Text, this.txt_nombre_ac.Text, this.comboBox1.Text);
                    }
                    if (consulta.Equals("Ok"))
                    {
                        if (this.isNuevo)
                        {
                            MensajeOk("Se ingreso el registro");
                        }
                        else
                        {
                            MensajeOk("Se actualizo el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(consulta);
                    }
                    this.isNuevo = false;
                    this.isEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.mostrar();
                    comboBox1.Items.Clear();

                   
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*frm_Deatelle_Actividad frm = frm_Deatelle_Actividad.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(dataGridView1.CurrentRow.Cells["Id_Actividad"].Value);
            par2 = txt_nombre_ac.Text;
            frm.setActividad(par1, par2);
            frm_Menu frmenu = new frm_Menu();
            frmenu.AbrirFormHijo(new frm_Deatelle_Actividad());
            this.Hide();*/
            this.txt_id.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Id_Actividad"].Value);
            this.dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Fecha_Inscripcion"].Value);
            this.dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Fecha_Finalizacion"].Value);
            this.txt_lugar.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Lugar"].Value);
            this.txt_nombre_ac.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre_Actividad"].Value);
            this.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Tipo"].Value);
            this.btn_cancelar.Enabled = true;
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            bool error;
            if (!this.txt_id.Text.Equals(""))
            {
                this.isEditar = true;
                this.isNuevo = false;
                this.Botones();
                this.Habilitar(true);
                this.creditos();

                errorProvider1.Clear();
            }
            else
            {
                error = true;
                errorProvider1.SetError(this.txt_id, "Seleccione el Registro que desea Editar");
            }
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            buscar();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = comboBox1.Text;
            this.errorProvider1.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.isNuevo = false;
            this.isEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void txt_lugar_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.errorProvider1.Clear();
        }

        private void txt_nombre_ac_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.errorProvider1.Clear();
        }
    }
}
