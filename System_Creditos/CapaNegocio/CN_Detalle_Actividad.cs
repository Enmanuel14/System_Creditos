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
    public class CN_Detalle_Actividad
    {
        public static DataTable Mostrar()
        {
            return new CD_Detalle_Actividad().Mostrar();
        }
        public static DataTable BuscarNombre(string buscar)
        {
            CD_Detalle_Actividad Obj = new CD_Detalle_Actividad();
            Obj.Buscar = buscar;
            return Obj.BuscarNombre(Obj);
        }
        public static DataTable BuscarCarnet(string buscar)
        {
            CD_Detalle_Actividad Obj = new CD_Detalle_Actividad();
            Obj.Buscar_Carnet = buscar;
            return Obj.BuscarCarnet(Obj);
        }
        public static string Insertar(int actividad, int alumno, string carnet, string nombre, int horas, int campus, int periodo, int año)
        {
            CD_Detalle_Actividad obj = new CD_Detalle_Actividad();
            obj.Id_Actividad = actividad;
            obj.Id_Alumno = alumno;
            obj.Carnet = carnet;
            obj.Nombres = nombre;
            obj.Horas = horas;
            obj.Id_Campus = campus;
            obj.Id_Periodo = periodo;
            obj.Id_Año = año;
            return CD_Detalle_Actividad.Insertar(obj);
        }
        public static string Editar(int detalle, int actividad, int alumno, string carnet, string nombre, int horas, int campus, int periodo, int año)
        {
            CD_Detalle_Actividad obj = new CD_Detalle_Actividad();
            obj.Id_Detalle = detalle;
            obj.Id_Actividad = actividad;
            obj.Id_Alumno = alumno;
            obj.Carnet = carnet;
            obj.Nombres = nombre;
            obj.Horas = horas;
            obj.Id_Campus = campus;
            obj.Id_Periodo = periodo;
            obj.Id_Año = año;
            return CD_Detalle_Actividad.Editar(obj);
        }
        public static string Eliminar(int detalle)
        {
            CD_Detalle_Actividad obj = new CD_Detalle_Actividad();
            obj.Id_Detalle = detalle;
            return CD_Detalle_Actividad.Eliminar(obj);
        }
    }
}
