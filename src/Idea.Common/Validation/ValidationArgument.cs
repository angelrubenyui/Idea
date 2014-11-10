using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Common.Validation
{
    public class ValidationArguments : IValidationArgument
    {
        public String Argument { get; private set; }
        public ValidationArguments(String Message)
        {
            this.Argument = Message;
        }
    }
}
