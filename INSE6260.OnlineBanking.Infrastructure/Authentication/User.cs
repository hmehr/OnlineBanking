namespace INSE6260.OnlineBanking.Infrastructure.Authentication
{
    public class User
    {
        public string AuthenticationToken { get; set; }
        public int AccountID { get; set; }
        public bool IsAuthenticated { get; set; }
    }

}
