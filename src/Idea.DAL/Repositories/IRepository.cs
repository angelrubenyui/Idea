using Idea.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Idea.DAL.Repositories
{
    public interface IRepository 
    {
        T GetById<T>(Int32 primaryKey) ;
        IEnumerable<T> GetAll<T>() ;
        PagedResult<T> PagedQuery<T>(Int32 pageNumber, Int32 pageSize) ;
        void Insert<T>(T itemToAdd) ;
        void Update<T>(T itemToUpdate, Int32 primaryKeyValue) ;
        void Delete<T>(Int32 primaryKeyValue) ;
    }
}
