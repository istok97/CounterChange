using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CounterChangeFile.Services
{
    public interface IGitCloneServices
    {
        void GitClone(string reference, string path);
    }
}
