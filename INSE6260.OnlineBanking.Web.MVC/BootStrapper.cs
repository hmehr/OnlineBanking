using INSE6260.OnlineBanking.Infrastructure;
using INSE6260.OnlineBanking.Infrastructure.Configuration;
using INSE6260.OnlineBanking.Infrastructure.CookieStorage;
using INSE6260.OnlineBanking.Infrastructure.Email;
using INSE6260.OnlineBanking.Infrastructure.Logging;
using INSE6260.OnlineBanking.Model.Customers;
using INSE6260.OnlineBanking.Repository.EF;
using INSE6260.OnlineBanking.Repository.EF.Repositories;
using INSE6260.OnlineBanking.Service.Implementations;
using INSE6260.OnlineBanking.Service.Interfaces;
using StructureMap;
using StructureMap.Configuration.DSL;
using INSE6260.OnlineBanking.Model.Payee;


namespace INSE6260.OnlineBanking.Web.MVC
{
    public class BootStrapper
    {
        public static void ConfigureDependencies()
        {
            ObjectFactory.Initialize(reg => reg.AddRegistry<ControllerRegistry>());
        }

        public class ControllerRegistry : Registry
        {
            public ControllerRegistry()
            {
                // Repositories 
                For<IClientRepository>().Use<ClientRepository>();
                For<IPayeeRepository>().Use<PayeeRepository>();
                For<IUnitOfWork>().Use<EFUnitOfWork>();
                For<ICookieStorageService>().Use<CookieStorageService>();
                For<IApplicationSettings>().Use<WebConfigApplicationSettings>();
                
                //Services
                For<IClientService>().Use<ClientService>();
                For<IPayeeService>().Use<PayeeService>();
                
                // Logger
                For<ILogger>().Use<Log4NetAdapter>();
               
                // Email Service   
                For<IEmailService>().Use<TextLoggingEmailService>();
            }
        }
    }
}
