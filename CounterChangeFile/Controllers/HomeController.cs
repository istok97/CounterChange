using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CounterChangeFile.Models;
using Microsoft.EntityFrameworkCore;
using CounterChangeFile.Services;

namespace CounterChangeFile.Controllers
{
    public class HomeController : Controller
    {
        private readonly RepositoryDbContext _context;
        private readonly ICounterChange counterChange;
        public HomeController(RepositoryDbContext context, ICounterChange counterChange)
        {
            _context = context;
            this.counterChange = counterChange;
        }

        public async Task<IActionResult> Index()
        {
            await counterChange.CounterChangeFileInLocalrepositiry();
            return View(await _context.Repositoryes.ToListAsync());
            
        }

       
    }
}
