using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Threading.Tasks;
using Idea.Common.Validation;


namespace Idea.Models.Entities
{
    public class Cliente:EntityBase
    {
        public String DNI { get; set; }
        public String RazonSocial { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Boolean isLegal { get; set; }
        public String Direccion { get; set; }
        public String CodigoPostal { get; set; }
    }

    public class ClientValidation : IValidation
    {
        public List<IValidationArgument> Arguments { get; set; }

        public ClientValidation()
        {
            Arguments = new List<IValidationArgument>();
        }

        public IEnumerable<ValidationArguments> GetListOfArguments()
        {
            return (IEnumerable<ValidationArguments>) Arguments.AsEnumerable();
        }

        public Boolean IsValid(Cliente cliente)
        {
            Boolean ret = true;
            //Validaciones de DataAnnotations


            //Validaciones De Negocio
            if (!IsDNIValid(cliente))
            {
                Arguments.Add(new ValidationArguments("Validación de Cliente: DNI Incorrecto"));
                ret = false;
            }
            if (cliente.isLegal && !IsFilledIfLegal(cliente))
            {
                Arguments.Add(new ValidationArguments("Validación de Cliente, No está informada la Razon social para un Cliente Jurídico"));
                ret= false;
            }
            if (!cliente.isLegal && !IsFilledIfNoLegal(cliente))
            {
                Arguments.Add(new ValidationArguments("Validación de Cliente, No está informado Nombre y Apellidos para un Cliente Físico"));
                ret =false;
            }
            return ret;
        }

        private Boolean IsDNIValid(Cliente cliente)
        {
            var validation = NIFValidation.CheckNif(cliente.DNI);
            if (!cliente.isLegal)
            {
                if (validation.TipoNif == NIFValidation.TiposCodigosEnum.NIE ||
                    validation.TipoNif == NIFValidation.TiposCodigosEnum.NIF)
                    return validation.EsCorrecto;
                else
                    return false;
            }
            else
            {
                if (validation.TipoNif == NIFValidation.TiposCodigosEnum.CIF)
                    return validation.EsCorrecto;
                else return false;
            }
        }

        private Boolean IsFilledIfLegal(Cliente cliente)
        {
            return (!String.IsNullOrEmpty(cliente.RazonSocial));
        }

        private Boolean IsFilledIfNoLegal(Cliente cliente)
        {
            return (!String.IsNullOrEmpty(String.Concat(cliente.Nombre, cliente.Apellidos)));
        }

    }
}
