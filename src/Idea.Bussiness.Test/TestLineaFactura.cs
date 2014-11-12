using System;
using System.Runtime.InteropServices;
using Idea.Common.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Idea.Models.Entities;

namespace Idea.Bussiness.Test
{
    [TestClass]
    public class TestLineaFactura
    {
        [TestMethod]
        public void TestLineaFacturaDefault()
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

            LineaFactura lf = new LineaFactura()
            {
                id = 1,
                FacturaId = 1,
                Cantidad = 1,
                Descripcion = "prueba descripcion",
                PrecioUnitario = 10,
                IVA = IVAType.Normal,
            };

            lf.PVP = (((lf.PrecioUnitario*lf.Cantidad)*(short)lf.IVA)/100) + (lf.PrecioUnitario*lf.Cantidad);
            EntityValidator validator = new EntityValidator(lf);
            Assert.IsTrue(validator.IsValid);
        }

        
        
    }
}
