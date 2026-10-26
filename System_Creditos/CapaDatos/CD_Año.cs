using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Año
    {
        private int _Id_Año;
        private string _Nombre;
        private string _Buscar;

        public int Id_Año { get => _Id_Año; set => _Id_Año = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Buscar { get => _Buscar; set => _Buscar = value; }

        public CD_Año()
        {

        }
        public CD_Año(int id, string nombre, string buscar)
        {
            this.Id_Año = id;
            this.Nombre = nombre;
            this.Buscar = buscar;
        }
        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("Año_Academico");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                SqlCommand sqlccmd = new SqlCommand();
                sqlccmd.Connection = sqlcon;

                sqlccmd.CommandText = "mostrar_año";
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
