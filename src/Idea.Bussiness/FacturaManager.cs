using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Idea.Common.DI;
using Idea.DAL;
using Idea.Models.Entities;
using Idea.Common.Validation;
using Idea.Common.Logging;

namespace Idea.Bussiness
{

    public class FacturaManager:IBusiness
    {
        
        public ILogger Log { get; set; }
        public IUnitOfWork TransactProvider { get; set; }
        public Boolean AreAnyValidationErrors
        {
            get { return (Arguments != null) && (Arguments.Count > 0); }
        }

        public List<ValidationArgument> Arguments { get; set; }

        public FacturaManager()
        {
            Arguments = new List<ValidationArgument>();
        }

        public Boolean SaveFactura(Cliente cliente, Factura factura, List<LineaFactura> lineasFactura)
        {
            //Proceso donde salvamos la factura
            var UoW = DependencyHelper.Resolve<IUnitOfWork>();
            var clientValidation = new ClientValidation();
            if (clientValidation.IsValid(cliente))
            {
                var CRepo = DependencyHelper.ResolveWithInstance<IRepository,IUnitOfWork>("unitofWork", UoW);
                var facturaValidation = new FacturaValidation();
                if (facturaValidation.IsValid(factura))
                {
                    var FRepo = DependencyHelper.ResolveWithInstance<IRepository,IUnitOfWork>("unitofWork", UoW);
                    var LFRepo = DependencyHelper.ResolveWithInstance<IRepository,IUnitOfWork>("unitofWork", UoW);
                    foreach (var lineaFactura in lineasFactura)
                    {
                        var lineaFacturaValidation = new EntityValidator(lineaFactura);
                        if (lineaFacturaValidation.IsValid)
                        {
                            LFRepo.Insert(lineaFactura);
                        }
                        else
                        {
                            lineaFacturaValidation.errors.ForEach(x=>
                            {
                                Arguments.Add(new ValidationArgument(x));
                            });
                            UoW.Rollback();
                            return false;
                        }
                    }
                    FRepo.Insert(factura);
                }
                else
                {
                    Arguments.AddRange(facturaValidation.Arguments);
                    UoW.Rollback();
                    return false;
                }
                CRepo.Insert(cliente);
            }
            else
            {
                Arguments.AddRange(clientValidation.Arguments);
                UoW.Rollback();
                return false;
            }

            UoW.Commit();
            return true;
        }

        
    }
}
