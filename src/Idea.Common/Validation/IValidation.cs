using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Common.Validation
{
    public interface IValidation
    {
        List<IValidationArgument> Arguments { get; set; }
        IEnumerable<ValidationArguments> GetListOfArguments();
    }
}
