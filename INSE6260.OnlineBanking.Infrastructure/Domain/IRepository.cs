using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using INSE6260.OnlineBanking.Infrastructure.Specifications;

namespace INSE6260.OnlineBanking.Infrastructure.Domain
{
    public interface IRepository<T> where T : class, IAggregateRoot
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        void SaveChanges();
        IQueryable<T> GetObjectSet();

        IQueryable<T> SourceQuery { get; }
        T FindByID(object id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(int index, int count);
        IEnumerable<T> FindBy(Func<T, bool> predicate);
        IEnumerable<T> FindBy(Func<T, bool> predicate, int index, int count);
        IQueryable<T> Query(Expression<Func<T, bool>> expressions);
        IQueryable<T> Query(SpecificationBase<T> specification);
        T First(Func<T, bool> predicate);
        int Count();
        int Count(Func<T, bool> predicate);
        void PersistCreationOf(IAggregateRoot entity);
        void PersistUpdateOf(IAggregateRoot entity);
        void PersistDeletionOf(IAggregateRoot entity);
    }
}
