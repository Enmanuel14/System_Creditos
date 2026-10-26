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
    public class CN_Campus
    {
        public static DataTable Mostrar()
        {
            return new CD_Campus().Mostrar();
        }
    }
}
