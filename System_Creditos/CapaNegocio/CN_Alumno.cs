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
    public class CN_Alumno
    {
        public static DataTable Mostrar()
        {
            return new CD_Alumno().Mostrar();
        }
        public static string Insertar(string carnet, string nombre, int carrera)
        {
            CD_Alumno obj = new CD_Alumno();
            obj.Carnet = carnet;
            obj.Nombre = nombre;
            obj.Id_Carrera = carrera;
            return CD_Alumno.Insertar(obj);
        }
        public static string Editar(int id, string carnet, string nombre, int carrera)
        {
            CD_Alumno obj = new CD_Alumno();
            obj.Id_Alumno = id;
            obj.Carnet = carnet;
            obj.Nombre = nombre;
            obj.Id_Carrera = carrera;
            return CD_Alumno.Editar(obj);
        }
        public static DataTable Buscar(string nombre)
        {
            CD_Alumno obj = new CD_Alumno();
            obj.Buscar = nombre;
            return CD_Alumno.Buscar_Nombre(obj);
        }
    }
}
