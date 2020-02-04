using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashService.Models
{
    public class Match
    {
        public int LeftCatId { get; set; }
        public int RightCatId { get; set; }
        public string MatchResult { get; set; }
    }
}
