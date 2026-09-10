using Microsoft.AspNetCore.Mvc;
using PortfolioSite.Data;

namespace PortfolioSite.Controllers
{
    public class AboutController : Controller
    {
        // 1. Controller needs a database context
        private readonly PortfolioDbContext _context;

        // 2. ASP.NET provides the database context
        public AboutController(PortfolioDbContext context)
        {
            // 3. Store it so the controller can use it
            _context = context;
            /*
             The constructor (public AboutController(PortfolioDbContext context)) is where dependency injection hands you the "kitchen access" automatically 
             — you never wrote new PortfolioDbContext(...) anywhere; ASP.NET Core does that for you because you registered it in Program.cs earlier.
             */
        }

        // 4. Now other methods can use it
        public IActionResult Index()
        {
            var bio = _context.Bios.FirstOrDefault();
            //var experiences = _context.Experiences.OrderByDescending(e => e.StartDate).ToList();
            var experiences = _context.Experiences.OrderBy(e => e.StartDate).ToList();

            ViewBag.Experiences = experiences;
            return View(bio);
        }
    }
}
