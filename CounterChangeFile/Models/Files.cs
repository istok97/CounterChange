using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CounterChangeFile.Models
{
    public class Files
    {
        public int Id { get; set; }

        public string RelativePath { get; set; }

        public int NumberOfChange { get; set; }
        
        public Repos Repos { get; set; }

        public Analysis Analysis { get; set; }
        


    }
}
