using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CounterChangeFile.Models;


namespace CounterChangeFile.Controllers
{
    public class ReposController : Controller
    {
        private readonly RepositoryDbContext _context;

        public ReposController(RepositoryDbContext context)
        {
            _context = context;
        }

      
        public async Task<IActionResult> Index()
        {


            return View(await _context.Repos.ToListAsync());
        }

 

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Path")] Repos repos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repos);
        }

    }
}
