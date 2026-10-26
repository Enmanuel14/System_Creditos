using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaPresentacion
{
    public class CN_Carrera
    {
        public static DataTable Mostrar()
        {
            return new CD_Carrera().Mostrar();
        }
    }
}
