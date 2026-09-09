using Microsoft.AspNetCore.Mvc;
using PortfolioSite.Data;

namespace PortfolioSite.Controllers
{
    public class AboutController : Controller
    {
        private readonly PortfolioDbContext _context;

        public AboutController(PortfolioDbContext context)
        {
            _context = context;
            /*
             The constructor (public AboutController(PortfolioDbContext context)) is where dependency injection hands you the "kitchen access" automatically 
             — you never wrote new PortfolioDbContext(...) anywhere; ASP.NET Core does that for you because you registered it in Program.cs earlier.
             */
        }
        public IActionResult Index()
        {
            var bio = _context.Bios.FirstOrDefault();
            var experiences = _context.Experiences.OrderByDescending(e => e.StartDate).ToList();

            ViewBag.Experiences = experiences;
            return View(bio);
        }
    }
}
