using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CounterChangeFile.Services
{
    public interface ICounterChange
    {
        Task CounterChangeFileInLocalrepositiry();
    }
}
