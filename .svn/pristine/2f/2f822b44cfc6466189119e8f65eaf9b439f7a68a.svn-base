using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using INSE6260.OnlineBanking.Infrastructure;
using INSE6260.OnlineBanking.Infrastructure.Domain;
using INSE6260.OnlineBanking.Infrastructure.Specifications;
using INSE6260.OnlineBanking.Infrastructure.UnitOfWork;

namespace INSE6260.OnlineBanking.Repository.EF.Repositories
{


    public class RepositoryBase<T> : IUnitOfWorkRepository, IRepository<T> where T : class, IAggregateRoot
    {
        private readonly IUnitOfWork _unitOfWork;

        protected RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }

        public void Add(T entity)
        {
            _unitOfWork.RegisterNew(entity, this);                        
        }

        public void Remove(T entity)
        {
            _unitOfWork.RegisterRemoved(entity, this);            
        }
       
        public void Update(T entity)
        {
           GetDbContext().Entry(entity).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public T FindByID(object id)
        {
            return (T)GetDbSet().Find(id);
        }

        public IQueryable<T> GetObjectSet()
        {
            return GetDbSet() as IQueryable<T>;
        }

        public IQueryable<T> SourceQuery
        {
            get { return GetObjectSet(); }
        }

        public IEnumerable<T> GetAll()
        {
            return GetObjectSet().ToList(); 
        }

        public IEnumerable<T> GetAll(int index, int count)
        {
            return GetObjectSet().Skip(index).Take(count).ToList(); 
        }

        public IEnumerable<T> FindBy(Func<T, bool> predicate)
        {
            return GetObjectSet().Where(predicate);
        }

        public IEnumerable<T> FindBy(Func<T, bool> predicate, int index, int count)
        {
            return GetObjectSet().Where(predicate).Skip(index).Take(count);
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> expressions)
        {
            return GetObjectSet().Where(expressions);
        }

        public IQueryable<T> Query(SpecificationBase<T> specification)
        {
            return GetObjectSet().Where(specification.IsSatisfiedBy()).AsQueryable();
        }

        public T First(Func<T, bool> predicate)
        {
            return GetObjectSet().FirstOrDefault(predicate);
        }

        public int Count()
        {
            return GetObjectSet().Count();
        }

        public int Count(Func<T, bool> predicate)
        {
            return GetObjectSet().Count(predicate);
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            GetDbSet().Add(entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            if(entity == null) return;
            GetDbContext().Entry(entity).State = EntityState.Modified;
        }

        private static DbSet GetDbSet()
        {
            return GetDbContext().Set(typeof(T));
        }
        private static DbContext GetDbContext()
        {
            return DbContextFactory.GetDbContext();
        }
        public void PersistDeletionOf(IAggregateRoot entity)
        {
            
            GetDbSet().Remove(entity);
        }
       
    }
}
