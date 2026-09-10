using Microsoft.AspNetCore.Mvc;
using PortfolioSite.Data;

namespace PortfolioSite.Controllers
{
    public class SkillsController : Controller
    {
        private readonly PortfolioDbContext _context;

        public SkillsController(PortfolioDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            /*var skills = _context.Skills.ToList();
            ViewBag.Skills = skills;*/

            var skills = _context.Skills
                 .OrderBy(s => s.Category)
                 .ThenByDescending(s => s.ProficiencyLevel)
                 .ToList();



            return View(skills);
        }
    }
}
