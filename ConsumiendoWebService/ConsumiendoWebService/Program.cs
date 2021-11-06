using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsumiendoWebService.ServiceReference1;

namespace ConsumiendoWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.ServiciosSoapClient clien = new ServiciosSoapClient();

            var resultado = clien.HelloWorld();
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
            var resEmpleado = clien.ObtenerEmpleado();
            for (var i = 0; i < resEmpleado.Length; i++)
            {
                Console.WriteLine(resEmpleado[i].APELLIDOS + " "+resEmpleado[i].NOMBRE);
            }
            Console.ReadKey();
        }
    }
}
