using System.Linq;
using INSE6260.OnlineBanking.Infrastructure;
using INSE6260.OnlineBanking.Model.ClientCard;

namespace INSE6260.OnlineBanking.Repository.EF.Repositories
{
    public class ClientCardRepository : RepositoryBase<ClientCard>,IClientCardRepository
    {
        protected ClientCardRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public ClientCard GetClientCard(string cardId,string password)
        {
            return GetObjectSet().FirstOrDefault(cc => cc.CardID == cardId && cc.Password == password);
        }
    }
}
