using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clases
{
    public class Estadistica
    {
        public float MediaAritmetica(float[] numeros)
        {
            float sum = 0;

            foreach (float numero in numeros) 
            { 
                sum += numero;
            }

            return  (float)Math.Round(sum/numeros.Length,2);
        }

        public float MediaGeometrica(float[] numeros)
        {
            float sum = 1;

            foreach (float numero in numeros)
            {
                sum *= numero;
            }
            float result = (float)Math.Pow(sum, (float) 1/ numeros.Length);

            return (float)Math.Round(result, 2);
        }

        public float MediaArmonica(float[] numeros)
        {
            float sum = 0;

            for (int i = 0; i < numeros.Length; i++)
                sum += (float)1 / numeros[i];

            return (float)Math.Round(numeros.Length / sum,2);
        }

        public float Mediana(float[] numeros)
        {
            float[] resultado = (float[])numeros.Clone();

            Array.Sort(resultado);

            if (resultado.Length % 2 != 0)
                return resultado[((resultado.Length + 1) / 2)-1];

            return (resultado[resultado.Length / 2] + resultado[resultado.Length / 2 - 1]) / 2;
        }

        public float[] Moda(float[] numeros)
        {       
            var dict = numeros.ToLookup(x => x);

            var numeroModas = dict.Max(x => x.Count());

            var modas = dict.Where(x => x.Count() == numeroModas).Select(x => x.Key);

            return modas.ToArray();
        }

        public float[] DesviacionAbsoluta(float[] numeros)
        {
            float[] resultado = (float[])numeros.Clone();

            float mediana = Mediana(numeros);

            for(int i = 0; i < numeros.Length; i++)
            {
                resultado[i] = (float)Math.Round((float)Math.Abs(resultado[i] - mediana),1);
            }

            return resultado;
        }

        public float DesviacionMedia(float[] numeros)
        {
            float sum = 0;

            float[] deviaciónAbsoluta = DesviacionAbsoluta(numeros);

            for (int i = 0; i < deviaciónAbsoluta.Length; i++)
            {
                sum += deviaciónAbsoluta[i];
            }

            return (float)sum / numeros.Length;
        }
    }
}
