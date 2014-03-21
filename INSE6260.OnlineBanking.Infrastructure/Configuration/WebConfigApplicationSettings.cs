using System.Configuration;

namespace INSE6260.OnlineBanking.Infrastructure.Configuration
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        public string LoggerName
        {
            get { return ConfigurationManager.AppSettings["LoggerName"]; }
        }

        public string NumberOfResultsPerPage
        {
            get { return ConfigurationManager.AppSettings["NumberOfResultsPerPage"]; }
        }

        public string JanrainApiKey
        {
            get
            {
                return ConfigurationManager
                             .AppSettings["JanrainApiKey"];
            }
        }

        public string PayPalBusinessEmail
        {
            get { return ConfigurationManager.AppSettings["PayPalBusinessEmail"]; }
        }

        public string PayPalPaymentPostToUrl
        {
            get { return ConfigurationManager.AppSettings["PayPalPaymentPostToUrl"]; }
        }


    }

}
