using System.Web.Mvc;
using INSE6260.OnlineBanking.Infrastructure;
using INSE6260.OnlineBanking.Service.Interfaces;
using INSE6260.OnlineBanking.Service.Messaging.ClientService;

namespace INSE6260.OnlineBanking.Controllers.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IClientService clientService, IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
            _clientService = clientService;
        }
        public ActionResult Index()
        {
            var clientView = _clientService.GetClient(new GetClientRequest {ClientIdToken = 1, LoadAccounts = true});
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View(clientView);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
