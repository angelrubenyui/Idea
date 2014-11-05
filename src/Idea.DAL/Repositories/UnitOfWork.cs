using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idea.DAL.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T:class
    {
        private IdeaContext _context;
        private IRepository<T> _Repository;

        public UnitOfWork(IdeaContext context)
        {
            _context = context;
        }

        public IRepository<T> Repository
        {
            get
            {
                if (_Repository == null)
                {
                    _Repository = new Repository<T>(_context);
                }
                return _Repository;
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
