using System.Web;

namespace INSE6260.OnlineBanking.Repository.EF.DataContextStorage
{
    public class DbContextStorageFactory
    {
        public static IDbContextStorageContainer DataContectStorageContainer;

        public static IDbContextStorageContainer CreateStorageContainer()
        {
            if (DataContectStorageContainer == null)
            {
                if (HttpContext.Current == null)                                    
                    DataContectStorageContainer = new ThreadDbContextStorageContainer();
                else
                    DataContectStorageContainer = new HttpDbContextStorageContainer();
            }

            return DataContectStorageContainer;
        }
    }
}
