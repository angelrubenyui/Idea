using Idea.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Idea.DAL.Repositories;

namespace Idea.DAL
{
    public class FakeRepository : IRepository 
    {
        private FakeUnitOfWork uw { get; set; }

        public FakeRepository(IUnitOfWork unitofWork)
        {
            uw = (FakeUnitOfWork)unitofWork;
        }

        public T GetById<T>(object primaryKey) 
        {
            return (T)uw.Get(primaryKey);
        }

        public IEnumerable<T> Query<T>()  
        {
            return (IEnumerable<T>)uw.getAll<T>();
        }

        public Page<T> PagedQuery<T>(long pageNumber, long itemsPerPage, string sql, params object[] args)
        {
            throw new NotImplementedException();
        }

        public int Insert(object itemToAdd)
        {
            PropertyInfo pId = itemToAdd.GetType().GetProperty("Id");
            if (pId != null)
            {
                uw.Add(pId.GetValue(itemToAdd), itemToAdd);
                return uw.Count();
            }
            else return 0;
        }

        public int Update(object itemToUpdate, object primaryKeyValue)
        {
            uw.Update(primaryKeyValue, itemToUpdate);
            return uw.Count();
        }

        public int Delete<T>(object primaryKeyValue) 
        {
            uw.Remove(primaryKeyValue);
            return uw.Count();
        }
    }
}
