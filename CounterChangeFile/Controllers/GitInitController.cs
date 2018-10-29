using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CounterChangeFile.Services;

namespace CounterChangeFile.Controllers
{
    public class GitInitController : Controller
    {
        private readonly IGitInitService gitInitService;
        //   await counterChange.CounterChangeFileInLocalrepositiry(RepoId, Path, AnalysisId);
        public GitInitController(IGitInitService gitInitService)
        {
            this.gitInitService = gitInitService;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult GitInit(string path)
        {
             gitInitService.GitInit(path);

           return RedirectToAction("Index");
        }
    }
}