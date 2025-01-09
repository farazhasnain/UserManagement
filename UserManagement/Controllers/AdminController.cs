using Microsoft.AspNetCore.Mvc;

namespace UserManagemet.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
