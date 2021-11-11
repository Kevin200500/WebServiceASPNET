using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsumiendoWebService.ServiceReference1;
using Newtonsoft.Json;

namespace ConsumiendoWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            var clien = new ServiciosSoapClient();


            //var saludo = clien.Saludar("Raul");

            //Console.WriteLine(saludo);

            //var resultado = clien.HelloWorld();
            //ejericio 3
            //var res = clien.GuardaLog("esto es un mensaje para ser guardado en un txt ");
            //Console.WriteLine(res);
            //Console.WriteLine(resultado);

            //Console.WriteLine("Teclea dos numeros: \n");
            //var numero1 = Convert.ToInt32(Console.ReadLine());
            //var numero2 = Convert.ToInt32(Console.ReadLine());
            //var suma = clien.Sumar(numero1, numero2);
            //Console.WriteLine("el resultado es: "+suma);
            //var arreglo = clien.ObtenerMeses();
            //foreach (var item in arreglo)
            //{
            //    Console.WriteLine(item);
            //}
            //var nombres =new ArrayOfString()
            //{
            //    "Kevin",
            //    "Evelyn",
            //    "Raul",
            //    "Larissa",
            //    "Diana",
            //    "Mario",
            //    "Irvin",
            //    "Harold"
            //};
            //var res = clien.GuardarArreglo(nombres);
            //Console.WriteLine(res);
            //var resEmpleado = clien.ObtenerEmpleado();
            //for (var i = 0; i < resEmpleado.Length; i++)
            //{
            //    Console.WriteLine(resEmpleado[i].APELLIDOS + " "+resEmpleado[i].NOMBRE);
            //}
            var xml = "<?xml version='1.0' encoding='UTF-8'?>" +
                      "<documento>" +
                      "<deporte>" +
                      "<![CDATA[Futbol]]>" +
                      "</deporte>" +
                      "<equipos>" +
                      "<equipo>" +
                      "<nombre>" + "<![CDATA[Manchester]]></nombre>" +
                      "<pais><![CDATA[Inglaterra]]></pais>" +
                      "</equipo><equipo>" +
                      "<nombre><![CDATA[Valencia]]></nombre>" +
                      "<pais><![CDATA[España]]></pais>" +
                      "</equipo></equipos>" +
                      "</documento>";
            var result = clien.EnviarXML(xml);
            Console.WriteLine(result);

            //var json = new Dictionary<string, dynamic>
            //{
            //    {"deporte","fultbol"},
            //};
            //var equipos = new List<Dictionary<string, string>>
            //{
            //    new Dictionary<string, string> { { "nombre", "Chelse" }, { "pais", "Inglaterra" } },
            //    new Dictionary<string, string>{{"nombre","tigres"},{"pais","nuevo leon"}}
            //};
            //var result = clien.GuardarJson(JsonConvert.SerializeObject((json)))
            Console.ReadKey();
        }
    }
}
