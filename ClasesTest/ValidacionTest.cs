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

        [TestMethod]
        public void TarjetaCreditoTest()
        {
            double tcLargo = 5186484156541656456;
            double tcCorto = 26;
            double cpMS = 5540708689080426; // mastercard
            double cpVisa16 = 4483627710043819; // visa 16
            double cpVisa13 = 4038815174749; // visa 13

            Validacion val = new Validacion();

            Assert.AreEqual(0, TarjetaCredito(tcLargo));
            Assert.AreEqual(0, TarjetaCredito(tcCorto));
            Assert.AreEqual(1, TarjetaCredito(cpMS));// mastercard
            Assert.AreEqual(1, TarjetaCredito(cpVisa16)); //visa 16 digitos
            Assert.AreEqual(1, TarjetaCredito(cpVisa13)); //visa 13 digitos
        }

        [TestMethod]
        public void CuentaCorrienteClienteTest()
        {
            string cccLargo = "5186484156541656456685416485";
            string cccCorto = "26";
            string cccConLetras = "12345678x12345678920";
            string cccConEspecial = "12345678*12345678920";
            string cccMal = "12345678912345678920";
            string ccc = "21039777361834071062"; 
            string ccc1 = "01259353619227879972";

            Validacion val = new Validacion();

            Assert.AreEqual(0, CuentaCorrienteCliente(cccLargo));
            Assert.AreEqual(0, CuentaCorrienteCliente(cccCorto));
            Assert.AreEqual(0, CuentaCorrienteCliente(cccConLetras));
            Assert.AreEqual(0, CuentaCorrienteCliente(cccConEspecial));
            Assert.AreEqual(0, CuentaCorrienteCliente(cccMal));
            Assert.AreEqual(1, CuentaCorrienteCliente(ccc));
            Assert.AreEqual(1, CuentaCorrienteCliente(ccc1));
        }

        [TestMethod]
        public void IBANClienteTest()
        {
            string ibanLargo = "518648415654165645668541648565416451251";
            string ibanCorto = "26";
            string ibanSinES= "12345678123456789201234";
            string ibanConLetrasMid = "ES3456781234x6789201234";
            string ibanConEspecial = "ES345678*1234/6789201234";
            string ibanMal = "123456789123456789201234";
            string iban = "ES8120804769486758368126";
            string iban1 = "ES0201828300476366645481";

            Validacion val = new Validacion();

            Assert.AreEqual(0, IBAN(ibanLargo));
            Assert.AreEqual(0, IBAN(ibanCorto));
            Assert.AreEqual(0, IBAN(ibanSinES));
            Assert.AreEqual(0, IBAN(ibanConLetrasMid));
            Assert.AreEqual(0, IBAN(ibanConEspecial));
            Assert.AreEqual(0, IBAN(ibanMal));
            Assert.AreEqual(1, IBAN(iban));
            Assert.AreEqual(1, IBAN(iban1));
        }


    }
}
