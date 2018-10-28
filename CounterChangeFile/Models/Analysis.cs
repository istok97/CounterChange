using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CounterChangeFile.Models
{
    public class Analysis
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Repos Repos { get; set; }
    }
}
