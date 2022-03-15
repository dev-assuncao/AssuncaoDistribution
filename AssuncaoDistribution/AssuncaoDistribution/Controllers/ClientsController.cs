using Microsoft.AspNetCore.Mvc;
using AssuncaoDistribution.Services;
using AssuncaoDistribution.Models;
using System;
using AssuncaoDistribution.Services.Exceptions;

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
        public IActionResult Edit(Client client)
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


        public IActionResult Details(int id)
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


        public IActionResult Delete(int? id)
        {
            var hasCli = _clientContext.HasClient(id.Value);
            if (hasCli)
            {
                var client = _clientContext.FindClient(id.Value);
                return View(client);
            }
            else
            {
                return RedirectToAction(nameof(Error), new { id = 404, message = ("Client not found in database") });
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                _clientContext.DeleteClient(id);
                return RedirectToAction(nameof(Index));
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { id = 409, message = e.Message });
            }
            catch (NotFoundException e)

            {
                return RedirectToAction(nameof(Error), new { id = 404, message = e.Message });
            }

        }


        public IActionResult Error(int? id, string message)
        {
            var errorModel = new ErrorViewModel()
            {
                ErrorCode = id.Value,
                Title = "An error occurred",
                Message = message
            };

            return View(errorModel);
        }
    }
}
