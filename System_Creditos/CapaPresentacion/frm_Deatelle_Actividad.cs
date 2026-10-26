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
using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class frm_Deatelle_Actividad : Form
    {
        public frm_Deatelle_Actividad()
        {
            InitializeComponent();
        }
        public void mostrar()
        {
            this.dataGridView1.DataSource = CN_Detalle_Actividad.Mostrar();
            this.OcultarColumnas();
        }
        private void OcultarColumnas()
        {
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].Visible = false;
        }
        public static frm_Deatelle_Actividad _Instancia;

        public static frm_Deatelle_Actividad GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frm_Deatelle_Actividad();
            }
            return _Instancia;
        }
        public void setActividad(string id, string actividad, string tipo)
        {
            this.txt_idactividad.Text = id;
            //this.txt_actividad.Text = actividad;
            this.txt_tipo.Text = tipo;
        }
        public void setAlumno(string id, string carnet, string nombre)
        {
            this.txt_id_alumno.Text = id;
            this.txt_carnet.Text = carnet;
            this.txt_nombre.Text = nombre;
        }
        public void setAño(string id, string año)
        {
           this.txt_idaño.Text = id;
            //this.txt_año.Text = año;
        }
        public void setPeriodo(string id, string periodo)
        {
            this.txt_idperiodo.Text = id;
            //this.txtperiodo.Text = periodo;
        }
        public void setCampus(string id, string campus)
        {
            this.txt_idcampus.Text = id;
           // this.txt_campus.Text = campus;
        }
        private void frm_Deatelle_Actividad_Load(object sender, EventArgs e)
        {
            this.mostrar();
            this.Habilitar(false);
            this.Botones();
        }
        private void cargarcombo_actividad()
        {
            this.comboBox1.DataSource = CN_Actividad.Mostrar();
            this.comboBox1.DisplayMember = "Nombre_Actividad";
            this.comboBox1.ValueMember = "Id_Actividad";
            this.comboBox1.Text = "...";
            //this.txt_idactividad.Text = string.Empty;
            this.txt_tipo.Text = string.Empty;
        }
        private void cargarcombo_periodo()
        {
            this.comboBox3.DataSource = CN_Periodo.Mostrar();
            this.comboBox3.DisplayMember = "Peirodo";
            this.comboBox3.ValueMember = "Id_Periodo";
            this.comboBox3.Text = "...";
            //this.txt_idperiodo.Text = string.Empty;
            //this.txt_tipo.Text = string.Empty;
        }
        private void cargarcombo_campus()
        {
            this.comboBox2.DataSource = CN_Campus.Mostrar();
            this.comboBox2.DisplayMember = "Campus";
            this.comboBox2.ValueMember = "Id_Campus";
            this.comboBox2.Text = "...";
            //this.txt_idcampus.Text = string.Empty;
        }
        private void cargarcombo_año()
        {
            this.comboBox4.DataSource = CN_Año.Mostrar();
            this.comboBox4.DisplayMember = "Año";
            this.comboBox4.ValueMember = "Id_Año";
            this.comboBox4.Text = "...";
            //this.txt_idcampus.Text = string.Empty;
        }
        private void buscar()
        {
            this.dataGridView1.DataSource = CN_Detalle_Actividad.BuscarNombre(this.textBox1.Text);
        }
        private void buscar_carnet()
        {
            this.dataGridView1.DataSource = CN_Detalle_Actividad.BuscarCarnet(this.textBox2.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buscar();
            if(textBox1.Text == String.Empty)
            {
                mostrar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            frm_vista_actividad frm = new frm_vista_actividad();
            frm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            this.errorProvider1.Clear();
            frm_vistaalumno frm = new frm_vistaalumno();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_vista_año frm = new frm_vista_año();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_vista_periodo frm = new frm_vista_periodo();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_vista_campus frm = new frm_vista_campus();
            frm.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        bool isNuevo = false;
        bool isEditar = false;
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "System Creditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "System Creditos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Limpiar_Nuevo_detalle()
        {
            this.txt_carnet.Text = string.Empty;
            this.txt_nombre.Text = string.Empty;
            this.txt_id_alumno.Text = string.Empty;
        }
        private void Limpiar()
        {
            this.txt_carnet.Text = string.Empty;
            this.txt_nombre.Text = string.Empty;
            this.txt_id_alumno.Text = string.Empty;
            this.txt_id.Text = string.Empty;
            this.txt_idactividad.Text = string.Empty;
            //this.txt_actividad.Text = string.Empty;
            this.txt_tipo.Text = string.Empty;
            this.txt_horas.Text = string.Empty;
            this.txt_idcampus.Text = string.Empty;
           // this.txt_campus.Text = string.Empty;
            this.txt_idperiodo.Text = string.Empty;
           // this.txtperiodo.Text = string.Empty;
            this.txt_idaño.Text = string.Empty;
           // this.txt_año.Text= string.Empty;
        }
        private void limpiar_nuevo()
        {
            this.txt_id_alumno.Text = string.Empty;
            this.txt_nombre.Text = string.Empty;
            this.txt_carnet.Text = string.Empty;
        }
        private void habilitar_nuevo(bool valor)
        {
            this.comboBox1.Enabled = valor;
            this.comboBox2.Enabled = valor;
            this.comboBox3.Enabled = valor;
            this.comboBox4.Enabled = valor;
            
            comboBox1.ForeColor = Color.White;
            comboBox2.ForeColor = Color.White;
            comboBox3.ForeColor = Color.White;
            comboBox4.ForeColor = Color.White;

        }
        private void Habilitar(bool valor)
        {
            this.txt_horas.ReadOnly = !valor;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = Conexion.cn;
            SqlCommand cmd = new SqlCommand("select*from Actividad where Nombre_Actividad = '" + comboBox1.Text + "'", sqlcon);
            sqlcon.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read()==true)
            {
                this.txt_idactividad.Text = reader["Id_Actividad"].ToString();
                this.txt_tipo.Text = reader["Tipo"].ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = Conexion.cn;
            SqlCommand cmd = new SqlCommand("select*from Actividad where Nombre_Actividad = '" + comboBox1.Text + "'", sqlcon);
            sqlcon.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                this.txt_idactividad.Text = reader["Id_Actividad"].ToString();
                this.txt_tipo.Text = reader["Tipo"].ToString();
            }
            sqlcon.Close();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = Conexion.cn;
            SqlCommand cmd = new SqlCommand("select*from Campus where Campus = '" + comboBox2.Text + "'", sqlcon);
            sqlcon.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                this.txt_idcampus.Text = reader["Id_Campus"].ToString();
                //this.txt_tipo.Text = reader["Tipo"].ToString();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = Conexion.cn;
            SqlCommand cmd = new SqlCommand("select*from Periodo where Peirodo = '" + comboBox3.Text + "'", sqlcon);
            sqlcon.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                this.txt_idperiodo.Text = reader["Id_Periodo"].ToString();
                //this.txt_tipo.Text = reader["Tipo"].ToString();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = Conexion.cn;
            SqlCommand cmd =  new SqlCommand("select*from Año_Academico where Año = '" + comboBox4.Text.ToString() + "'", sqlcon);
            sqlcon.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                this.txt_idaño.Text = reader["Id_Año"].ToString();
                //this.txt_tipo.Text = reader["Tipo"].ToString();
            }
        }

        private void btn_calcular_Click(object sender, EventArgs e)
        {
            bool error;
            if(this.txt_tipo.Text == string.Empty)
            {
                error = true;
                errorProvider1.SetError(txt_tipo, "Seleccione un Registro");
            }
            else
            {
                errorProvider1.Clear();
                string texto1 = this.txt_tipo.Text;
                string texto2 = "Participación en ferias organizadas por la universidad.";
                string texto3 = "Presentación de proyectos de emprendimiento.";
                string texto4 = "Participación en ferias científicas.";
                string texto5 = "Promoción de la Universidad.";
                string texto6 = "Participación en charlas, seminarios, cursos organizados o no por la Universidad.";
                string texto7 = "Deportes o cultura.";
                string texto8 = "Proyección Social (Jornadas de salud, mas sociales).";
                string texto9 = "Promoción de carreras.";
                string texto10 = "Atención en biblioteca.";
                string texto11 = "Soporte a Dirección de Campus.";
                string texto12 = "Programa Movimiento Alumno Ayudante.";
                string texto13 = "Voluntariado UCN.";
                string texto14 = "Edecanes.";
                string texto15 = "Organización de eventos científicos.";
                string texto16 = "Organización de eventos culturales.";
                string texto17 = "Organización de eventos verdes.";
                string texto18 = "Participación en el curso de inducción.";
                string texto19 = "Participar en eventos, verdes, culturales o científicos.";
                bool result;
               
                if(texto1.Contains(texto2))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "48";
                    this.txt_horas.ReadOnly = false;
                }
                else if(texto1.Contains(texto3))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "144";
                    this.txt_horas.ReadOnly = false;
                }
                else if(texto1.Contains(texto4))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "48";
                    this.txt_horas.ReadOnly = false;
                }
                else if (texto1.Contains(texto5))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "48";
                    this.txt_horas.ReadOnly = false;
                }
                else if (texto1.Contains(texto6))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "48";
                    this.txt_horas.ReadOnly = false;
                }
                else if (texto1.Contains(texto7))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "96";
                    this.txt_horas.ReadOnly = false;
                }
                else if (texto1.Contains(texto8))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "96";
                    this.txt_horas.ReadOnly = false;
                }
                else if (texto1.Contains(texto9))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "96";
                    this.txt_horas.ReadOnly = false;
                }
                else if (texto1.Contains(texto10))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "96";
                    this.txt_horas.ReadOnly = false;
                }
                else if (texto1.Contains(texto11))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "96";
                    this.txt_horas.ReadOnly = false;
                }
                else if (texto1.Contains(texto12))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "96";
                    this.txt_horas.ReadOnly = false;
                }
                else if (texto1.Contains(texto13))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "96";
                    this.txt_horas.ReadOnly = false;
                }
                else if (texto1.Contains(texto14))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "96";
                    this.txt_horas.ReadOnly = false;
                }
                else if (texto1.Contains(texto15))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "96";
                    this.txt_horas.ReadOnly = false;
                }
                else if (texto1.Contains(texto16))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "96";
                    this.txt_horas.ReadOnly = false;
                }
                else if (texto1.Contains(texto17))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "96";
                    this.txt_horas.ReadOnly = false;
                }
                else if (texto1.Contains(texto18))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "96";
                    this.txt_horas.ReadOnly = false;
                }
                else if (texto1.Contains(texto19))
                {
                    result = true;
                    this.txt_horas.Text = string.Empty;
                    this.txt_horas.Text = "48";
                    this.txt_horas.ReadOnly = false;
                }
            }
            
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            bool error;
            try
            {
                string consulta = "";
                if (this.txt_idactividad.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos Datos.");
                    errorProvider1.Clear();
                    error = true;
                    errorProvider1.SetError(comboBox1, "Seleccione una Actividad");
                }
                else if (this.txt_idactividad.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos Datos.");
                    errorProvider1.Clear();
                    error = true;
                    errorProvider1.SetError(this.txt_idactividad, "Seleccione una Actividad");
                }
                else if (this.txt_id_alumno.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos Datos.");
                    errorProvider1.Clear();
                    error = true;

                    errorProvider1.SetError(txt_id_alumno, "Seleccione el id del Alumno");
                }
                else if(this.txt_horas.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos Datos.");
                    errorProvider1.Clear();
                    error = true;
                    errorProvider1.SetError(txt_horas, "Defina la cantidad de Horas");
                }
                else if(this.txt_idcampus.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos Datos.");
                    errorProvider1.Clear();
                    error = true;
                    errorProvider1.SetError(comboBox2, "Seleccione el Campus");
                }
                else if (this.txt_idperiodo.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos Datos.");
                    errorProvider1.Clear();
                    error = true;
                    errorProvider1.SetError(comboBox3, "Seleccione el Periodo");
                }
                else if (this.txt_idaño.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos Datos.");
                    errorProvider1.Clear();
                    error = true;
                    errorProvider1.SetError(comboBox4, "Seleccione el Año");
                }
                else
                {
                    if (this.isNuevo)
                    {
                       consulta = CN_Detalle_Actividad.Insertar(int.Parse(this.txt_idactividad.Text), int.Parse(this.txt_id_alumno.Text), this.txt_carnet.Text, this.txt_nombre.Text, int.Parse(this.txt_horas.Text), int.Parse(this.txt_idcampus.Text), int.Parse(this.txt_idperiodo.Text), int.Parse(this.txt_idaño.Text));
                    }
                    else
                    {
                        consulta = CN_Detalle_Actividad.Editar(int.Parse(this.txt_id.Text),int.Parse(this.txt_idactividad.Text), int.Parse(this.txt_id_alumno.Text), this.txt_carnet.Text, this.txt_nombre.Text, int.Parse(this.txt_horas.Text), int.Parse(this.txt_idcampus.Text), int.Parse(this.txt_idperiodo.Text), int.Parse(this.txt_idaño.Text));
                    }
                    if (consulta.Equals("Ok"))
                    {
                        if (this.isNuevo)
                        {
                            MensajeOk("Se ingreso el registro");
                            this.isNuevo = true;
                            this.isEditar = false;
                            this.Botones();
                            this.limpiar_nuevo();

                        }
                        else
                        {
                            MensajeOk("Se actualizo el registro");
                            this.isNuevo = false;
                            this.isEditar = false;
                            this.Botones();
                            this.Limpiar();
                            this.Habilitar(false);
                            this.Limpiar_combo();
                        }
                    }
                    else
                    {
                        this.MensajeError(consulta);
                    }
                    
                    
                    
                    
                    
                    this.mostrar();
                    //comboBox1.Items.Clear();




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.isEditar = false;
            this.Botones();
            this.Habilitar(true);
            this.Limpiar();
            cargarcombo_actividad();
            cargarcombo_campus();
            cargarcombo_periodo();
            cargarcombo_año();
        }
        private void Limpiar_combo()
        {
            comboBox1.DataSource = null;
            comboBox2.DataSource = null;
            comboBox3.DataSource = null;
            comboBox4.DataSource = null;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.isNuevo = false;
            this.isEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.Limpiar_combo();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Limpiar_combo();
                this.txt_id.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Id_DetalleA"].Value);
                this.txt_idactividad.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Id_Actividad"].Value);
                this.comboBox1.Items.Add(Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre_Actividad"].Value));
                //this.txt_tipo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Tipo"].Value);
                this.txt_id_alumno.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Id_Alumno"].Value);
                this.txt_carnet.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Carnet"].Value);
                this.txt_nombre.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre"].Value);
                this.txt_horas.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Horas"].Value);
                this.txt_idcampus.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Id_Campus"].Value);
                this.comboBox2.Items.Add(Convert.ToString(dataGridView1.CurrentRow.Cells["Campus"].Value));
                this.txt_idperiodo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Id_Periodo"].Value);
                this.comboBox3.Items.Add(Convert.ToString(dataGridView1.CurrentRow.Cells["Periodo"].Value));
                this.txt_idaño.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Id_Año"].Value);
                this.comboBox4.Items.Add(Convert.ToString(dataGridView1.CurrentRow.Cells["Año"].Value));
                cargarcombo_actividad();
                cargarcombo_año();
                cargarcombo_campus();
                cargarcombo_periodo();
                btn_cancelar.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (!this.txt_id.Text.Equals(""))
            {
                this.isEditar = true;
                this.Botones();
                this.Habilitar(true);
                this.cargarcombo_actividad();
                this.cargarcombo_año();
                this.cargarcombo_campus();
                this.cargarcombo_periodo();
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
                bool error;
                error = true;
                if(error)
                {
                    errorProvider1.SetError(txt_id, "Seleccione el Registro");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.dataGridView1.Columns[0].Visible = true;
            }
            else
            {
                this.dataGridView1.Columns[0].Visible = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            
                try
                {
                    DialogResult Opcion;
                    Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        string Codigo;
                        string Rpta = "";

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = Convert.ToString(row.Cells[1].Value);
                                Rpta = CN_Detalle_Actividad.Eliminar(Convert.ToInt32(Codigo));

                                

                            }
                        }
                    if (Rpta.Equals("Ok"))
                    {
                        this.MensajeOk("Se Eliminó Correctamente el registro");
                        checkBox1.Checked = false;
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                    this.mostrar();
                    this.isNuevo = false;
                    this.isEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Habilitar(false);
                    this.Limpiar_combo();
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox2.Text = null;
                this.mostrar();
                textBox2.Enabled = false;
                textBox1.Enabled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                textBox1.Text = string.Empty;
                this.mostrar();
                textBox1.Enabled = false;
                textBox2.Enabled = true;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            this.buscar();
            if (textBox1.Text == string.Empty)
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = CN_Detalle_Actividad.Mostrar();
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.buscar_carnet();
            if (textBox2.Text == string.Empty)
            {
                this.mostrar();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text= string.Empty;
            this.textBox1.Enabled = false;
            this.textBox2.Text = string.Empty;
            this.textBox2.Enabled = false;
            this.radioButton2.Checked = false;
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = CN_Detalle_Actividad.Mostrar();
        }
    }
    }

