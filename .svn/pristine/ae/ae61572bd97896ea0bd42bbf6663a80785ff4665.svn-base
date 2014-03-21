using System.Collections.Generic;
using System.Linq;
using INSE6260.OnlineBanking.Infrastructure;
using INSE6260.OnlineBanking.Model;
using INSE6260.OnlineBanking.Model.Customers;
using INSE6260.OnlineBanking.Service.Interfaces;
using INSE6260.OnlineBanking.Service.Mapping;
using INSE6260.OnlineBanking.Service.Messaging;
using INSE6260.OnlineBanking.Service.Messaging.ClientService;
using INSE6260.OnlineBanking.Service.ViewModels;

namespace INSE6260.OnlineBanking.Service.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _uow;

        public ClientService(IClientRepository customerRepository,IUnitOfWork uow)
        {
            _clientRepository = customerRepository;
            _uow = uow;
        }
        public GetClientResponse GetClient(GetClientRequest request)
        {
            var response = new GetClientResponse();
            var client = _clientRepository.FindByID(request.ClientIdToken);
            if (client != null)
            {
                response.ClientFound = true;
                response.Client = client.ConvertToClientView();
                if (request.LoadAccounts)
                    response.Accounts = client.Accounts.Select(acc => acc.ConvertToAccountView()).OrderBy(acc => acc.AccountID);
            }
            else
                response.ClientFound = false;
            return response;
        }

        public Client GetClientByID(int clientId)
        {
            return _clientRepository.FindByID(clientId);
        }

        public IEnumerable<ClientView> GetAllClients()
        {
            return _clientRepository.GetAll().Select(c => c.ConvertToClientView());
        }

        public void InsertClient(Client client)
        {
            _clientRepository.Add(client);
            _uow.Commit();
        }

        public void UpdateClient(Client client)
        {
            _clientRepository.Update(client);
            _uow.Commit();
        }

        public void RemoveClient(Client client)
        {
            if(client == null) return;
            _clientRepository.Remove(client);
            _uow.Commit();
        }
    }
}
