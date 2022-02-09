using Microsoft.AspNetCore.Mvc;
using AssuncaoDistribution.Services;


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
    }
}
