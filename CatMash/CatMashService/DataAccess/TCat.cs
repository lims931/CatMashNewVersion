using System;
using System.Collections.Generic;

namespace CatMashService.DataAccess
{
    public partial class TCat
    {
        public TCat()
        {
            TMatchLeftCat = new HashSet<TMatch>();
            TMatchRightCat = new HashSet<TMatch>();
        }

        public int CatId { get; set; }
        public string CatUrl { get; set; }

        public virtual ICollection<TMatch> TMatchLeftCat { get; set; }
        public virtual ICollection<TMatch> TMatchRightCat { get; set; }
    }
}
