using System.Data.Entity;
using System.Web;

namespace INSE6260.OnlineBanking.Repository.EF.DataContextStorage
{
    public class HttpDbContextStorageContainer : IDbContextStorageContainer 
    {
        private const string DataContextKey = "DataContext";

        public DbContext GetDataContext()
        {
            DbContext objectContext = null;
            if (HttpContext.Current.Items.Contains(DataContextKey))
                objectContext = (DbContext)HttpContext.Current.Items[DataContextKey];

            return objectContext;
        }

        public void Store(DbContext dbContext)
        {
            if (HttpContext.Current.Items.Contains(DataContextKey))
                HttpContext.Current.Items[DataContextKey] = dbContext;
            else
                HttpContext.Current.Items.Add(DataContextKey, dbContext);  
        }

    }
}
