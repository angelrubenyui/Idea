using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idea.Models.Entities;

namespace Idea.DAL.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork, IDisposable where T:class
    {
        public IdeaContext Context { get; set; }
        

        public UnitOfWork(IdeaContext context)
        {
            Context = context;
        }

        public UnitOfWork()
        {
            Context = new IdeaContext();
            Context.Configuration.AutoDetectChangesEnabled = false;
            Context.Configuration.LazyLoadingEnabled = true;
            Context.Configuration.ValidateOnSaveEnabled = false;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

       
    }
}
