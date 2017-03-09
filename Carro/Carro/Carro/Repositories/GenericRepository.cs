using System;
using System.Collections.Generic;
using Carro.Repositories.Interfaces;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;

namespace Carro.Repositories
{
    public class GenericRepository<T, TKey> : GenericReadOnlyRepository<T, TKey>, IGenericRepository<T, TKey> where T : class, new()
    {
        public GenericRepository(SQLiteConnection context, object locker) : base(context, locker)
        {
        }

        public int Add(T entity)
        {
            lock (Locker)
            {
                Context.InsertWithChildren(entity);
                return 0;
            }
        }

        public int AddOrUpdate(T entity)
        {
            lock (Locker)
            {
                Context.InsertOrReplaceWithChildren(entity);
                return 0;
            }
        }

        public int AddOrUpdateAll(IEnumerable<T> list)
        {
            lock (Locker)
            {
                return Context.InsertOrReplaceAll(list);
            }
        }

        public void CreateTable()
        {
            Context.CreateTable<T>();
        }

        public int Delete(TKey key)
        {
            lock (Locker)
            {
                return Context.Delete<T>(key);
            }
        }

        public int Delete(T entity)
        {
            lock (Locker)
            {
                Context.Delete(entity, true);
                return 0;
            }
        }

        public int Drop()
        {
            lock (Locker)
            {
                return Context.DropTable<T>();
            }
        }

        public int InsertAll(IEnumerable<T> list)
        {
            lock (Locker)
            {
                return Context.InsertAll(list);
            }
        }

        public int Update(T entity)
        {
            lock (Locker)
            {
                return Context.Update(entity);
            }
        }

        public int UpdateAll(IEnumerable<T> list)
        {
            lock (Locker)
            {
                return Context.UpdateAll(list);
            }
        }
    }
}
