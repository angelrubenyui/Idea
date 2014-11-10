using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idea.Common.DI;

namespace Idea.Models.Entities
{

    public enum IVAType:short
    {
        Normal = 18,
        Reducido = 7,
        SuperReducido = 4
    }

    public class LineaFactura:EntityBase
    {
        public Int32 FacturaId { get; set; }
        [Required]
        
        public Int32 Cantidad { get; set; }
        public String Descripcion { get; set; }
        
        [Required]
        [EnumDataType(typeof(IVAType))]
        public IVAType IVA { get; set; }
        
        [Required]
        [DataType(DataType.Currency)]
        public Decimal PrecioUnitario { get; set; }

        [CalculatedPVP]
        public Decimal PVP { get; set; }
    }


    public class CalculatedPVPAttribute : ValidationAttribute 
    {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                LineaFactura object2validate = (LineaFactura)validationContext.ObjectInstance;
                var TAX = (short)object2validate.IVA;
                var resultWithoutTax = (object2validate.Cantidad*object2validate.PrecioUnitario);
                var resultWithTaxes = ((resultWithoutTax*TAX)/100) + resultWithoutTax;
                if ((decimal)value == resultWithTaxes)
                    return ValidationResult.Success;
                else
                {
                    if ((decimal)value == resultWithoutTax)
                        return new ValidationResult("No se ha añadido el Calculo de IVA al PVP");
                    else
                        return new ValidationResult("Error al Comprobar el PVP");
                }
            }
    }


}
