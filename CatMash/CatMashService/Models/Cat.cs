using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashService.Models
{
    public class Cat
    {
        public int CatId { get; set; }

        public string CatUrl { get; set; }

        public CatResult CatResult { get; set; }
    }
}
