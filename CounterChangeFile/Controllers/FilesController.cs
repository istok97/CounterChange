using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CounterChangeFile.Models;
using CounterChangeFile.Models.Enums;

namespace CounterChangeFile.Controllers
{
    public class FilesController : Controller
    {
        private readonly RepositoryDbContext _context;

        public FilesController(RepositoryDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int Id, SortFiles sortFiles = SortFiles.NumberOfChangeDefault)
        {
            IQueryable<Files> files = _context.Files.Where(x => x.Analysis.Id == Id);
            ViewData["sortFiles"] = sortFiles == SortFiles.NumberOfChangeAsc ? SortFiles.NumberOfChangeDesc : SortFiles.NumberOfChangeAsc;
            switch(sortFiles)
            {
                case SortFiles.NumberOfChangeAsc:
                    files = files.OrderBy(s => s.NumberOfChange);
                    break;
                case SortFiles.NumberOfChangeDesc:
                    files = files.OrderByDescending(s => s.NumberOfChange);
                    break;
                
            }
           
            return View(await files.AsNoTracking().ToListAsync());
        }

 
    }
}
