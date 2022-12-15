using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesTest
{
    public class Validacion
    {
        public string CodigoPostal()
        {
            string ubicacion = GetAbsolutePath("..\\Datos\\Usuarios.csv");
            System.IO.StreamReader archivo = new System.IO.StreamReader(ubicacion);
            char separador = ';';
            string linea;

            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(separador);
                Usuario u = new Usuario(fila[0], fila[1], fila[2], fila[3]);
                InsertarUsuario(u);
            }
            return null;
        }
    }
}
