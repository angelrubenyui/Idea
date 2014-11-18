using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Idea.DAL.Repositories
{
    public class FakeUnitOfWork:IUnitOfWork
    {
        private readonly Hashtable _db;
        private readonly Hashtable _changes;
        public Guid UoW_ID { get; set; }
        
        public FakeUnitOfWork()
        {
            UoW_ID = Guid.NewGuid();
            _db = new Hashtable();
            _changes = new Hashtable();
        }

        public void Dispose()
        {
            _changes.Clear();
        }

        public void Add(Object Key, Object Value)
        {
            _changes.Add(Key, Value);
        }

        public void Update(Object key, Object Value)
        {
            _changes[key] = Value;
        }

        public void Remove(Object Key)
        {
            _changes.Remove(Key);
        }

        public Object Get(Object Key)
        {
            return _db[Key];
        }

        public Int32 Count()
        {
            return _db.Count;
        }

        public void Commit()
        {
            foreach (var key in _changes.Keys)
            {
                _db.Add(key, _changes[key]);
            }
        }

        public void Rollback()
        {
            _changes.Clear();
        }


        public Common.Database Db
        {
            get { throw new NotImplementedException(); }
        }

        internal ICollection getAll()
        {
            return _db.Values;
        }
    }
}
