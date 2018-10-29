using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CounterChangeFile.Models;
using CounterChangeFile.Services;
using CounterChangeFile.ViewModels;

namespace CounterChangeFile.Controllers
{
    public class AnalysisController : Controller
    {
        private readonly ICounterChange counterChange;
        private readonly RepositoryDbContext _context;


        public AnalysisController(RepositoryDbContext context, ICounterChange counterChange)
        {
            this.counterChange = counterChange;
            _context = context;
        }

        public async Task<IActionResult> Index(int Id)
        {
            IQueryable<Analysis> analyses = _context.Analysis.Where(x => x.Repos.Id == Id);

            return View(analyses);
        }

        public IActionResult Create(int Id, string Path)
        {

            var result = _context.Repos.Where(x => x.Id == Id);
            var analisisViewModel = new AnalisisViewModel
            {
                Path = Path,
                RepoId = Id
            };

            return View(analisisViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, RepoId, Path")] AnalisisViewModel analisisViewModel)
        {

            if (ModelState.IsValid)
            {
                var analysis = new Analysis
                {
                    Date = DateTime.Now,
                    Repos = _context.Repos.SingleOrDefault(x => x.Id == analisisViewModel.Id)
                };

                _context.Add(analysis);
                await _context.SaveChangesAsync();
                int RepoId = analisisViewModel.RepoId;
                string Path = analisisViewModel.Path;
                int AnalysisId = analysis.Id;
                await counterChange.CounterChangeFileInLocalrepositiry(RepoId, Path, AnalysisId);
                return RedirectToAction("Index", "Repos");
            }

            return View("Create");
        }
    }
}
