using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idea.DAL.Repositories
{
    public interface IUnitOfWork<T> where T:class
    {
        IRepository<T> Repository { get; }
        void SaveChanges();
    }

    public interface IUnitOfWork
    {
        IRepository Repository { get; }
        void SaveChanges();
    }
}
