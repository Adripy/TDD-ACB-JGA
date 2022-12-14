using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClasesTest
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
                sum = sum + (float)1 / numeros[i];

            return (float)Math.Round(numeros.Length / sum,2);
        }

        public float Mediana(float[] numeros)
        {
            Array.Sort(numeros);

            if (numeros.Length % 2 != 0)
                return numeros[((numeros.Length + 1) / 2)-1];

            return (numeros[numeros.Length / 2] + numeros[numeros.Length / 2 - 1]) / 2;
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
            float[] ordenado = new float[numeros.Length];

            ordenado = (float[])numeros.Clone();

            Array.Sort(ordenado);

            float mediana = 0;

            if (ordenado.Length % 2 != 0)
            {
                mediana = ordenado[((ordenado.Length + 1) / 2) - 1];
            }
            else 
            {
                mediana = (ordenado[ordenado.Length / 2] + ordenado[ordenado.Length / 2 - 1]) / 2;
            }
            Console.WriteLine("mediana {0}", mediana);

            for(int i = 0; i < numeros.Length; i++)
            {
                ordenado[i] = (float)Math.Round((float)Math.Abs(numeros[i] - mediana),1);
            }

            return ordenado;
        }

        public float DesviacionMedia(float[] numeros)
        {
            float sum = 0;

            float[] ordenado = new float[numeros.Length];

            ordenado = (float[])numeros.Clone();

            Array.Sort(ordenado);

            float mediana = 0;

            if (ordenado.Length % 2 != 0)
            {
                mediana = ordenado[((ordenado.Length + 1) / 2) - 1];
            }
            else
            {
                mediana = (ordenado[ordenado.Length / 2] + ordenado[ordenado.Length / 2 - 1]) / 2;
            }
            Console.WriteLine("mediana {0}", mediana);

            for (int i = 0; i < numeros.Length; i++)
            {
                sum += (float)Math.Round((float)Math.Abs(numeros[i] - mediana), 1);
            }

            return (float)sum / numeros.Length;
        }
    }
}
