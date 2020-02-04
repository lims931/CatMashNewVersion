using CatMashService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashService.Repositories
{
    public interface ICatMashRepository
    {
        bool AddMatch(TMatch matche);

        TCat GetCatById(int id);

        IEnumerable<TCat> GetAllCats();

        TCat GetRandomCat();

        IEnumerable<TMatch> GetAllMatchs();
    }
}
