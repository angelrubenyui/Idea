using Idea.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Idea.DAL.Repositories
{
    public interface IRepository<T> where T:class
    {
        void Add(T entity);
        void Remove(T entity);
        T Find(Int32 Id);
    }

    public interface IRepository
    {
        void Add(EntityBase entity);
        void Remove(EntityBase entity);
        EntityBase Find(Int32 Id);
    }
}
