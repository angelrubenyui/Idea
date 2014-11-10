using Idea.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Models.Contracts
{
    [ServiceContract]
    public interface IMarketingService
    {
        [OperationContract]
        List<ClienteDTO> GetClientsWithFacturationMoreBigThan(Decimal Amount);

        [OperationContract]
        List<ClienteDTO> GetClientsFromZipCode(String ZipCode);

    }
}
