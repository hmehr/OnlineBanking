﻿using System.Web.Mvc;
using INSE6260.OnlineBanking.Infrastructure;
using INSE6260.OnlineBanking.Model;
using INSE6260.OnlineBanking.Service.Interfaces;
using INSE6260.OnlineBanking.Service.Messaging.ClientService;

namespace INSE6260.OnlineBanking.Controllers.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IUnitOfWork _unitOfWork;
        public ClientController(IClientService clientService, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _clientService = clientService;
        }
        public ActionResult Index()
        {
            var clients = _clientService.GetAllClients();
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View(clients);
        }

        public ActionResult Create()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Client client)
        {
           if (ModelState.IsValid)
           {
               _clientService.InsertClient(client);
                return RedirectToAction("Index", "Client");
           }
           return View(client);
        }


        public ActionResult Edit(int id)
        {
            var client = _clientService.GetClientByID(id);
            return View(client);
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                _clientService.UpdateClient(client);
                return RedirectToAction("Index", "Client");
            }
            return View(client);
        }

        public ActionResult Delete(int id)
        {
            var client = _clientService.GetClientByID(id);
            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var client = _clientService.GetClientByID(id);
            _clientService.RemoveClient(client);
            return RedirectToAction("Index", "Client");
        }
        public ViewResult Details(int id)
        {
            var client = _clientService.GetClient(new GetClientRequest {ClientIdToken = id, LoadAccounts = true});
            return View(client);
        }
        public ActionResult About()
        {
            return View();
        }
    }
}
