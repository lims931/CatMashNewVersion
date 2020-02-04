using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashService.Transverse
{
    public static class MatchResultHelper
    {
        public static readonly string LEFT_CAT_WIN = "1";
        public static readonly string RIGHT_CAT_WIN = "2";
        public static readonly string DRAW = "X";

        public static readonly int NUMBER_POINTS_WINNER = 3;
        public static readonly int NUMBER_POINTS_LOOSER = 0;
        public static readonly int NUMBER_POINTS_DRAW = 1;

        public static bool IsValidMatchResult(string matchResult)
        {
            return matchResult != LEFT_CAT_WIN && matchResult != RIGHT_CAT_WIN && matchResult != DRAW;
        }
    }
}
