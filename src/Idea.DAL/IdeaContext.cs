using Idea.Common.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idea.DAL
{
    public abstract class IdeaContext: DbContext
    {
        public ILogger log { get; set; }
    }
}
