using System;
using System.Text;
using INSE6260.OnlineBanking.Infrastructure;
using INSE6260.OnlineBanking.Infrastructure.Authentication;
using INSE6260.OnlineBanking.Infrastructure.Helpers;
using INSE6260.OnlineBanking.Model.ClientCard;
using INSE6260.OnlineBanking.Service.Interfaces;

namespace INSE6260.OnlineBanking.Service.Implementations
{
    public class ClientAuthenticationService : IClientAuthenticationService
    {
        private readonly IUnitOfWork _uow;
        private readonly IClientCardRepository _clientCardRepository;

        public ClientAuthenticationService(IUnitOfWork uow, IClientCardRepository clientCardRepository)
        {
            _uow = uow;
            _clientCardRepository = clientCardRepository;
        }

        public User Login(string cardId, string password)
        {
            ValidateLoginInfo(cardId,password);
            var clientCard = _clientCardRepository.GetClientCard(cardId, password);
            var user = new User {IsAuthenticated = clientCard != null};
            if (clientCard != null) user.AccountID = clientCard.CardAccount.AccountID;
            return user;
        }
        private static void ValidateLoginInfo(string cardId, string password)
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty(cardId) || !ClientCardHelper.IsMatch(cardId))
                sb.AppendLine("Card ID is invalid!");
            if (!String.IsNullOrEmpty(password) )
                sb.AppendLine("Password is invalid!");
            if (!String.IsNullOrEmpty(sb.ToString()))
                throw new InvaliLoginInfoException(sb.ToString());
        }
       
    }

    
}
