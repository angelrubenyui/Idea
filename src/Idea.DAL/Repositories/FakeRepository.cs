using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idea.Models.Entities;
using System.Reflection;

namespace Idea.DAL.Repositories
{
    public class FakeRepository : IRepository
    {
        private Hashtable Storage { get; set; }

        public FakeRepository()
        {
            Storage = new Hashtable();
        }

        public T GetById<T>(Int32 primaryKey) 
        {
            return (T)Storage[primaryKey];
        }

        public IEnumerable<T> GetAll<T>() 
        {
            return (IEnumerable<T>)Storage.Values.Cast<T>().ToList();
        }

        public PagedResult<T> PagedQuery<T>(Int32 pageNumber, Int32 pageSize) 
        {
            PagedResult<T> myPageResult = new PagedResult<T>();

            myPageResult.Collection = (IEnumerable<T>)Storage.Values.Cast<T>().ToList().Skip(pageSize * pageNumber).Take(pageSize);
            return myPageResult;
        }

        public void Insert<T>(T itemToAdd) 
        {
            PropertyInfo pId = itemToAdd.GetType().GetProperty("Id");
            if (pId != null)
            {
                Storage.Add(pId.GetValue(itemToAdd), itemToAdd);
            }
        }

        public void Update<T>(T itemToUpdate, Int32 primaryKeyValue) 
        {
            Storage[primaryKeyValue] = itemToUpdate;
        }

        public void Delete<T>(Int32 primaryKeyValue) 
        {
            Storage.Remove(primaryKeyValue);
        }
    }
}
