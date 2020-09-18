using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private ManagerContext context { get; set; }

        public HomeController(ManagerContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var managers = context.Managers.Include(m => m.Category).OrderBy(m => m.LastName).ToList();
            return View(managers);
        }
    }
}
