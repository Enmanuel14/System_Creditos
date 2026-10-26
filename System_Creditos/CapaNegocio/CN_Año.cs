using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Año
    {
        public static DataTable Mostrar()
        {
            return new CD_Año().Mostrar();
        }
    }
}
