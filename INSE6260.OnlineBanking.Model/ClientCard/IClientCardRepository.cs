using INSE6260.OnlineBanking.Infrastructure.Domain;

namespace INSE6260.OnlineBanking.Model.ClientCard
{
    public interface IClientCardRepository : IRepository<ClientCard>
    {
        ClientCard GetClientCard(string cardId, string password);
    }
}
