using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Common.Logging
{
    public interface ILogger
    {
        void Exception(Exception exception);
        
        void Verbose(string category, string message);
        
        void Info(string category, string message);
        void Warning(string category, string message);
        
        void Error(string category, string message);

        void Write(TraceLevel level, string category, string message);
        
    }
}
