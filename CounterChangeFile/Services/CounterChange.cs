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
       
        private readonly RepositoryDbContext _context;
        public CounterChange(RepositoryDbContext context)
        {
            _context = context;
        }

        public async Task CounterChangeFileInLocalrepositiry(int RepoId, string Path, int AnalysisId)
        {

            List<Files> repos = new List<Files>();
            var repo = new Repository(Path);
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

                repos.Add(new Files { RelativePath = fileName, NumberOfChange = i, Repos = _context.Repos.SingleOrDefault(x => x.Id == RepoId), Analysis = _context.Analysis.SingleOrDefault(x => x.Id == AnalysisId) });
                //TODO Check
            }

            await _context.Files.AddRangeAsync(repos);

            await _context.SaveChangesAsync();
        }
    }
}
