using AutoMapper;
using INSE6260.OnlineBanking.Model;
using INSE6260.OnlineBanking.Service.ViewModels;

namespace INSE6260.OnlineBanking.Service.Mapping
{
    public static class ClientMapper
    {
        public static ClientView ConvertToClientView(this Client client)
        {
            return Mapper.Map<Client, ClientView>(client);
        }
    }

}