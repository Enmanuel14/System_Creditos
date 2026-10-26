using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Detalle_Actividad
    {
        private int _Id_Detalle;
        private int _Id_Actividad;
        private int _Id_Alumno;
        private string _Carnet;
        private string _Nombres;
        private int _Horas;
        private int _Id_Campus;
        private int _Id_Periodo;
        private int _Id_Año;
        private string _Buscar;
        private string _Buscar_Carnet;

        public int Id_Detalle { get => _Id_Detalle; set => _Id_Detalle = value; }
        public int Id_Actividad { get => _Id_Actividad; set => _Id_Actividad = value; }
        public int Id_Alumno { get => _Id_Alumno; set => _Id_Alumno = value; }
        public string Carnet { get => _Carnet; set => _Carnet = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public int Horas { get => _Horas; set => _Horas = value; }
        public int Id_Campus { get => _Id_Campus; set => _Id_Campus = value; }
        public int Id_Periodo { get => _Id_Periodo; set => _Id_Periodo = value; }
        public int Id_Año { get => _Id_Año; set => _Id_Año = value; }
        public string Buscar { get => _Buscar; set => _Buscar = value; }
        public string Buscar_Carnet { get => _Buscar_Carnet; set => _Buscar_Carnet = value; }

        public CD_Detalle_Actividad()
        {

        }
        public CD_Detalle_Actividad(int detalle, int actividad, int alumno, string carnet, string nombre, int horas, int campus, int periodo, int año, string buscar, string buscar_carnet)
        {
            this.Id_Detalle = detalle;
            this.Id_Actividad = actividad;
            this.Id_Alumno = alumno;
            this.Carnet = carnet;
            this.Nombres = nombre;
            this.Horas = horas;
            this.Id_Campus = campus;
            this.Id_Periodo = periodo;
            this.Id_Año = año;
            this.Buscar = buscar;
            this.Buscar_Carnet = buscar_carnet;
        }
        public static string Insertar(CD_Detalle_Actividad detalle)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                sqlcon.Open();

                SqlCommand sqlccmd = new SqlCommand();
                sqlccmd.Connection = sqlcon;

                sqlccmd.CommandText = "insertar_detalle";
                sqlccmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlpariddetalle = new SqlParameter();
                sqlpariddetalle.ParameterName = "@id_detalle";
                sqlpariddetalle.SqlDbType = SqlDbType.Int;
                sqlpariddetalle.Direction = ParameterDirection.Output;
                sqlccmd.Parameters.Add(sqlpariddetalle);

                SqlParameter sqlparida = new SqlParameter();
                sqlparida.ParameterName = "@id_actividad";
                sqlparida.SqlDbType = SqlDbType.Int;
                //sqlparida.Direction = ParameterDirection.Output;
                sqlparida.Value = detalle.Id_Actividad;
                sqlccmd.Parameters.Add(sqlparida);

                SqlParameter sqlparidalum = new SqlParameter();
                sqlparidalum.ParameterName = "@id_alumno";
                sqlparidalum.SqlDbType = SqlDbType.Int;
                //sqlparida.Direction = ParameterDirection.Output;
                sqlparidalum.Value = detalle.Id_Alumno;
                sqlccmd.Parameters.Add(sqlparidalum);

                SqlParameter sqlparcarnet = new SqlParameter();
                sqlparcarnet.ParameterName = "@carnet";
                sqlparcarnet.SqlDbType = SqlDbType.Decimal;
                sqlparcarnet.Value = detalle.Carnet;
                sqlccmd.Parameters.Add(sqlparcarnet);

                SqlParameter sqlparnombre = new SqlParameter();
                sqlparnombre.ParameterName = "@nombre";
                sqlparnombre.SqlDbType = SqlDbType.NVarChar;
                sqlparnombre.Size = 250;
                sqlparnombre.Value = detalle.Nombres;
                sqlccmd.Parameters.Add(sqlparnombre);

                SqlParameter sqlparhoras = new SqlParameter();
                sqlparhoras.ParameterName = "@horas";
                sqlparhoras.SqlDbType = SqlDbType.Int;
                //sqlparida.Direction = ParameterDirection.Output;
                sqlparhoras.Value = detalle.Horas;
                sqlccmd.Parameters.Add(sqlparhoras);

                SqlParameter sqlparcampus = new SqlParameter();
                sqlparcampus.ParameterName = "@id_campus";
                sqlparcampus.SqlDbType = SqlDbType.Int;
                //sqlparida.Direction = ParameterDirection.Output;
                sqlparcampus.Value = detalle.Id_Campus;
                sqlccmd.Parameters.Add(sqlparcampus);

                SqlParameter sqlparperiodo = new SqlParameter();
                sqlparperiodo.ParameterName = "@id_periodo";
                sqlparperiodo.SqlDbType = SqlDbType.Int;
                //sqlparida.Direction = ParameterDirection.Output;
                sqlparperiodo.Value = detalle.Id_Periodo;
                sqlccmd.Parameters.Add(sqlparperiodo);

                SqlParameter sqlparaño = new SqlParameter();
                sqlparaño.ParameterName = "@id_año";
                sqlparaño.SqlDbType = SqlDbType.Int;
                //sqlparida.Direction = ParameterDirection.Output;
                sqlparaño.Value = detalle.Id_Año;
                sqlccmd.Parameters.Add(sqlparaño);

                rpta = sqlccmd.ExecuteNonQuery() == 1 ? "Ok" : "No se Ingreso el Registro";
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
        public static string Editar(CD_Detalle_Actividad detalle)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                sqlcon.Open();

                SqlCommand sqlccmd = new SqlCommand();
                sqlccmd.Connection = sqlcon;

                sqlccmd.CommandText = "editar_detalle";
                sqlccmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlpariddetalle = new SqlParameter();
                sqlpariddetalle.ParameterName = "@id_detalle";
                sqlpariddetalle.SqlDbType = SqlDbType.Int;
                //sqlpariddetalle.Direction = ParameterDirection.Output;
                sqlpariddetalle.Value = detalle.Id_Detalle;
                sqlccmd.Parameters.Add(sqlpariddetalle);

                SqlParameter sqlparida = new SqlParameter();
                sqlparida.ParameterName = "@id_actividad";
                sqlparida.SqlDbType = SqlDbType.Int;
                //sqlparida.Direction = ParameterDirection.Output;
                sqlparida.Value = detalle.Id_Actividad;
                sqlccmd.Parameters.Add(sqlparida);

                SqlParameter sqlparidalum = new SqlParameter();
                sqlparidalum.ParameterName = "@id_alumno";
                sqlparidalum.SqlDbType = SqlDbType.Int;
                //sqlparida.Direction = ParameterDirection.Output;
                sqlparidalum.Value = detalle.Id_Alumno;
                sqlccmd.Parameters.Add(sqlparidalum);

                SqlParameter sqlparcarnet = new SqlParameter();
                sqlparcarnet.ParameterName = "@carnet";
                sqlparcarnet.SqlDbType = SqlDbType.Decimal;
                sqlparcarnet.Value = detalle.Carnet;
                sqlccmd.Parameters.Add(sqlparcarnet);

                SqlParameter sqlparnombre = new SqlParameter();
                sqlparnombre.ParameterName = "@nombre";
                sqlparnombre.SqlDbType = SqlDbType.NVarChar;
                sqlparnombre.Size = 250;
                sqlparnombre.Value = detalle.Nombres;
                sqlccmd.Parameters.Add(sqlparnombre);

                SqlParameter sqlparhoras = new SqlParameter();
                sqlparhoras.ParameterName = "@horas";
                sqlparhoras.SqlDbType = SqlDbType.Int;
                //sqlparida.Direction = ParameterDirection.Output;
                sqlparhoras.Value = detalle.Horas;
                sqlccmd.Parameters.Add(sqlparhoras);

                SqlParameter sqlparcampus = new SqlParameter();
                sqlparcampus.ParameterName = "@id_campus";
                sqlparcampus.SqlDbType = SqlDbType.Int;
                //sqlparida.Direction = ParameterDirection.Output;
                sqlparcampus.Value = detalle.Id_Campus;
                sqlccmd.Parameters.Add(sqlparcampus);

                SqlParameter sqlparperiodo = new SqlParameter();
                sqlparperiodo.ParameterName = "@id_periodo";
                sqlparperiodo.SqlDbType = SqlDbType.Int;
                //sqlparida.Direction = ParameterDirection.Output;
                sqlparperiodo.Value = detalle.Id_Periodo;
                sqlccmd.Parameters.Add(sqlparperiodo);

                SqlParameter sqlparaño = new SqlParameter();
                sqlparaño.ParameterName = "@id_año";
                sqlparaño.SqlDbType = SqlDbType.Int;
                //sqlparida.Direction = ParameterDirection.Output;
                sqlparaño.Value = detalle.Id_Año;
                sqlccmd.Parameters.Add(sqlparaño);

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
        public static string Eliminar(CD_Detalle_Actividad detalle)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                sqlcon.Open();

                SqlCommand sqlccmd = new SqlCommand();
                sqlccmd.Connection = sqlcon;

                sqlccmd.CommandText = "eliminar_detalle";
                sqlccmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlpariddetalle = new SqlParameter();
                sqlpariddetalle.ParameterName = "@id_detalle";
                sqlpariddetalle.SqlDbType = SqlDbType.Int;
                //sqlpariddetalle.Direction = ParameterDirection.Output;
                sqlpariddetalle.Value = detalle.Id_Detalle;
                sqlccmd.Parameters.Add(sqlpariddetalle);

                

                rpta = sqlccmd.ExecuteNonQuery() == 1 ? "Ok" : "No se Elimino el Registro";
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
        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("Detalle_Actividad");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                SqlCommand sqlccmd = new SqlCommand();
                sqlccmd.Connection = sqlcon;

                sqlccmd.CommandText = "MOSTRAR_DETALLE";
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
        public DataTable BuscarNombre(CD_Detalle_Actividad detalle)
        {
            DataTable DtResultado = new DataTable("Detalle_Actividad");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscar_detalle";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@nombre";
                ParTextoBuscar.SqlDbType = SqlDbType.NVarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = detalle.Buscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
        public DataTable BuscarCarnet(CD_Detalle_Actividad detalle)
        {
            DataTable DtResultado = new DataTable("Detalle_Actividad");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscar_detalle_";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@carnet";
                ParTextoBuscar.SqlDbType = SqlDbType.NVarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = detalle.Buscar_Carnet;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

    }
}
