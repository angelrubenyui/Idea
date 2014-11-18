using System;
using System.Collections.Generic;
using Idea.Bussiness;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Idea.Models.Entities;

namespace Idea.Bussines.Test
{
    [TestClass]
    public class FacturaManagerTests:Configuration
    {
   
        [TestMethod]
        public void TestSaveFactura()
        {

            //Generamos una factura valida  
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
                Importe = 10
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

            lf.PVP = (((lf.PrecioUnitario * lf.Cantidad) * (short)lf.IVA) / 100) + (lf.PrecioUnitario * lf.Cantidad);


            //Llamamos al FacturaManager.Save
            FacturaManager mngFactura = new FacturaManager();
            List<LineaFactura> lfs = new List<LineaFactura>();
            lfs.Add(lf);
            bool resul = mngFactura.SaveFactura(cliente, factura, lfs);
            Assert.IsTrue(resul);
        }
    }
}
