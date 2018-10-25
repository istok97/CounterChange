using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibGit2Sharp;
using CounterChangeFile.Models;

namespace CounterChangeFile.Services
{
    public class CounterChange : ICounterChange
    {
        private const string RepoPath = "D:/Total";
        private readonly RepositoryDbContext _context;
        public CounterChange(RepositoryDbContext context)
        {
            _context = context;
        }

        public async Task CounterChangeFileInLocalrepositiry()
        {
            IQueryable<Repositories> repositories = _context.Repositoryes;
            List<Repositories> repos = new List<Repositories>();
            var repo = new Repository(RepoPath);
            foreach (IndexEntry e in repo.Index)
            {
                var fileName = "";
                var i = 0;
                fileName = e.Path;

                foreach (var commit in repo.Commits)
                {
                    foreach (var parent in commit.Parents)
                    {
                        foreach (var change in repo.Diff.Compare<TreeChanges>(parent.Tree, commit.Tree))
                        {
                            if (change.Path == fileName)
                            {
                                i++;
                            }
                        }


                       

                    }
                    
                }

                repos.Add(new Repositories { Name = fileName, NumberOfChange = i });
                //TODO Check
            }

            await _context.Repositoryes.AddRangeAsync(repos);

            await _context.SaveChangesAsync();
        }
    }
}
