using INSE6260.OnlineBanking.Infrastructure.Authentication;

namespace INSE6260.OnlineBanking.Service.Interfaces
{
    public interface IClientAuthenticationService
    {
        User Login(string cardId, string password);
    }
}
