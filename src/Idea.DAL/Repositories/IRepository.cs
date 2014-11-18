using System.Collections.Generic;
using Idea.Common;

namespace Idea.DAL
{
    public interface IRepository 
    {
        T GetById<T>(object primaryKey);
        IEnumerable<T> Query<T>();
        Page<T> PagedQuery<T>(long pageNumber, long itemsPerPage, string sql, params object[] args);
        int Insert(object itemToAdd);
        int Update(object itemToUpdate, object primaryKeyValue);
        int Delete<T>(object primaryKeyValue);
    }
    
}
