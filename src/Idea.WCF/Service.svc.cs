using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Idea.Models.Contracts;
using Idea.Models.DTOs;

namespace Idea.WCF
{
    public class Service1 : IMarketingService
    {

        public List<ClienteDTO> GetClientsWithFacturationMoreBigThan(Decimal Amount)
        {
            return new List<ClienteDTO>();
        }

        public List<ClienteDTO> GetClientsFromZipCode(String ZipCode)
        {
            if (ZipCode == null)
            {
                throw new ArgumentNullException("ZipCodeInvalid");
            }
            return new List<ClienteDTO>();
        }
    }
}
