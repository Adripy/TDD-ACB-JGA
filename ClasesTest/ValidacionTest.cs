﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            Assert.AreEqual(null, val.CodigoPostal(cpLargo));
            Assert.AreEqual(null, val.CodigoPostal(cpCorto));
            Assert.AreEqual(null, val.CodigoPostal(cpGrande));

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

            Assert.AreEqual(0, val.NIF(nifLargo));
            Assert.AreEqual(0, val.NIF(nifCorto));
            Assert.AreEqual(0, val.NIF(nifNoLetraIni));
            Assert.AreEqual(0, val.NIF(nifLetraIniMal));
            Assert.AreEqual(0, val.NIF(nifNumConFinalX));
            Assert.AreEqual(0, val.NIF(nifLetConFinalX));
            Assert.AreEqual(0, val.NIF(nifNumConLetraMid));
            Assert.AreEqual(0, val.NIF(nifLetConLetraMid));

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

            Assert.AreEqual(0, val.TarjetaCredito(tcLargo));
            Assert.AreEqual(0, val.TarjetaCredito(tcCorto));
            Assert.AreEqual(1, val.TarjetaCredito(cpMS));// mastercard
            Assert.AreEqual(1, val.TarjetaCredito(cpVisa16)); //visa 16 digitos
            Assert.AreEqual(1, val.TarjetaCredito(cpVisa13)); //visa 13 digitos
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

            Assert.AreEqual(0, val.CuentaCorrienteCliente(cccLargo));
            Assert.AreEqual(0, val.CuentaCorrienteCliente(cccCorto));
            Assert.AreEqual(0, val.CuentaCorrienteCliente(cccConLetras));
            Assert.AreEqual(0, val.CuentaCorrienteCliente(cccConEspecial));
            Assert.AreEqual(0, val.CuentaCorrienteCliente(cccMal));
            Assert.AreEqual(1, val.CuentaCorrienteCliente(ccc));
            Assert.AreEqual(1, val.CuentaCorrienteCliente(ccc1));
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

            Assert.AreEqual(0, val.IBAN(ibanLargo));
            Assert.AreEqual(0, val.IBAN(ibanCorto));
            Assert.AreEqual(0, val.IBAN(ibanSinES));
            Assert.AreEqual(0, val.IBAN(ibanConLetrasMid));
            Assert.AreEqual(0, val.IBAN(ibanConEspecial));
            Assert.AreEqual(0, val.IBAN(ibanMal));
            Assert.AreEqual(1, val.IBAN(iban));
            Assert.AreEqual(1, val.IBAN(iban1));
        }

        [TestMethod]
        public void EmailTest()
        {
            string emailSinArroba = "abcd+-/*dsf.com";
            string emailNoTexArroba = "@abcddsf.com";
            string emailTexArrobaNoTexPunto = "abcdef@.com";
            string emailTexArrobaEspPunto = "abcdef@a+*-d.com";
            string emailTexArrobaTexPuntoNoTex = "abcdef@mail.";
            string emailTexArrobaTexPuntoCar = "abcdef@mail.c";
            string emailTexArrobaTexPunto2MinEsp = "abcdef@mail.c/om";
            string espacio1 = "abcd ef@mail.com";
            string espacio2 = "abcdef@ma il.com";
            string espacio3 = "abcdef@mail.co m";

            //las casos de prueba descritos abarcarian la mayoria de los email de uso actual
            //sabiendo que algunos pasan sin ser realmente válidos
            List<string> emails = new List<string>() {
                "abcdefghfghfghfghfgh@abdfghfghfghfghfghfgh.fghfghfghfghfghfgh",
                "abcde._%+-@yahoo.co",
                "abcde._%+-@abd.es",
                "._%+--+-+-@gmail.uk",
                "jeramie_morar@ya hoo.com",
                "franklin_delano.roosevelt.jr.@aol.com",
                "vladimir_putin@protonmail.como",
                "paula_newby-fraser@yandex.com",
                "abdel_latifabuhaif@hotmail.comun",
                "jamescracknell@outlook.italia"
            };

            Validacion val = new Validacion();

            Assert.AreEqual(0, val.Email(emailSinArroba));
            Assert.AreEqual(0, val.Email(emailNoTexArroba));
            Assert.AreEqual(0, val.Email(emailTexArrobaNoTexPunto));
            Assert.AreEqual(0, val.Email(emailTexArrobaEspPunto));
            Assert.AreEqual(0, val.Email(emailTexArrobaTexPuntoNoTex));
            Assert.AreEqual(0, val.Email(emailTexArrobaTexPuntoCar));
            Assert.AreEqual(0, val.Email(emailTexArrobaTexPunto2MinEsp));
            Assert.AreEqual(0, val.Email(espacio1));
            Assert.AreEqual(0, val.Email(espacio2));
            Assert.AreEqual(0, val.Email(espacio3));

            foreach (string email in emails)
            {
                Assert.AreEqual(1, Email(email));
            }
        }
    }
}