using Idea.Common.Exceptions;
using System;
using System.Data.Entity;

namespace Idea.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T:class
    {
        IdeaContext _context;
        IDbSet<T> _dbSet;
        
        public Repository() 
        {
            throw new EFContextNotSetException();
        }

        public Repository(IdeaContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        
        public void Add(T entity) 
        {
            _dbSet.Add(entity);
        }

        public void Remove(T entity) 
        {
            _dbSet.Remove(entity);
        }

        public T Find(Int32 Id)
        {
            return (T)_dbSet.Find(Id);
        }

}
}
