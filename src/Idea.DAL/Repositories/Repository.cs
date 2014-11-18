using System.Linq;
using System.Threading;
using Idea.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using Idea.Models.Entities;

namespace Idea.DAL.Repositories
{
    public class Repository<T> : IRepository 
    {
        private IUnitOfWork mUnitOfWork { get; set; } 

        public Repository() 
        {
            throw new EFContextNotSetException();
        }

        public Repository(IUnitOfWork unitOfWork )
        {
            mUnitOfWork = unitOfWork;
        }
   
        public T GetById<T>(Int32 primaryKey)
        {
            return (T)mUnitOfWork.Context.Set(typeof(T)).Find(primaryKey);
        }

        public IEnumerable<T> GetAll<T>() 
        {
            return (IEnumerable<T>)mUnitOfWork.Context.Set(typeof(T)).
        }

        public PagedResult<T> PagedQuery<T>(Int32 pageNumber, Int32 pageSize) 
        {
            PagedResult<T> myPageResult = new PagedResult<T>();
            myPageResult.Collection = (IEnumerable<T>) mUnitOfWork.Context.entities.Select(m => m).Skip(pageSize * pageNumber).Take(pageSize).AsEnumerable();
            myPageResult.NumberOfRegisters = mUnitOfWork.Context.entities.Count();
            myPageResult.CurrentPage = pageNumber;
            myPageResult.TotalPages = (myPageResult.NumberOfRegisters/pageSize) +
                                      ((myPageResult.NumberOfRegisters%pageSize > 0) ? 1 : 0);
            return myPageResult;

        }

        public void Insert<T>(T itemToAdd) 
        {
            mUnitOfWork.Context.Set(typeof(T)).Add(itemToAdd);
        }

        public void Update<T>(T itemToUpdate, Int32 primaryKeyValue)
        {
            var entity2Update = this.GetById<T>(primaryKeyValue);
                entity2Update = itemToUpdate;
        }

        public void Delete<T>(Int32 primaryKeyValue)
        {
            mUnitOfWork.Context.Set(typeof (T)).Remove(primaryKeyValue);
        }
    }
}
