using Microsoft.AspNetCore.Mvc;

namespace SignalRLiveMatchProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
