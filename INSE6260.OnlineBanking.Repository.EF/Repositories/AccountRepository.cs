using System.Linq;
using System.Collections.Generic;
using INSE6260.OnlineBanking.Infrastructure;
using INSE6260.OnlineBanking.Model.Accounts;
using INSE6260.OnlineBanking.Model.Customers;


namespace INSE6260.OnlineBanking.Repository.EF.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(IUnitOfWork unitOfWork): base(unitOfWork)
        {
            
        }
        public List<Account> GetCustomerAccounts(int clientId)
        {
            return SourceQuery.Where(account => account.Client.ClientID == clientId).ToList();
        }
    }
}
