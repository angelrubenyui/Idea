using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Idea.Common;

namespace Idea.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        Database Db { get;}
        void Rollback();
        void Commit();
    }
}
