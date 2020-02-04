using CatMashService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashService.Services
{
    public interface ICatMashServices
    {
        List<Cat> GetAllCatsWithResults();

        bool AddMatch(Match match);

        List<Match> GetHomeMatchCat(int CatId);

        List<Match> GetAwayMatchCat(int CatId);

        Cat GetCatWithsResults(int CatId);

        Tuple<Cat, Cat> GetOpponents();
    }
}
