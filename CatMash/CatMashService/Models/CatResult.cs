using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashService.Models
{
    public class CatResult
    {
        public int NumbreOfWins { get; set; }

        public int NumberOfLosses { get; set; }

        public int NumberOfDraws { get; set; }

        public int Points { get; set; }
    }
}
