using Microsoft.AspNetCore.Mvc;

namespace Tp3EFcoreRelations.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
