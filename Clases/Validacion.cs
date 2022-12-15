using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return -1;
        }

        public int TarjetaCredito(double tarjeta)
        {
            return -1;
        }

        public int CuentaCorrienteCliente(string cuenta)
        {
            return -1;
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