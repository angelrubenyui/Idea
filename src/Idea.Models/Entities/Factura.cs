using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Idea.Common.Validation;

namespace Idea.Models.Entities
{
    public class Factura: EntityBase
    {
        public String Codigo { get; set; }
        [Required]  
        public DateTime FechaEmision { get; set; }
        [Required]
        [Range(0,9999999)]
        public decimal Importe { get; set; }
        public Int32 ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public virtual Cliente clienteAsociado { get; set; }
    }

    public class FacturaValidation : IValidation
    {
        public List<IValidationArgument> Arguments{get; set; }

        public IEnumerable<ValidationArguments> GetListOfArguments()
        {
            return (IEnumerable<ValidationArguments>)Arguments.AsEnumerable();
        }

        public FacturaValidation()
        {
           Arguments = new List<IValidationArgument>();
        }

        public Boolean IsValid(Factura factura)
        {
            var ret = true;
            ValidationContext validationContext = new ValidationContext(factura, null, null);
            List<ValidationResult> errors = new List<ValidationResult>();
            ret = Validator.TryValidateObject(factura, validationContext, errors, true);
            if (!ret)
            {
                errors.ForEach(x=> Arguments.Add(new ValidationArguments(x.ErrorMessage)));
            }

            return ret;
        }
    }
}
