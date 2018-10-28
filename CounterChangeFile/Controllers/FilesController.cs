using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CounterChangeFile.Models;

namespace CounterChangeFile.Controllers
{
    public class FilesController : Controller
    {
        private readonly RepositoryDbContext _context;

        public FilesController(RepositoryDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int Id)
        {
            IQueryable<Files> files = _context.Files.Where(x => x.Analysis.Id == Id);
            return View(files);
        }

 
    }
}
