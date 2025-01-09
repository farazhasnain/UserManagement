using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace UserManagemet.Controllers
{
    
    public class HomeController : Controller
    {
    
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admins,SuperAdmin")]
        public IActionResult About()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult FAQ()
        {
            return View();
        }

    }
}
