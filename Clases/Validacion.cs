using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Comun;

namespace Clases
{
    public class Validacion
    {
        public string CodigoPostal(int codigoPostal)
        {
            string ubicacion = Utils.GetAbsolutePath("..\\datos\\CPProvincia.csv");

            System.IO.StreamReader archivo = new System.IO.StreamReader(ubicacion,System.Text.Encoding.UTF7);
            char separador = ';';
            string linea;

            Dictionary<string, string> provincias = new Dictionary<string, string>();

            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(separador);
                provincias.Add(fila[0], fila[1]); // se agregan las filas por pares con las columnas
            }

            if (codigoPostal.ToString().Length != 5 )
                return null;

            if (codigoPostal > 52999)
                return null;

            string digitos = codigoPostal.ToString().Substring(0, 2);

            return provincias[digitos];
        }
        public int NIF(string dni)
        {
            if (dni.Length != 9)
                return 0;

            if (!Regex.IsMatch(dni.Substring(8), @"^[TRWAGMYFPDXBNJZSQVHLCKE]$")) // si el caracter final es diferente de TRWAGMYFPDXBNJZSQVHLCKE
                return 0;

            if (!Regex.IsMatch(dni.Substring(0,1), @"^[0-9KLMXYZ]$")) // si el caracter inicial es diferente de KLMXYZ
                return 0;

            if (!Regex.IsMatch(dni.Substring(1, 7), @"^[0-9]+$")) // si algun caracter intermedio es diferente de dígito
                return 0;

            switch (dni.Substring(0, 1))
            {
                case "K":
                    return 2;
                case "L":
                    return 3;
                case "M":
                    return 4;
                case "X":
                    return 5;
                case "Y":
                    return 6;
                case "Z":
                    return 7;
                default:
                    return 1;
            }
        }

        public int TarjetaCredito(long tarjeta)
        {
            if (tarjeta.ToString().Length != 13 && tarjeta.ToString().Length != 16)
                return 0;
            
            if (tarjeta.ToString()
                        .Reverse() // lo voltea
                        .Select(c => (int)char.GetNumericValue(c)) //coge numero a numero
                        .Select((n, i) => ((i % 2) == 0) ? n : n * 2) //los impares los deja como estan los pares los multiplica por 2
                        .Select(n => n > 9 ? n - 9 : n) //Toma el 1º dígito de las unidades 
                        .Sum() % 10 == 0) // suma todos los anteriores y se hace modulo de 10, si da 0 es válido
                return 1;

            return 0;
        }

        public int CuentaCorrienteCliente(string cuenta)
        {
            if (cuenta.ToString().Length != 13)
                return 0;

            if (cuenta.ToString()
                        .Reverse() // lo voltea
                        .Select(c => (int)char.GetNumericValue(c)) //coge numero a numero
                        .Select((n, i) => ((i % 2) == 0) ? n : n * 2) //los impares los deja como estan los pares los multiplica por 2
                        .Select(n => n > 9 ? n - 9 : n) //Toma el 1º dígito de las unidades 
                        .Sum() % 10 == 0) // suma todos los anteriores y se hace modulo de 10, si da 0 es válido
                return 1;

            return 0;
        }

        public int IBAN(string iban)
        {
            return -1;
        }
        public int Email(string email)
        {
            return -1;
        }
    }
}