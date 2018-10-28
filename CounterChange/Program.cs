using System;
using LibGit2Sharp;
namespace CounterChange
{
    class Program
    {
        private const string RepoPath = "D:/1234/EShop";
        private static void Main(string[] args)
        {
           
            TestAsync();
            Console.ReadKey();
        }

        private static void CheckAllFilesListing()
        {
            using (var repo = new Repository(RepoPath))
            {
                foreach (IndexEntry e in repo.Index)
                {


                    Console.WriteLine("{0} {1} {2} {3}",
                    Convert.ToString((int)e.Mode, 8),
                    e.Id.ToString(), (int)e.StageLevel, e.Path);
                }
            }
        }

        private static async System.Threading.Tasks.Task TestAsync()
        {
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

                await writer.WriteLineAsync();
                //Console.WriteLine("File {0} was changed {1} times.", fileName, i);
            }
        }
    }
}

