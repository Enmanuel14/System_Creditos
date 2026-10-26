using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDActividad
    {
        private int _Id_Actividad;
        private DateTime _Fecha_Inicio;
        private DateTime _Fecha_Final;
        private string _Lugar;
        private string _Nombre;
        private string _Tipo;
        private string _Buscar;

        public int Id_Actividad { get => _Id_Actividad; set => _Id_Actividad = value; }
        public DateTime Fecha_Inicio { get => _Fecha_Inicio; set => _Fecha_Inicio = value; }
        public DateTime Fecha_Final { get => _Fecha_Final; set => _Fecha_Final = value; }
        public string Lugar { get => _Lugar; set => _Lugar = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Buscar { get => _Buscar; set => _Buscar = value; }
        public string Tipo { get => _Tipo; set => _Tipo = value; }

        public CDActividad()
        {

        }
        public CDActividad(int id, DateTime fi, DateTime ff, string lugar, string nombre, string tipo, string buscar)
        {
            this.Id_Actividad = id;
            this.Fecha_Inicio = fi;
            this.Fecha_Final = ff;
            this.Lugar = lugar;
            this.Nombre = nombre;
            this.Tipo = tipo;
            this.Buscar = buscar;
        }
        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("Actividad");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                SqlCommand sqlccmd = new SqlCommand();
                sqlccmd.Connection = sqlcon;

                sqlccmd.CommandText = "mostrar_actividad";
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
        public static string Insertar(CDActividad activi)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                sqlcon.Open();

                SqlCommand sqlccmd = new SqlCommand();
                sqlccmd.Connection = sqlcon;

                sqlccmd.CommandText = "insertar_actividad";
                sqlccmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlparida = new SqlParameter();
                sqlparida.ParameterName = "@id";
                sqlparida.SqlDbType = SqlDbType.Int;
                sqlparida.Direction = ParameterDirection.Output;
                sqlccmd.Parameters.Add(sqlparida);

                SqlParameter sqlparfechai = new SqlParameter();
                sqlparfechai.ParameterName = "@fechai";
                sqlparfechai.SqlDbType = SqlDbType.Date;
                sqlparfechai.Value = activi.Fecha_Inicio;
                sqlccmd.Parameters.Add(sqlparfechai);

                SqlParameter sqlparfechaf = new SqlParameter();
                sqlparfechaf.ParameterName = "@fechaf";
                sqlparfechaf.SqlDbType = SqlDbType.Date;
                sqlparfechaf.Value = activi.Fecha_Final;
                sqlccmd.Parameters.Add(sqlparfechaf);

                SqlParameter sqlparlugar = new SqlParameter();
                sqlparlugar.ParameterName = "@lugar";
                sqlparlugar.SqlDbType = SqlDbType.NVarChar;
                sqlparlugar.Size = 250;
                sqlparlugar.Value = activi.Lugar;
                sqlccmd.Parameters.Add(sqlparlugar);

                SqlParameter sqlparnombre = new SqlParameter();
                sqlparnombre.ParameterName = "@nombre";
                sqlparnombre.SqlDbType = SqlDbType.NVarChar;
                sqlparnombre.Size = 250;
                sqlparnombre.Value = activi.Nombre;
                sqlccmd.Parameters.Add(sqlparnombre);

                SqlParameter sqlpartipo = new SqlParameter();
                sqlpartipo.ParameterName = "@tipo";
                sqlpartipo.SqlDbType = SqlDbType.NVarChar;
                sqlpartipo.Size = 300;
                sqlpartipo.Value = activi.Tipo;
                sqlccmd.Parameters.Add(sqlpartipo);

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
        public static string Editar(CDActividad activi)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                sqlcon.Open();

                SqlCommand sqlccmd = new SqlCommand();
                sqlccmd.Connection = sqlcon;

                sqlccmd.CommandText = "editar_actividad";
                sqlccmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlparida = new SqlParameter();
                sqlparida.ParameterName = "@id";
                sqlparida.SqlDbType = SqlDbType.Int;
                //sqlparida.Direction = ParameterDirection.Output;
                sqlparida.Value = activi.Id_Actividad;
                sqlccmd.Parameters.Add(sqlparida);

                SqlParameter sqlparfechai = new SqlParameter();
                sqlparfechai.ParameterName = "@fechai";
                sqlparfechai.SqlDbType = SqlDbType.Date;
                sqlparfechai.Value = activi.Fecha_Inicio;
                sqlccmd.Parameters.Add(sqlparfechai);

                SqlParameter sqlparfechaf = new SqlParameter();
                sqlparfechaf.ParameterName = "@fechaf";
                sqlparfechaf.SqlDbType = SqlDbType.Date;
                sqlparfechaf.Value = activi.Fecha_Final;
                sqlccmd.Parameters.Add(sqlparfechaf);

                SqlParameter sqlparlugar = new SqlParameter();
                sqlparlugar.ParameterName = "@lugar";
                sqlparlugar.SqlDbType = SqlDbType.NVarChar;
                sqlparlugar.Size = 250;
                sqlparlugar.Value = activi.Lugar;
                sqlccmd.Parameters.Add(sqlparlugar);

                SqlParameter sqlparnombre = new SqlParameter();
                sqlparnombre.ParameterName = "@nombre";
                sqlparnombre.SqlDbType = SqlDbType.NVarChar;
                sqlparnombre.Size = 250;
                sqlparnombre.Value = activi.Nombre;
                sqlccmd.Parameters.Add(sqlparnombre);

                SqlParameter sqlpartipo = new SqlParameter();
                sqlpartipo.ParameterName = "@tipo";
                sqlpartipo.SqlDbType = SqlDbType.NVarChar;
                sqlpartipo.Size = 300;
                sqlpartipo.Value = activi.Tipo;
                sqlccmd.Parameters.Add(sqlpartipo);

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
        public static DataTable Buscar_Nombre(CDActividad actividad)
        {
            DataTable dt = new DataTable("Actividad");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                SqlCommand sqlccmd = new SqlCommand();
                sqlccmd.Connection = sqlcon;

                sqlccmd.CommandText = "buscar_actividad";
                sqlccmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlparnombre = new SqlParameter();
                sqlparnombre.ParameterName = "@nombre";
                sqlparnombre.SqlDbType = SqlDbType.NVarChar;
                sqlparnombre.Size = 250;
                sqlparnombre.Value = actividad.Buscar;
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
