using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ObjectBuilder2;

namespace Idea.Common.Validation
{
    public class ValidationArgument
    {
        public String Argument { get; private set; }
        public String Field { get; private set; }

        public ValidationArgument(String Field, String Message)
        {
            this.Field = Field;
            this.Argument = Message;
        }

        public ValidationArgument(ValidationResult result)
        {
            this.Argument = result.ErrorMessage;
            foreach (var member in result.MemberNames)
            {
                this.Field = String.Concat(this.Field, "|", member);
            }
        }
    }
}
