using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CounterChangeFile.Models;

namespace CounterChangeFile.ViewModels
{
    public class ReposViewModel
    {   
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }
    }
}
