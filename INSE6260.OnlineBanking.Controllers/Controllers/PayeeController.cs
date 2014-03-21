using System.Web.Mvc;
using INSE6260.OnlineBanking.Infrastructure;
using INSE6260.OnlineBanking.Model;
using INSE6260.OnlineBanking.Service.Interfaces;
using INSE6260.OnlineBanking.Service.Messaging.ClientService;

namespace INSE6260.OnlineBanking.Controllers.Controllers
{
    public class PayeeController : Controller
    {
        private readonly IPayeeService _payeeService;
        private readonly IUnitOfWork _unitOfWork;
        public PayeeController(IPayeeService payeeService, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _payeeService = payeeService;
        }
        public ActionResult Index()
        {
            var payees = _payeeService.GetAllPayee();
            return View(payees);
        }
    }
     }
