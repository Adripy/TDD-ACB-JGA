using System;
using System.CodeDom;
using System.Text;
using System.Text.RegularExpressions;
namespace Comun
{
    public static class Utils
    {
        private static Regex reg = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$");
        private static Regex regDos = new Regex(@"^[\w!#$%&'+-/=?^_`{|}~]+(.[\w!#$%&'+-/=?^_`{|}~]+)*@((([-\w]+.)+[a-zA-Z]{2,4})|(([0-9]{1,3}.){3}[0-9]{1,3}))\z");
        // Encripta en base 64 el string pasado
        // retorna el string encriptado.
        public static string Encriptar(string password)
        {
            byte[] encriptado = Encoding.Unicode.GetBytes(password);
            return Convert.ToBase64String(encriptado);
        }

        // Desencripta el string pasado en base 64
        // retorna el string desencriptado.
        public static string Desencriptar(string passwordEncriptada)
        {
            byte[] desencriptar = Convert.FromBase64String(passwordEncriptada);
            return Encoding.Unicode.GetString(desencriptar);
        }

        // Valida si la contraseña cumple con los requisitos
        // retorna true si cumple, false si no.
        public static bool ValidarPassword(string password)
        {
            return reg.IsMatch(password);
        }

        // Valida si el email cumple con los requisitos
        // retorna true si cumple, false si no.
        public static bool ValidarEmail(string email)
        {
            return regDos.IsMatch(email);
        }

        // Obtiene la ruta absoluta a un fichero.
        public static string GetAbsolutePath(string relativePath)
        {

            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            int lastIndex = path.LastIndexOf("bin", StringComparison.OrdinalIgnoreCase);
            string actualPath = path.Substring(0, lastIndex);
            string projectPath = new Uri(actualPath).LocalPath;
            string absolutePath = projectPath + relativePath;

            return absolutePath;

        }
    }
}