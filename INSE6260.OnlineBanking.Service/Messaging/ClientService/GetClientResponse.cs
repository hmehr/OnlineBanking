using System.Collections.Generic;
using INSE6260.OnlineBanking.Service.ViewModels;

namespace INSE6260.OnlineBanking.Service.Messaging
{
    public class GetClientResponse
    {
        public bool ClientFound { get; set; }
        public ClientView Client { get; set; }
        public IEnumerable<AccountView> Accounts { get; set; }
    }
}
