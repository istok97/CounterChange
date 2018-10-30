using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CounterChangeFile.Services;
using CounterChangeFile.ViewModels;
using CounterChangeFile.Models;

namespace CounterChangeFile.Controllers
{
    public class AnalysisCreatorController : Controller
    {
        private readonly RepositoryDbContext _context;
        private readonly ICounterChange counterChange;
        private readonly IGitCloneServices gitCloneServices;
        private readonly IGitInitService gitInitService;

        public AnalysisCreatorController(RepositoryDbContext context, IGitCloneServices gitCloneServices, ICounterChange counterChange, IGitInitService gitInitService)
        {
            this.gitCloneServices = gitCloneServices;
            this.gitInitService = gitInitService;
            this.counterChange = counterChange;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(string reference, string path, string name)
        {
            if (ModelState.IsValid)
            {
                gitCloneServices.GitClone(reference, path);
                gitInitService.GitInit(path);
                var repos = new Repos
                {
                    Name = name,
                    Path = path
                };

                _context.Add(repos);
                _context.SaveChanges();

                var analysis = new Analysis
                {
                    Date = DateTime.Now,
                    Repos = _context.Repos.SingleOrDefault(x => x.Id == repos.Id)
                };

                _context.Add(analysis);
                _context.SaveChanges();
                int RepoId = repos.Id;
                string Path = path;
                int AnalysisId = analysis.Id;
                counterChange.CounterChangeFileInLocalrepositiry(RepoId, Path, AnalysisId);
                
            }

            return View("Index");
        }
    }
}