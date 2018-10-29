using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CounterChangeFile.Services;

namespace CounterChangeFile.Controllers
{
    public class GitCloneController : Controller
    {
        private readonly IGitCloneServices gitCloneServices;
        public GitCloneController(IGitCloneServices gitCloneServices)
        {
            this.gitCloneServices = gitCloneServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GitClone(string reference, string path)
        {
            gitCloneServices.GitClone(reference, path );

            return RedirectToAction("Index");
        }
    }
}