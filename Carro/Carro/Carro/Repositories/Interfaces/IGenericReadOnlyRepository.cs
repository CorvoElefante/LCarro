using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Carro.Repositories.Interfaces
{
    public interface IGenericReadOnlyRepository<T, TKey> where T : new()
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T GetById(TKey id);
        IEnumerable<T> Query(string query);
    }
}