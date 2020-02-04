using CatMashService.DataAccess;
using CatMashService.Models;
using CatMashService.Exceptions;
using CatMashService.Transverse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatMashService.Repositories;

namespace CatMashService.Services
{
    public class CatMashServices : ICatMashServices
    {
        private readonly ICatMashRepository _catMashRepository;

        public CatMashServices(ICatMashRepository catMashRepository)
        {
            _catMashRepository = catMashRepository;
        }

        public bool AddMatch(Match match)
        {
            if (match == null)
            {
                throw new ElementNotFoundException();
            }

            if (match.LeftCatId <= 0 || match.RightCatId <= 0 || match.LeftCatId == match.RightCatId)
            {
                throw new InvalidMatchParametersException();
            }

            var tMatch = MapMatchToTMach(match);
            return _catMashRepository.AddMatch(tMatch);
        }

        public List<Match> GetAwayMatchCat(int CatId)
        {
            var allMatchs = _catMashRepository.GetAllMatchs();

            var ayawaTMatchs = allMatchs.Where(x => x.RightCatId == CatId);

            var awayMatchs = new List<Match>();

            if (ayawaTMatchs.Count() > 0)
            {

                foreach (var elem in ayawaTMatchs)
                {
                    var homeMatch = MapTMachToMatch(elem);
                    awayMatchs.Add(homeMatch);
                }
            }

            return awayMatchs;
        }

        public List<Match> GetHomeMatchCat(int CatId)
        {
            var allMatchs = _catMashRepository.GetAllMatchs();

            var homeTMatchs = allMatchs.Where(x => x.LeftCatId == CatId);

            var homeMatchs = new List<Match>();

            if (homeTMatchs.Count() > 0)
            {

                foreach (var elem in homeTMatchs)
                {
                    var homeMatch = MapTMachToMatch(elem);
                    homeMatchs.Add(homeMatch);
                }
            }
            return homeMatchs;
        }

        public Cat GetCatWithsResults(int CatId)
        {
            var catHomeMatchs = GetHomeMatchCat(CatId);
            var catAwayMatchs = GetAwayMatchCat(CatId);

            var numberOfWins = ComputeMatchResultHelper.GetNumberOfWinsForCat(catHomeMatchs, catAwayMatchs);
            var numberOfLooses = ComputeMatchResultHelper.GetNumberOfLossesForCat(catHomeMatchs, catAwayMatchs);
            var numberOfDraws = ComputeMatchResultHelper.GetNumberOfDrawsForCat(catHomeMatchs, catAwayMatchs);

            var numberOfPoints = ComputeMatchResultHelper.GetNumberOfPointsForCat(catHomeMatchs, catAwayMatchs);


            var tCat = _catMashRepository.GetCatById(CatId);

            var cat = new Cat()
            {
                CatId = tCat.CatId,
                CatUrl = tCat.CatUrl,
                CatResult = new CatResult()
                {
                    NumbreOfWins = numberOfWins,
                    NumberOfLosses = numberOfLooses,
                    NumberOfDraws = numberOfDraws,
                    Points = numberOfPoints
                }
            };

            return cat;
        }

        public List<Cat> GetAllCatsWithResults()
        {
            var allTCats = _catMashRepository.GetAllCats();

            var catList = new List<Cat>();

            foreach (var tcat in allTCats)
            {
                var cat = GetCatWithsResults(tcat.CatId);

                catList.Add(cat);
            }

            return catList;
        }


        public Tuple<Cat, Cat> GetOpponents()
        {
            var firstOpponentTCat = _catMashRepository.GetRandomCat();
            var secondOpponentTCat = _catMashRepository.GetRandomCat();

            var firstOpponentCat = new Cat() { CatId = firstOpponentTCat.CatId, CatUrl= firstOpponentTCat.CatUrl };
            var secondOpponentCat = new Cat() { CatId = secondOpponentTCat.CatId, CatUrl = secondOpponentTCat.CatUrl };

             return Tuple.Create(firstOpponentCat, secondOpponentCat);

        }

        private TMatch MapMatchToTMach(Match match)
        {
            return new TMatch()
            {
                LeftCatId = match.LeftCatId,
                RightCatId = match.RightCatId,
                MatchResult = match.MatchResult
            };
        }

        private Match MapTMachToMatch(TMatch tMatch)
        {
            return new Match()
            {
                LeftCatId = tMatch.LeftCatId,
                RightCatId = tMatch.RightCatId,
                MatchResult = tMatch.MatchResult
            };
        }
    }
}
