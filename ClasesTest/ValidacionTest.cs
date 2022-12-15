using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ClasesTest
{
    [TestClass]
    public class ValidacionTest
    {
        [TestMethod]
        public void CodigoPostalTest()
        {
            int cpLargo = 518648415;
            int cpCorto = 26;
            int cpGrande = 68598;

            Dictionary<int, string> codigosPrueba = new Dictionary<int, string>
            {
                { 29570 ,"Málaga" },
                { 41210 ,"Sevilla" } // meter más
            };

            Validacion val = new Validacion();

            Assert.AreEqual(null, CodigoPostal(cpLargo));
            Assert.AreEqual(null, CodigoPostal(cpCorto));
            Assert.AreEqual(null, CodigoPostal(cpGrande));

            foreach (KeyValuePair<int, string> pares in codigosPrueba)
            {
                Assert.AreEqual(pares.Value, CodigoPostal(pares.Key));
            }
        }

        [TestMethod]
        public void NIFTest()
        {
            string nifLargo = "G518648415564GHJ";
            string nifCorto = "G26G";
            string nifNoLetraIni = "645121562";
            string nifLetraIniMal = "O45121562";
            string nifNumConFinalX = "64512156X";
            string nifLetConFinalX = "X4512156X";
            string nifNumConLetraMid = "645M2156X";
            string nifLetConLetraMid = "X45M2156X";

            Dictionary<int, string> nifPrueba = new Dictionary<int, string>
            {
                { 1 ,"12345678A" },
                { 1 ,"12345678W" },
                { 2 ,"K1234567V" },
                { 3 ,"L1234567H" },
                { 4 ,"M1234567B" },
                { 5 ,"X1234567A" },
                { 6 ,"Y1234567P" },
                { 7 ,"Z1234567T" }
            };

            Validacion val = new Validacion();

            Assert.AreEqual(0, NIF(nifLargo));
            Assert.AreEqual(0, NIF(nifCorto));
            Assert.AreEqual(0, NIF(nifNoLetraIni));
            Assert.AreEqual(0, NIF(nifLetraIniMal));
            Assert.AreEqual(0, NIF(nifNumConFinalX));
            Assert.AreEqual(0, NIF(nifLetConFinalX));
            Assert.AreEqual(0, NIF(nifNumConLetraMid));
            Assert.AreEqual(0, NIF(nifLetConLetraMid));

            foreach (KeyValuePair<int, string> pares in nifPrueba)
            {
                Assert.AreEqual(pares.Key, NIF(pares.Value));
            }
        }
    }
}
