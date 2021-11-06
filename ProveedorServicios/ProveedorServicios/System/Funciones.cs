using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProveedorServicios
{
    public class Funciones
    {
        public static void Logs(string nombreArchivo,string descripcion)
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory + "logs/" + DateTime.Now.Year.ToString() + "/" +
                         DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day + "/";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var miDocto = new StreamWriter(dir + "/" + nombreArchivo + ".txt", true);
            var cadena = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ">>>" + descripcion;
            miDocto.WriteLine(cadena);
            miDocto.Close();
        }
    }
}