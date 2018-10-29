using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CounterChangeFile.Services;
using LibGit2Sharp;

namespace CounterChangeFile.Services
{
    public class GitInitServices : IGitInitService
    {
        public  void  GitInit(string Path)
            
        {
            string rootedPath = Repository.Init(@Path);

        }
    }
}
