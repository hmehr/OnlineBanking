namespace INSE6260.OnlineBanking.Service.Messaging.ClientService
{
    public class GetClientRequest
    {
        public int  ClientIdToken { get; set; }
        public bool LoadAccounts { get; set; }
    }
}
