using Microsoft.AspNetCore.Mvc;


namespace AssuncaoDistribution.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
