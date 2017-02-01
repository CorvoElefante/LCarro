using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Carro.Repositories.Interfaces;
using SQLite.Net;

namespace Carro.Repositories
{
    public class GenericReadOnlyRepository<T, TKey> : IGenericReadOnlyRepository<T, TKey> where T : class, new()
    {
        protected object Locker { get; private set; }
        protected SQLiteConnection Context { get; private set; }

        public GenericReadOnlyRepository(SQLiteConnection context, object locker)
        {
            Context = context;
            Locker = locker;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            lock (Locker)
            {
                return Context.Table<T>().Where(predicate);
            }
        }

        public IEnumerable<T> GetAll()
        {
            lock (Locker)
            {
                return Context.Table<T>();
            }
        }

        public T GetById(TKey id)
        {
            lock (Locker)
            {
                return Context.Get<T>(id);
            }
        }

        public IEnumerable<T> Query(string query)
        {
            lock (Locker)
            {
                return Context.Query<T>(query);
            }
        }
    }
}

