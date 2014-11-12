using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Idea.Models.Entities;
using Idea.Common.Validation;
using Idea.Common.Logging;

namespace Idea.Bussiness
{

    public class FacturaManager:IBusiness
    {
        
        public ILogger Log { get; set; }

        public Boolean AreAnyValidationErrors
        {
            get { return (Arguments != null) && (Arguments.Count > 0); }
        }

        public List<ValidationArguments> Arguments { get; set; }

        public FacturaManager()
        {
            Arguments = new List<ValidationArguments>();
        }
        public void SaveFactura(Cliente cliente, Factura factura, List<LineaFactura> lineasFactura)
        {
            //Proceso donde salvamos la factura
            var clientValidation = new ClientValidation();
            if (clientValidation.IsValid(cliente))
            {
                var facturaValidation = new FacturaValidation();
                if (facturaValidation.IsValid(factura))
                {
                    foreach (var lineaFactura in lineasFactura)
                    {
                        var lineaFacturaValidation = new EntityValidator(lineaFactura);
                        if (lineaFacturaValidation.IsValid)
                        {
                            //HAY que GRABAR LA FACTURA!!!
                            //Si el cliente no existe, lo grabamos en la db
                            //Si la factura no existe la grabamos en la db
                            //Grabamos en la db las lineas de factura
                            //Todo Atomico, en una sola Operacion
                        }
                        else
                        {
                            var list = new List<ValidationArguments>();
                            lineaFacturaValidation.errors.ForEach(x => list.Add(new ValidationArguments(x.ErrorMessage)));
                            Arguments.AddRange(list);
                        }
                    }
                }
                else
                {
                    Arguments.AddRange(facturaValidation.GetListOfArguments());
                }
            }
            else
            {
                Arguments.AddRange(clientValidation.GetListOfArguments());
            }

        }

        
    }
}
