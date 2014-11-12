using System;
using System.Runtime.Remoting.Channels;
using Idea.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Idea.Bussiness.Test
{
    [TestClass]
    public class TestClientValidation
    {
        [TestMethod]
        public void ClientePersonaFisica()
        {
            Cliente cliente = new Cliente()
            {
                id = 1,
                Nombre = "Pepito",
                Apellidos = "Pacheco",
                CodigoPostal = "08012",
                DateCreation = DateTime.Now,
                Direccion = "c/ El pez molon",
                DNI = "12345678Z",
                isLegal = false
            };
            ClientValidation validation = new ClientValidation();
            Assert.IsTrue(validation.IsValid(cliente));
        }

        [TestMethod]
        public void ClientePersonaJuridica()
        {
            Cliente cliente = new Cliente()
            {
                id = 1,
                RazonSocial = "Laboratorios Imma",
                CodigoPostal = "08012",
                DateCreation = DateTime.Now,
                Direccion = "c/ El pez molon",
                DNI = "C47435599",
                isLegal = true
            };
            ClientValidation validation = new ClientValidation();
            Assert.IsTrue(validation.IsValid(cliente));
        }


        [TestMethod]
        public void ClienteJuridicoFallaConNIF()
        {
            Cliente cliente = new Cliente()
            {
                id = 1,
                RazonSocial = "Laboratorios Imma",
                CodigoPostal = "08012",
                DateCreation = DateTime.Now,
                Direccion = "c/ El pez molon",
                DNI = "12345678Z",
                isLegal = true
            };
            ClientValidation validation = new ClientValidation();
            Assert.IsFalse(validation.IsValid(cliente));
            Assert.AreEqual(validation.Arguments.Count, 1);
        }


        [TestMethod]
        public void ClienteNoJuridicoFallaNIFYNombreMalInformado()
        {
            Cliente cliente = new Cliente()
            {
                id = 1,
                RazonSocial = "Laboratorios Imma",
                CodigoPostal = "08012",
                DateCreation = DateTime.Now,
                Direccion = "c/ El pez molon",
                DNI = "C47435599",
                isLegal = false
            };
            ClientValidation validation = new ClientValidation();
            Assert.IsFalse(validation.IsValid(cliente));
            Assert.AreEqual(validation.Arguments.Count, 2);
        }
    }
}
