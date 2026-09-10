using Microsoft.AspNetCore.Mvc;
using PortfolioSite.Data;

namespace PortfolioSite.Controllers
{
    public class ProjectController : Controller
    {
        private readonly PortfolioDbContext _context;

        public ProjectController(PortfolioDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

             var projects = _context.Projects.ToList();
            //var projects = _context.Projects.OrderBy(p => p.TechStack).ToList();

            return View(projects);
        }

        /*public IActionResult Index()
        {
            return Content("Project controller works!");
        }*/

        /*public IActionResult Index()
        {
            var projects = _context.Projects
                .OrderBy(p => p.TechStack)
                .ToList();

            return View(projects);
        }*/
    }
}
