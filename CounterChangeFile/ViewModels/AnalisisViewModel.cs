using CounterChangeFile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CounterChangeFile.ViewModels
{
    public class AnalisisViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int RepoId { get; set; }

        public string Path { get; set; }

        
        public Repos Repos { get; set; }
    }
}
