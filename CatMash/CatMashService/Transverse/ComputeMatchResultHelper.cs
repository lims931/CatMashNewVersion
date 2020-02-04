using System;
using System.Collections.Generic;
using System.Linq;
using CatMashService.Models;
using System.Threading.Tasks;

namespace CatMashService.Transverse
{
    public static class ComputeMatchResultHelper
    {
        public static int GetNumberOfHomeWinsForCat(List<Match> catHomeMatchs)
        {
            return catHomeMatchs.Where(x => x.MatchResult == MatchResultHelper.LEFT_CAT_WIN).Count();
        }

        public static int GetNumberOfHomeLossesForCat(List<Match> catHomeMatchs)
        {
            return catHomeMatchs.Where(x => x.MatchResult == MatchResultHelper.RIGHT_CAT_WIN).Count();
        }

        public static int GetNumberOfAwayWinsForCat(List<Match> catAwayMatchs)
        {
            return catAwayMatchs.Where(x => x.MatchResult == MatchResultHelper.RIGHT_CAT_WIN).Count();
        }

        public static int GetNumberOfAwayLossesForCat(List<Match> catAwayMatchs)
        {
            return catAwayMatchs.Where(x => x.MatchResult == MatchResultHelper.LEFT_CAT_WIN).Count();
        }

        public static int GetNumberOfWinsForCat(List<Match> catHomeMatchs, List<Match> catAwayMatchs)
        {
            return GetNumberOfHomeWinsForCat(catHomeMatchs) + GetNumberOfAwayWinsForCat(catAwayMatchs);
        }

        public static int GetNumberOfLossesForCat(List<Match> catHomeMatchs, List<Match> catAwayMatchs)
        {
            return GetNumberOfHomeLossesForCat(catHomeMatchs) + GetNumberOfAwayLossesForCat(catAwayMatchs);
        }

        public static int GetNumberOfHomeDrawsForCat(List<Match> catHomeMatchs)
        {
            return catHomeMatchs.Where(x => x.MatchResult == MatchResultHelper.DRAW).Count();
        }

        public static int GetNumberOfAwayDrawsForCat(List<Match> catAwayMatchs)
        {
            return catAwayMatchs.Where(x => x.MatchResult == MatchResultHelper.DRAW).Count();
        }

        public static int GetNumberOfDrawsForCat(List<Match> catHomeMatchs, List<Match> catAwayMatchs)
        {
            return GetNumberOfHomeDrawsForCat(catHomeMatchs) + GetNumberOfAwayDrawsForCat(catAwayMatchs);
        }

        public static int GetNumberOfPointsForCat(List<Match> catHomeMatchs, List<Match> catAwayMatchs)
        {
            var numberOfWinsForCat = GetNumberOfWinsForCat(catHomeMatchs, catAwayMatchs);
            var numberOfLossesForCat = GetNumberOfLossesForCat(catHomeMatchs, catAwayMatchs);
            var numberOfDrawsForCat = GetNumberOfDrawsForCat(catHomeMatchs, catAwayMatchs);

            return numberOfWinsForCat * MatchResultHelper.NUMBER_POINTS_WINNER +
                numberOfLossesForCat * MatchResultHelper.NUMBER_POINTS_LOOSER +
                numberOfDrawsForCat * MatchResultHelper.NUMBER_POINTS_DRAW;
        }
    }
}
