using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ProveedorServicios;

namespace ProveedorServicios
{
    /// <summary>
    /// Descripción breve de Servicios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Servicios : System.Web.Services.WebService
    {

        [WebMethod(Description = "Metodo el que saluda")]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod(Description = "Metodo Con parametro")]
        public string Saludar(string nombre)
        {
            return "Hola a "+nombre;
        }
        [WebMethod(Description = "Guarda Log")]
        public string GuardaLog(string mensaje)
        {
            Funciones.Logs("LogsServicios",mensaje);
            return "OK";
        }
        [WebMethod(Description = "Metodo de suma")]
        public decimal Sumar(int n1, int n2)
        {
            var suma = (decimal)n1 + n2;
            return suma;
        }
        [WebMethod(Description = "Metodo que retorna un arreglo")]
        public string[] ObtenerMeses()
        {
            var meses = new []
            {
                "Enero",
                "Febrero",
                "Marzo"
            };
            return meses;
        }
        [WebMethod(Description = "Metodo que guarda un arreglo")]
        public string GuardarArreglo(string[] arreglo)
        {
            try
            {
                for (var i = 0; i < arreglo.Length; i++)
                {
                    Funciones.Logs("Nombres",arreglo[i]);
                }
                return "OK";
            }
            catch (Exception e)
            {
                return "error";
            }
            
        }

        [WebMethod(Description = "Metodo que retorna un lista de objetos")]
        public List<Empleados> ObtenerEmpleado()
        {
            var listEmpleados = new List<Empleados>()
            {
                new Empleados() { NOMBRE = "Kevin", APELLIDOS = "Rivas" },
                new Empleados() { NOMBRE = "Roberto", APELLIDOS = "Aguilar" },
                new Empleados() { NOMBRE = "Larissa", APELLIDOS = "Dominguez" }
            };
            return listEmpleados;
        }
    }
}
