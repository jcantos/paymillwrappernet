﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymillWrapper.Net;

namespace UnitTest.Net
{
    /// <summary>
    /// Descripción resumida de TestHttpClientRest
    /// </summary>
    [TestClass]
    public class TestHttpClientRest
    {
        public TestHttpClientRest()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la ejecución de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateHttpClientRest()
        {
            HttpClientRest client = new HttpClientRest(
                "https://api.paymill.de/v2", 
                "9a4129b37640ea5f62357922975842a1");
        }

        [TestMethod]
        [ExpectedException(typeof(PaymillWrapper.PaymillException),"ApiUrl is inappropiate or malformed")]
        public void CreateFailedHttpClientRest()
        {
            HttpClientRest client = new HttpClientRest(
                "xxxxxxxxxxxx",
                "9a4129b37640ea5f62357922975842a1");
        }
    }
}
