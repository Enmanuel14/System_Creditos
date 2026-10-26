using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CD_Alumno
    {
        private int _Id_Alumno;
        private string _Carnet;
        private string _Nombre;
        private int _Id_Carrera;
        private string _Buscar;

        public string Carnet { get => _Carnet; set => _Carnet = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int Id_Carrera { get => _Id_Carrera; set => _Id_Carrera = value; }
        public string Buscar { get => _Buscar; set => _Buscar = value; }
        public int Id_Alumno { get => _Id_Alumno; set => _Id_Alumno = value; }

        public CD_Alumno()
        {

        }
        public CD_Alumno(int id, string carnet, string nombre, int carrera, string buscar)
        {
            this.Id_Alumno=id;
            this.Carnet = carnet;
            this.Nombre = nombre;
            this.Id_Carrera = carrera;
            this.Buscar = buscar;
        }
        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("Alumno");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                SqlCommand sqlccmd = new SqlCommand();
                sqlccmd.Connection = sqlcon;

                sqlccmd.CommandText = "mostrar_alumno";
                sqlccmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(sqlccmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }
        public static string Insertar(CD_Alumno alumno)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                sqlcon.Open();

                SqlCommand sqlccmd = new SqlCommand();
                sqlccmd.Connection = sqlcon;

                sqlccmd.CommandText = "insertar_alumno";
                sqlccmd.CommandType= CommandType.StoredProcedure;

                SqlParameter sqlparida = new SqlParameter();
                sqlparida.ParameterName = "@id";
                sqlparida.SqlDbType = SqlDbType.Int;
                sqlparida.Direction = ParameterDirection.Output;
                sqlccmd.Parameters.Add(sqlparida);

                SqlParameter sqlparcarnet = new SqlParameter();
                sqlparcarnet.ParameterName = "@carnet";
                sqlparcarnet.SqlDbType = SqlDbType.NVarChar;
                sqlparcarnet.Size = 20;
                sqlparcarnet.Value = alumno.Carnet;
                sqlccmd.Parameters.Add(sqlparcarnet);

                SqlParameter sqlparnombre = new SqlParameter();
                sqlparnombre.ParameterName = "@nombre";
                sqlparnombre.SqlDbType = SqlDbType.NVarChar;
                sqlparnombre.Size = 250;
                sqlparnombre.Value = alumno.Nombre;
                sqlccmd.Parameters.Add(sqlparnombre);

                SqlParameter sqlparid = new SqlParameter();
                sqlparid.ParameterName = "@carrera";
                sqlparid.SqlDbType = SqlDbType.Int;
                sqlparid.Value = alumno.Id_Carrera;
                sqlccmd.Parameters.Add(sqlparid);

                rpta = sqlccmd.ExecuteNonQuery() == 1 ? "Ok" : "No se Ingreso el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if(sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
            return rpta;
        }
        public static string Editar(CD_Alumno alumno)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                sqlcon.Open();

                SqlCommand sqlccmd = new SqlCommand();
                sqlccmd.Connection = sqlcon;

                sqlccmd.CommandText = "editar_alumno";
                sqlccmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlparida = new SqlParameter();
                sqlparida.ParameterName = "@id";
                sqlparida.SqlDbType = SqlDbType.Int;
                sqlparida.Value = alumno.Id_Alumno;
                sqlccmd.Parameters.Add(sqlparida);

                SqlParameter sqlparcarnet = new SqlParameter();
                sqlparcarnet.ParameterName = "@carnet";
                sqlparcarnet.SqlDbType = SqlDbType.NVarChar;
                sqlparcarnet.Size = 20;
                sqlparcarnet.Value = alumno.Carnet;
                sqlccmd.Parameters.Add(sqlparcarnet);

                SqlParameter sqlparnombre = new SqlParameter();
                sqlparnombre.ParameterName = "@nombre";
                sqlparnombre.SqlDbType = SqlDbType.NVarChar;
                sqlparnombre.Size = 250;
                sqlparnombre.Value = alumno.Nombre;
                sqlccmd.Parameters.Add(sqlparnombre);

                SqlParameter sqlparid = new SqlParameter();
                sqlparid.ParameterName = "@carrera";
                sqlparid.SqlDbType = SqlDbType.Int;
                sqlparid.Value = alumno.Id_Carrera;
                sqlccmd.Parameters.Add(sqlparid);

                rpta = sqlccmd.ExecuteNonQuery() == 1 ? "Ok" : "No se Actualizo el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
            return rpta;
        }
        public static DataTable Buscar_Nombre(CD_Alumno alumno)
        {
            DataTable dt = new DataTable("Alumno");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                SqlCommand sqlccmd = new SqlCommand();
                sqlccmd.Connection = sqlcon;

                sqlccmd.CommandText = "buscar_alumno";
                sqlccmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlparnombre = new SqlParameter();
                sqlparnombre.ParameterName = "@nombre";
                sqlparnombre.SqlDbType = SqlDbType.NVarChar;
                sqlparnombre.Size = 250;
                sqlparnombre.Value = alumno.Buscar;
                sqlccmd.Parameters.Add(sqlparnombre);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlccmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }
    }
}
