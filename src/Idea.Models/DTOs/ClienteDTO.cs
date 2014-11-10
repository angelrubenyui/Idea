using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Idea.Models.DTOs
{
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class ClienteDTO
    {
        [DataMember]
        public Int32 id { get; set; }
        [DataMember]
        public DateTime DateCreation { get; set; }
        [DataMember]
        public DateTime DateModification { get; set; }
        [DataMember]
        public DateTime DateDelete { get; set; }
        [DataMember]
        public String EntityComments { get; set; }
        [DataMember]
        public String DNI { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String Nombre { get; set; }
        [DataMember]
        public String Apellidos { get; set; }
        [DataMember]
        public DateTime FechaNacimiento { get; set; }
        [DataMember]
        public Boolean isLegal { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String CodigoPostal { get; set; }
    }
}
