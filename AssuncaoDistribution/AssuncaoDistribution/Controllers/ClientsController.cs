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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (Client client)
        {
            if (ModelState.IsValid)
            {
                _clientContext.UpdateClient(client);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(client);
            }
        }


        public IActionResult Details (int id)
        {
            var hasCli = _clientContext.HasClient(id);

            if (hasCli)
            {
                var client = _clientContext.FindClient(id);
                return View(client);
            }
            else
            {
                throw new Exception("Client not find in database, please try again");
            }
        }

        
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var hasCli = _clientContext.HasClient(id);

            if (hasCli)
            {
                var client = _clientContext.FindClient(id);
                return View(client);
            }
            else
            {
                throw new Exception("Client not find in database, please try again");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (Client client)
        {
            if(ModelState.IsValid)
            {
                _clientContext.DeleteClient(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }
    }
}
