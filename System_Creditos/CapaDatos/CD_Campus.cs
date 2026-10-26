using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Campus
    {
        private int _Id_Campus;
        private string _Campus;
        private string _Buscar;

        public int Id_Campus { get => _Id_Campus; set => _Id_Campus = value; }
        public string Campus { get => _Campus; set => _Campus = value; }
        public string Buscar { get => _Buscar; set => _Buscar = value; }

        public CD_Campus()
        {

        }
        public CD_Campus(int id, string campus, string buscar)
        {
            this.Id_Campus = id;
            this.Campus = campus;
            this.Buscar = buscar;
        }
        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("Campus");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                SqlCommand sqlccmd = new SqlCommand();
                sqlccmd.Connection = sqlcon;

                sqlccmd.CommandText = "mostrar_campus";
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
