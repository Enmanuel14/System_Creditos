using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaNegocio;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class frm_alumno : Form
    {
        public frm_alumno()
        {
            InitializeComponent();
        }
        bool isNuevo = false;
        bool isEditar = false;
        public void mostrar()
        {
            this.dataGridView1.DataSource = CN_Alumno.Mostrar();
            this.dataGridView1.Columns[0].Visible = false;
        }
        private void cargarcombo_carrera()
        {
            this.comboBox1.DataSource = CN_Carrera.Mostrar();
            this.comboBox1.DisplayMember = "Nombre";
            this.comboBox1.ValueMember = "Id_Carrera";
            this.comboBox1.Text = "...";

            
            
        }
        private void buscar()
        {
            this.dataGridView1.DataSource = CN_Alumno.Buscar(this.txt_buscar.Text);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje,"System Creditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "System Creditos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Limpiar()
        {
            this.txt_carnet.Text = string.Empty;
            this.txt_nombre.Text = string.Empty;
            //  this.txt_codigo_carrera.Text = string.Empty;
            this.comboBox1.DataSource = null;
            this.txt_carrera.Text = string.Empty;
            this.txt_id_alumno.Text = string.Empty;
        }
        private void Habilitar(bool valor)
        {
            this.txt_carnet.ReadOnly = !valor;
            this.txt_nombre.ReadOnly = !valor;
            this.txt_carnet.Focus();
        }
        private void Botones()
        {
            if(this.isNuevo || this.isEditar)
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
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frm_alumno_Load(object sender, EventArgs e)
        {
            this.mostrar();
            this.Habilitar(false);
            this.Botones();
        }
        public static frm_alumno _Instancia;

        public static frm_alumno GetInstancia()
        {
            if(_Instancia == null)
            {
                _Instancia = new frm_alumno();
            }
            return _Instancia;
        }
        public void setCarrera(string id, string carrera)
        {
           // this.txt_codigo_carrera.Text = id;
            this.txt_carrera.Text = carrera;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            frm_vista_carrera frm = new frm_vista_carrera();
            frm.ShowDialog();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.isEditar = false;
            this.Botones();
            this.Habilitar(true);
            this.Limpiar();
            cargarcombo_carrera();
            comboBox1.Text = string.Empty;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            bool error;
            try
            {
                string consulta = "";
                if(this.txt_carnet.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos Datos.");
                    error = true;
                    errorProvider1.SetError(this.txt_carnet, "Ingrese el Carnet del Alumno");
                }
                else if(this.txt_nombre.Text == string.Empty)
                {
                    
                    errorProvider1.Clear();
                    MensajeError("Falta Ingresar algunos Datos.");
                    error = true;
                    errorProvider1.SetError(this.txt_nombre, "Ingrese el Nombre");
                }
               else if(this.comboBox1.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    MensajeError("Falta Ingresar algunos Datos.");
                    error = true;
                    errorProvider1.SetError(comboBox1, "Seleccione la Carrera Correspondiente");
                }
                else
                {
                    errorProvider1.Clear();
                    if(this.isNuevo)
                    {
                        consulta = CN_Alumno.Insertar(txt_carnet.Text, this.txt_nombre.Text, int.Parse(txt_carrera.Text));
                    }
                    else
                    {
                        consulta = CN_Alumno.Editar(int.Parse(this.txt_id_alumno.Text),this.txt_carnet.Text, this.txt_nombre.Text, int.Parse(txt_carrera.Text));
                    }
                    if(consulta.Equals("Ok"))
                    {
                        if(this.isNuevo)
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
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txt_carnet_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.errorProvider1.Clear();
        }

        private void txt_carnet_TextChanged(object sender, EventArgs e)
        {
            if(txt_carnet.TextLength > 11)
            {
                
            }
        }

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            bool error;
            if(!this.txt_carnet.Text.Equals(""))
            {
                this.isEditar = true;
                this.isNuevo = false;
                this.Botones();
                this.Habilitar(true);
                
                errorProvider1.Clear();
            }
            else
            {
                error = true;
                errorProvider1.SetError(this.txt_carnet, "Seleccione el Registro que desea Editar");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txt_id_alumno.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Id_Alumno"].Value);
            this.txt_carnet.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Carnet"].Value);
            this.txt_nombre.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre"].Value);
            this.txt_carrera.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Id_Carrera"].Value);
            //this.txt_carrera.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Carrera"].Value);
            cargarcombo_carrera();
            btn_cancelar.Enabled = true;
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
           
            if(txt_buscar.Text == string.Empty)
            {
                mostrar();
            }
            else
            {
                buscar();
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.isNuevo = false;
            this.isEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = Conexion.cn;
            SqlCommand cmd = new SqlCommand("select*from Carrera where Nombre = '" + comboBox1.Text + "'", sqlcon);
            sqlcon.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                this.txt_carrera.Text = reader["Id_Carrera"].ToString();
                //this.txt_tipo.Text = reader["Tipo"].ToString();
            }
            sqlcon.Close();
        }
    }
}
