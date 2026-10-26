using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CD_Periodo
    {
        private int _Id_Periodo;
        private string _Periodo;
        private string _Buscar;

        public int Id_Periodo { get => _Id_Periodo; set => _Id_Periodo = value; }
        public string Periodo { get => _Periodo; set => _Periodo = value; }
        public string Buscar { get => _Buscar; set => _Buscar = value; }

        public CD_Periodo()
        {

        }
        public CD_Periodo(int id, string periodo, string buscar)
        {
            this.Id_Periodo = id;
            this.Periodo = periodo;
            this.Buscar = buscar;
        }
        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("Periodo");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                SqlCommand sqlccmd = new SqlCommand();
                sqlccmd.Connection = sqlcon;

                sqlccmd.CommandText = "mostrar_periodo";
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
