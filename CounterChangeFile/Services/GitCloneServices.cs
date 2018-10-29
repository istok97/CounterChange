using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CounterChangeFile.Services;
using LibGit2Sharp;
namespace CounterChangeFile.Services
{
    public class GitCloneServices : IGitCloneServices
    {
        public void GitClone(string reference, string path)

        {
            Repository.Clone(@reference, @path);

        }
    }
}
