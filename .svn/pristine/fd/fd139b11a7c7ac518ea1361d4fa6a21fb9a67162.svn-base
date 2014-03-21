using System.Collections;
using System.Data.Entity;
using System.Threading;

namespace INSE6260.OnlineBanking.Repository.EF.DataContextStorage
{
    public class ThreadDbContextStorageContainer : IDbContextStorageContainer 
    {    
        private static readonly Hashtable DbContexts = new Hashtable();

        public DbContext GetDataContext()
        {
            DbContext dbContext = null;
            if (DbContexts.Contains(GetThreadName()))
                dbContext = (OnlineBankingDataContext)DbContexts[GetThreadName()];           

            return dbContext;
        }

        public void Store(DbContext dbContext)
        {
            if (DbContexts.Contains(GetThreadName()))
                DbContexts[GetThreadName()] = dbContext;
            else
                DbContexts.Add(GetThreadName(), dbContext);           
        }

        private static string GetThreadName()
        {
            return Thread.CurrentThread.Name;
        }     
    }
}
