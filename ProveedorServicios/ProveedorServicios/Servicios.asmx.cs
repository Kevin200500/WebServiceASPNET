using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ProveedorServicios;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

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
                "Marzo",
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
        [WebMethod(Description = "Metodo que retorna un XML")]
        public string EnviarXML(string xml)
        {
            var data_xml = new XmlDocument();

            data_xml.LoadXml(xml);

            var documento = data_xml.SelectSingleNode("documento");
            var deporte = documento["deporte"].InnerText;

            Funciones.Logs("ARCHIVO_XML","Deporte: "+ deporte+"; Equipos:");
            var node_equipos = data_xml.GetElementsByTagName("equipo");

            
            var equipos = ((XmlElement)node_equipos[0]).GetElementsByTagName("equipo");

            foreach (XmlElement item in equipos)
            {
                var nombre = item.GetElementsByTagName("nombre")[0].InnerText;
                var pais = item.GetElementsByTagName("pais")[0].InnerText;
                Funciones.Logs("XML",nombre+"-"+pais);
            }

            return "OK";
        }
        [WebMethod(Description = "Metodo que retorna un json")]
        public string RetornarJSON()
        {
            var json = new Dictionary<string, dynamic>();

            json.Add("equipos","Futbol");
            var equipos = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "nombre", "America" },
                    { "pais", "mexico" }
                },
                new Dictionary<string, string>
                {
                    { "nombre", "LA Galaxy" },
                    { "pais", "USA" }
                }
            };
            json.Add("equipos",equipos);
            return JsonConvert.SerializeObject(json);
        }

        [WebMethod(Description = "Metodo que Guarda un json")]
        public string GuardarJSON(string json)
        {
            var data = JsonConvert.DeserializeObject<DataJson>(json);
            Funciones.Logs("JSON","Deporte: "+data.deporte+" equipos: ");
            for (var i = 0; i < data.equipos.Count; i++)
            {
                Funciones.Logs("JSON", "nombre: " + data.equipos[i].nombre + " -- "+data.equipos[i].pais);
            }
            return "OK";
        }
        internal class DataJson
        {
            public string deporte { get; set; }
            public List<Equipos> equipos { get; set; }
        }
        internal class Equipos
        {
            public string nombre { get; set; }
            public string pais { get; set; }
        }
    }
}
