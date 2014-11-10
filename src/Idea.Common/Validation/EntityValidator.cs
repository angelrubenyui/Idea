using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Common.Validation
{
    public class EntityValidator
    {
        private ValidationContext validationContext { get; set; }
        public List<ValidationResult> errors { get; set; }
        public Boolean IsValid { get; set; }

        public EntityValidator(Object Object2Validate)
        {
            validationContext = new ValidationContext(Object2Validate, null, null);
            errors = new List<ValidationResult>();
            IsValid = Validator.TryValidateObject(Object2Validate, validationContext, errors, true);
        }
    }
}
