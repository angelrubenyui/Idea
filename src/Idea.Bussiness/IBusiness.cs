using Idea.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Bussiness
{
    public interface IBusiness
    {
        ILogger Log { get; set; }
    }
}
