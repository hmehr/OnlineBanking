using System.Data.Entity;
using INSE6260.OnlineBanking.Repository.EF.DataContextStorage;

namespace INSE6260.OnlineBanking.Repository.EF
{
    public class DbContextFactory
    {
        private static string _connectionName;
        public static void SetupDbConnection(string connectionName)
        {
            _connectionName = connectionName;
        }
        public static DbContext GetDbContext()
        {
            var dataContextStorageContainer = DbContextStorageFactory.CreateStorageContainer();
            
            var onlineBankingDataContext = dataContextStorageContainer.GetDataContext();
            if (onlineBankingDataContext == null)
            {
                onlineBankingDataContext = new OnlineBankingDataContext(_connectionName);
                dataContextStorageContainer.Store(onlineBankingDataContext);
            }

            return onlineBankingDataContext;            
        }       
    }
}
