using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClasesTest
{
    [TestClass]
    public class EstadisticaTest
    {
        [TestMethod]
        public void MediaAritmeticaTest()
        {
            int[] enteros = { 1, 2, 3, 4, 5};
            float mediaArEnteros = 3;
            float[] decimales = { 1.5f, 2.3f, 3.2f, 4.5f, 5.1f };
            float mediaArDecimales = 3.32f;
            char[] caracteres = { 'a', 'b', 'c', 'd', 'e' };
            int[] prueba = { 50, 22, 53, 4, 15 };
            float mediaArPrueba = 28.8f;

            Estadistica es = new Estadistica();

            Assert.AreEqual(es.MediaAritmetica(enteros), mediaArEnteros);
            Assert.AreEqual(es.MediaAritmetica(decimales), mediaArDecimales);
            Assert.ThrowsException(es.MediaAritmetica(caracteres));
            Assert.AreEqual(es.MediaAritmetica(prueba), mediaArPrueba);
        }
    }

    [TestMethod]
    public void MediaGeometricaTest()
    {
        int[] enteros = { 1, 2, 3, 4, 5 };
        float mediaEnteros = 2.605f;
        float[] decimales = { 1.5f, 2.3f, 3.2f, 4.5f, 5.1f };
        float mediaDecimales = 3.025f;
        char[] caracteres = { 'a', 'b', 'c', 'd', 'e' };
        int[] prueba = { 50, 22, 53, 4, 15 };
        float mediaPrueba = 20.359f;

        Estadistica es = new Estadistica();

        Assert.AreEqual(es.MediaGeometrica(enteros), mediaEnteros);
        Assert.AreEqual(es.MediaGeometrica(decimales), mediaDecimales);
        Assert.ThrowsException(es.MediaGeometrica(caracteres));
        Assert.AreEqual(es.MediaGeometrica(prueba), mediaPrueba);
    }

    [TestMethod]
    public void MediaArmonicaTest()
    {
        int[] enteros = { 1, 2, 3, 4, 5 };
        float mediaEnteros = 2.19f;
        float[] decimales = { 1.5f, 2.3f, 3.2f, 4.5f, 5.1f };
        float mediaDecimales = 2.73f;
        char[] caracteres = { 'a', 'b', 'c', 'd', 'e' };
        int[] prueba = { 50, 22, 53, 4, 15 };
        float mediaPrueba = 12.47f;

        Estadistica es = new Estadistica();

        Assert.AreEqual(es.MediaArmonica(enteros), mediaEnteros);
        Assert.AreEqual(es.MediaArmonica(decimales), mediaDecimales);
        Assert.ThrowsException(es.MediaArmonica(caracteres));
        Assert.AreEqual(es.MediaArmonica(prueba), mediaPrueba);
    }

    [TestMethod]
    public void MedianaTest()
    {
        int[] enteros = { 5,4,3,2,1 };
        float medianaEnteros = 3f;
        float[] decimales = { 1.5f, 2.3f, 3.2f, 4.5f, 5.1f };
        float medianaDecimales = 3.2f;
        char[] caracteres = { 'a', 'b', 'c', 'd', 'e' };
        int[] pruebaImpar = { 50, 22, 53, 4, 15 };
        float medianaPruebaImpar = 22f;
        int[] pruebaPar = { 1, 2, 3, 4};
        float medianaPruebaPar = 2.5f;

        Estadistica es = new Estadistica();

        Assert.AreEqual(es.Mediana(enteros), medianaEnteros);
        Assert.AreEqual(es.Mediana(decimales), medianaDecimales);
        Assert.ThrowsException(es.Mediana(caracteres));
        Assert.AreEqual(es.Mediana(pruebaImpar), medianaPruebaImpar);
        Assert.AreEqual(es.Mediana(pruebaPar), medianaPruebaPar);
    }

    [TestMethod]
    public void ModaTest()
    {
        int[] enteros = { 5, 4, 3, 2, 1, 2};
        float[] solEnteros = { 2f };
        float[] decimales = { 1.5f, 2.3f, 3.2f, 4.5f, 5.1f, 3.2f};
        float[] solDecimales = { 3.2f };
        char[] caracteres = { 'a', 'b', 'c', 'd', 'e' };
        int[] pruebaModaMult = { 50, 22, 53, 4, 15 ,50 ,53};
        float[] solPruebaModaMult = { 50, 53 };
        int[] pruebaSinModa = { 1, 2, 3, 4 };
        float[] solPruebaSinModa = { };

        Estadistica es = new Estadistica();

        Assert.AreEqual(es.Moda(enteros), solEnteros);
        Assert.AreEqual(es.Moda(decimales), solDecimales);
        Assert.ThrowsException(es.Moda(caracteres));
        Assert.AreEqual(es.Moda(pruebaModaMult), solPruebaModaMult);
        Assert.AreEqual(es.Moda(pruebaSinModa), solPruebaSinModa);
    }

    [TestMethod]
    public void DesviacionAbsolutaTest()
    {
        int[] enteros = { 5, 4, 3, 2, 1};
        float[] solEnteros = { 2, 1, 0, 1, 2};
        float[] decimales = { 1.5f, 2.3f, 3.2f, 4.5f, 5.1f };
        float[] solDecimales = { 1.7f, 0.9f, 0, 0.7f, 1.9f };
        char[] caracteres = { 'a', 'b', 'c', 'd', 'e' };
        int[] prueba= { 50, 22, 53, 4, 15};
        float[] solPrueba = { 28, 0, 31, 18, 7 };

        Estadistica es = new Estadistica();

        Assert.AreEqual(es.DesviacionAbsoluta(enteros), solEnteros);
        Assert.AreEqual(es.DesviacionAbsoluta(decimales), solDecimales);
        Assert.ThrowsException(es.DesviacionAbsoluta(caracteres));
        Assert.AreEqual(es.DesviacionAbsoluta(prueba), solPrueba);
    }

    [TestMethod]
    public void DesviacionMediaTest()
    {
        int[] enteros = { 5, 4, 3, 2, 1 };
        float solEnteros = 1.2f;
        float[] decimales = { 1.5f, 2.3f, 3.2f, 4.5f, 5.1f };
        float solDecimales = 1.04f;
        char[] caracteres = { 'a', 'b', 'c', 'd', 'e' };
        int[] prueba = { 50, 22, 53, 4, 15 };
        float solPrueba = 16.8f;

        Estadistica es = new Estadistica();

        Assert.AreEqual(es.DesviacionMedia(enteros), solEnteros);
        Assert.AreEqual(es.DesviacionMedia(decimales), solDecimales);
        Assert.ThrowsException(es.DesviacionMedia(caracteres));
        Assert.AreEqual(es.DesviacionMedia(prueba), solPrueba);
    }
}
