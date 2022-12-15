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
            string ubicacion = Utils.GetAbsolutePath("..\\Datos\\Usuarios.csv");
            System.IO.StreamReader archivo = new System.IO.StreamReader(ubicacion);
            char separador = ';';
            string linea;

            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(separador);
                //Usuario u = new Usuario(fila[0], fila[1], fila[2], fila[3]);
                //InsertarUsuario(u);
            }
            return null;
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