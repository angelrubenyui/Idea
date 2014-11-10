using System;
using Idea.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Idea.Bussiness.Test
{
    [TestClass]
    public class TestFacturaValidation
    {
        [TestMethod]
        public void TestFacturaValida()
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
            Factura factura = new Factura()
            {
                id=1,
                clienteAsociado = cliente,
                ClienteId = 1,
                Codigo = "FAC001",
                FechaEmision = DateTime.Now,
                Importe = 15
            };
            FacturaValidation validation = new FacturaValidation();
            Assert.IsTrue(validation.IsValid(factura));
        }

        [TestMethod]
        public void TestFacturaInValida()
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
            Factura factura = new Factura()
            {
                id = 1,
                clienteAsociado = cliente,
                ClienteId = 1,
                Codigo = "FAC001",
                FechaEmision = DateTime.Now,
                Importe = -1
            };
            FacturaValidation validation = new FacturaValidation();
            Assert.IsTrue(!validation.IsValid(factura));
        }
    }
}
