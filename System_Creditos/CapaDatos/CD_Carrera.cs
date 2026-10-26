using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Carrera
    {
        private int _Id_Carrera;
        private string _Nombre;
        private string _Buscar;

        public int Id_Carrera { get => _Id_Carrera; set => _Id_Carrera = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Buscar { get => _Buscar; set => _Buscar = value; }

        public CD_Carrera()
        {

        }
        public CD_Carrera(int idcarrera, string nombre, string buscar)
        {
            this.Id_Carrera = idcarrera;
            this.Nombre = nombre;
            this.Buscar = buscar;
        }
        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("Carrera");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                SqlCommand sqlccmd = new SqlCommand();
                sqlccmd.Connection = sqlcon;

                sqlccmd.CommandText = "mostrar_carrera";
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
    }
}
