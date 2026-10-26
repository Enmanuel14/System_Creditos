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
    public class CN_Actividad
    {
        public static DataTable Mostrar()
        {
            return new CDActividad().Mostrar();
        }
        public static string Insertar(DateTime fechai, DateTime fechaf, string lugar, string nombre, string tipo)
        {
            CDActividad obj = new CDActividad();
            obj.Fecha_Inicio = fechai;
            obj.Fecha_Final = fechaf;
            obj.Lugar = lugar;
            obj.Nombre = nombre;
            obj.Tipo = tipo;
            return CDActividad.Insertar(obj);
        }
        public static string Editar(int id,DateTime fechai, DateTime fechaf, string lugar, string nombre, string tipo)
        {
            CDActividad obj = new CDActividad();
            obj.Id_Actividad = id;
            obj.Fecha_Inicio = fechai;
            obj.Fecha_Final = fechaf;
            obj.Lugar = lugar;
            obj.Nombre = nombre;
            obj.Tipo = tipo;
            return CDActividad.Editar(obj);
        }
        public static DataTable Buscar(string nombre)
        {
            CDActividad obj = new CDActividad();
            obj.Buscar = nombre;
            return CDActividad.Buscar_Nombre(obj);
        }
    }
}
