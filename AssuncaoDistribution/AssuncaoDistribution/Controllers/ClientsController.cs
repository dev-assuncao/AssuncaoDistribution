using Microsoft.AspNetCore.Mvc;
using AssuncaoDistribution.Services;
using AssuncaoDistribution.Models;
using System;

namespace AssuncaoDistribution.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ClientServices _clientContext;

        public ClientsController(ClientServices client)
        {
            _clientContext = client;
        }



        public IActionResult Index()
        {
            var allClients = _clientContext.AllClients();
            return View(allClients);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _clientContext.InsertClient(client);
               return RedirectToAction(nameof(Index));
            }

            return View(client);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var findCli = _clientContext.FindClient(id);

            if (findCli != null)
            {
                return View(findCli);
            }
            else
            {
                throw new Exception("Client not find in database");
            }
        }
    }
}
