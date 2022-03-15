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
        public IActionResult Delete(Client client)
        {
            if(ModelState.IsValid)
            {
                _clientContext.DeleteClient(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }


        public IActionResult Error(int? id, string message)
        {
            var errorModel = new ErrorViewModel();


            if (id.Value == 500)
            {
                errorModel.ErrorCode = id.Value;
                errorModel.Title = "An error ocurred!";
                errorModel.Message = "An error ocurred! Please, try again later or contact our suport";
            }
            else if (id.Value == 404)
            {
                errorModel.ErrorCode = id.Value;
                errorModel.Title = "Page not found";
                errorModel.Message = "This page not exists!";
            }
            else if (id.Value == 403)
            {
                errorModel.ErrorCode = id.Value;
                errorModel.Title = "Access denied";
                errorModel.Message = "You not have permission to do this";
            }
            else
            {
                return StatusCode(404);
            }
            return View(errorModel);
        }
    }
}
