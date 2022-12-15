using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
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

        public int CodigoCuentaCliente(string cuenta)
        {
            if (cuenta.ToString().Length != 20)
                return 0;

            if (!cuenta.All(char.IsDigit))
                return 0;

            string entidadOficina = "00";
            entidadOficina = entidadOficina + cuenta.Substring(0, 8);
            string cuentaBancaria = cuenta.Substring(10);

            int[] pesos = { 1, 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            int suma = 0;
            int digito;

            for (int i = 0; i < pesos.Length; i++)
            {
                suma += pesos[i] * int.Parse(entidadOficina.Substring(i, 1));
            }
            digito = 11 - (suma % 11);

            if (digito == 10)
                digito = 1;

            if (digito == 11)
                digito = 0;


            if (digito.ToString() != cuenta.Substring(8, 1))
                return 0;

            suma = 0;

            for (int i = 0; i < pesos.Length; i++)
            {
                suma += pesos[i] * int.Parse(cuentaBancaria.Substring(i, 1));
            }
            digito = 11 - (suma % 11);

            if (digito == 10)
                return 1;

            if (digito == 11)
                digito = 0;
  
            if (digito.ToString() != cuenta.Substring(9, 1))
                return 0;

            return 1;
        }

        public int IBAN(string iban)
        {
            if (iban.ToString().Length != 24)
                return 0;

            string extension = iban.Substring(0, 2);
            string resto = iban.Remove(0, 4);

            if (extension != "ES")
                return 0;

            if (!resto.All(char.IsDigit))
                return 0;

            ulong calculo = ulong.Parse(resto + "142800") % 97 - 98;
            string resultado = "";

            if (calculo < 10)
            {
                resultado = "0" + calculo.ToString();
            }
            else 
            {
                resultado = calculo.ToString();
            }

            if (resultado != iban.Substring(2, 2))
                return 0;

            return 1;
        }

        public int Email(string email)
        {
            if (Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                return 1;

            return 0;
        }
    }
}