using System.Linq;
using INSE6260.OnlineBanking.Infrastructure;
using INSE6260.OnlineBanking.Model;
using INSE6260.OnlineBanking.Model.Customers;

namespace INSE6260.OnlineBanking.Repository.EF.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }

        public Client GetFirstCustomerStartWith(string start)
        {
            return GetObjectSet().FirstOrDefault(customer => customer.Name.StartsWith(start));
        }
    }
}
