using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Common.Exceptions
{
    public class EFContextNotSetException : Exception
    {
        private static string defaultMessage = "Error, No se ha instanciado un DBContext Válido";
        public EFContextNotSetException()
            : base(defaultMessage)
        {
        }

        public EFContextNotSetException(string message)
            : base(message)
        {
        }

        public EFContextNotSetException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
 }
