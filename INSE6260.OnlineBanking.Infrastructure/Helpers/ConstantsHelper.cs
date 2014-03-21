using System.Text.RegularExpressions;

namespace INSE6260.OnlineBanking.Infrastructure.Helpers
{
    public class ClientCardHelper
    {
        public static bool IsMatch(string cardId)
        {
            return CardIDRegex.IsMatch(cardId);
        }
        private static Regex CardIDRegex
        {
            get
            {
                return new Regex("^4[0-9]{12}(?:[0-9]{3})?$"); 
            }
        }
    }
}
