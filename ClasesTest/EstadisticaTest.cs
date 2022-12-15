using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases;
using System;

namespace ClasesTest
{
    [TestClass]
    public class EstadisticaTest
    {
        [TestMethod]
        public void MediaAritmeticaTest()
        {
            float[] enteros = { 1, 2, 3, 4, 5 };
            float mediaArEnteros = 3;
            float[] decimales = { 1.5f, 2.3f, 3.2f, 4.5f, 5.1f };
            float mediaArDecimales = 3.32f;
            float[] prueba = { 50, 22, 53, 4, 15 };
            float mediaArPrueba = 28.80f;

            Estadistica es = new Estadistica();

            Assert.AreEqual(es.MediaAritmetica(enteros), mediaArEnteros);
            Assert.AreEqual(es.MediaAritmetica(decimales), mediaArDecimales);
            Assert.AreEqual(es.MediaAritmetica(prueba), mediaArPrueba);
        }

        [TestMethod]
        public void MediaGeometricaTest()
        {
            float[] enteros = { 1, 2, 3, 4, 5 };
            float mediaEnteros = 2.61f;
            float[] decimales = { 1.5f, 2.3f, 3.2f, 4.5f, 5.1f };
            float mediaDecimales = 3.03f;
            float[] prueba = { 50, 22, 53, 4, 15 };
            float mediaPrueba = 20.36f;

            Estadistica es = new Estadistica();

            Assert.AreEqual(es.MediaGeometrica(enteros), mediaEnteros);
            Assert.AreEqual(es.MediaGeometrica(decimales), mediaDecimales);
            Assert.AreEqual(es.MediaGeometrica(prueba), mediaPrueba);
        }

        [TestMethod]
        public void MediaArmonicaTest()
        {
            float[] enteros = { 1, 2, 3, 4, 5 };
            float mediaEnteros = 2.19f;
            float[] decimales = { 1.5f, 2.3f, 3.2f, 4.5f, 5.1f };
            float mediaDecimales = 2.73f;
            float[] prueba = { 50, 22, 53, 4, 15 };
            float mediaPrueba = 12.47f;

            Estadistica es = new Estadistica();

            Assert.AreEqual(es.MediaArmonica(enteros), mediaEnteros);
            Assert.AreEqual(es.MediaArmonica(decimales), mediaDecimales);
            Assert.AreEqual(es.MediaArmonica(prueba), mediaPrueba);
        }

        [TestMethod]
        public void MedianaTest()
        {
            float[] enteros = { 5, 4, 3, 2, 1 };
            float medianaEnteros = 3f;
            float[] decimales = { 1.5f, 2.3f, 3.2f, 4.5f, 5.1f };
            float medianaDecimales = 3.2f;
            float[] pruebaImpar = { 50, 22, 53, 4, 15 };
            float medianaPruebaImpar = 22f;
            float[] pruebaPar = { 1, 2, 3, 4 };
            float medianaPruebaPar = 2.5f;

            Estadistica es = new Estadistica();

            Assert.AreEqual(es.Mediana(enteros), medianaEnteros);
            Assert.AreEqual(es.Mediana(decimales), medianaDecimales);
            Assert.AreEqual(es.Mediana(pruebaImpar), medianaPruebaImpar);
            Assert.AreEqual(es.Mediana(pruebaPar), medianaPruebaPar);
        }

        [TestMethod]
        public void ModaTest()
        {
            float[] enteros = { 5, 4, 3, 2, 1, 2 };
            float[] solEnteros = { 2f };
            float[] decimales = { 1.5f, 2.3f, 3.2f, 4.5f, 5.1f, 3.2f };
            float[] solDecimales = { 3.2f };
            float[] pruebaModaMult = { 50, 22, 53, 4, 15, 50, 53 };
            float[] solPruebaModaMult = { 50, 53 };
            float[] pruebaSinModa = { 1, 2, 3, 4 };
            float[] solPruebaSinModa = { 1, 2, 3, 4 };

            Estadistica es = new Estadistica();

            int count = 0;

            Assert.AreEqual(es.Moda(enteros).Length, solEnteros.Length);

            foreach (float num in es.Moda(enteros)) 
            {
                Assert.AreEqual(num, solEnteros[count]);
                count++;
            }

            count = 0;
            Assert.AreEqual(es.Moda(decimales).Length, solDecimales.Length);
            
            foreach (float num in es.Moda(solDecimales))
            {
                Assert.AreEqual(num, solDecimales[count]);
                count++;
            }
            count = 0;
            Assert.AreEqual(es.Moda(pruebaModaMult).Length, solPruebaModaMult.Length);

            foreach (float num in es.Moda(pruebaModaMult))
            {
                Assert.AreEqual(num, solPruebaModaMult[count]);
                count++;
            }
            count = 0;
            Assert.AreEqual(es.Moda(pruebaSinModa).Length, solPruebaSinModa.Length);

            foreach (float num in es.Moda(pruebaSinModa))
            {
                Assert.AreEqual(num, solPruebaSinModa[count]);
                count++;
            }
        }

        [TestMethod]
        public void DesviacionAbsolutaTest()
        {
            float[] enteros = { 5, 4, 3, 2, 1 };
            float[] solEnteros = { 2, 1, 0, 1, 2 };
            float[] decimales = { 1.5f, 2.3f, 3.2f, 4.5f, 5.1f };
            float[] solDecimales = { 1.7f, 0.9f, 0, 1.3f, 1.9f };
            float[] prueba = { 50, 22, 53, 4, 15 };
            float[] solPrueba = { 28, 0, 31, 18, 7 };

            Estadistica es = new Estadistica();

            int count = 0;

            Assert.AreEqual(es.DesviacionAbsoluta(enteros).Length, solEnteros.Length);

            foreach (float num in es.DesviacionAbsoluta(enteros))
            {
                Assert.AreEqual(num, solEnteros[count]);
                count++;
            }

            count = 0;

            Assert.AreEqual(es.DesviacionAbsoluta(decimales).Length, solDecimales.Length);

            foreach (float num in es.DesviacionAbsoluta(decimales))
            {
                Assert.AreEqual(num, solDecimales[count]);
                count++;
            }

            count = 0;
            
            Assert.AreEqual(es.DesviacionAbsoluta(prueba).Length, solPrueba.Length);

            foreach (float num in es.DesviacionAbsoluta(prueba))
            {
                Assert.AreEqual(num, solPrueba[count]);
                count++;
            }
            //CollectionAssert.AreEqual(es.DesviacionAbsoluta(enteros), solEnteros);
            //CollectionAssert.AreEqual(es.DesviacionAbsoluta(decimales), solDecimales);
            //CollectionAssert.AreEqual(es.DesviacionAbsoluta(prueba), solPrueba);
        }

        [TestMethod]
        public void DesviacionMediaTest()
        {
            float[] enteros = { 5, 4, 3, 2, 1 };
            float solEnteros = 1.2f;
            float[] decimales = { 1.5f, 2.3f, 3.2f, 4.5f, 5.1f };
            float solDecimales = 1.16f;
            float[] prueba = { 50, 22, 53, 4, 15 };
            float solPrueba = 16.8f;

            Estadistica es = new Estadistica();

            Assert.AreEqual(es.DesviacionMedia(enteros), solEnteros);
            Assert.AreEqual(es.DesviacionMedia(decimales), solDecimales);
            Assert.AreEqual(es.DesviacionMedia(prueba), solPrueba);
        }
    }
}
