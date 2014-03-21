using System.Collections.Generic;
using INSE6260.OnlineBanking.Model;
using INSE6260.OnlineBanking.Service.Messaging;
using INSE6260.OnlineBanking.Service.Messaging.ClientService;
using INSE6260.OnlineBanking.Service.ViewModels;

namespace INSE6260.OnlineBanking.Service.Interfaces
{
    public interface IClientService
    {
        GetClientResponse GetClient(GetClientRequest request);
        Client GetClientByID(int clientId);
        IEnumerable<ClientView> GetAllClients();
        void InsertClient(Client client);
        void UpdateClient(Client client);
        void RemoveClient(Client client);
    }
}
