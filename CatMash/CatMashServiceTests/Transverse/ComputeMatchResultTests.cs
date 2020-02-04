using CatMashService.Transverse;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CatMashService.Models;

namespace CatMashServiceTests.Transverse
{
    public class ComputeMatchResultTests
    {
        [Fact]
        public void Should_OK_ComputesNumberOfHomeLooses()
        {
            var matchList = GetHomeMatchs();
            var numberOfHomeLooses = ComputeMatchResultHelper.GetNumberOfHomeLossesForCat(matchList);

            Assert.Equal(4, numberOfHomeLooses);
        }

        [Fact]
        public void Should_OK_ComputesNumberOfAwayLooses()
        {
            var matchList = GetHomeMatchs();
            var numberOfAwayLooses = ComputeMatchResultHelper.GetNumberOfAwayLossesForCat(matchList);

            Assert.Equal(8, numberOfAwayLooses);
        }

        [Fact]
        public void Should_OK_ComputesNumberOfHomeWins()
        {
            var matchList = GetHomeMatchs();
            var numberOfHomeWins = ComputeMatchResultHelper.GetNumberOfHomeWinsForCat(matchList);

            Assert.Equal(8, numberOfHomeWins);
        }

        [Fact]
        public void Should_OK_ComputesNumberOfAwayWins()
        {
            var matchList = GetAwayMatchs();

            var numberOfAwayWins = ComputeMatchResultHelper.GetNumberOfAwayWinsForCat(matchList);

            Assert.Equal(6, numberOfAwayWins);
        }

        [Fact]
        public void Should_OK_ComputesNumberOfHomeDraws()
        {
            var matchList = GetHomeMatchs();

            var numberOfHomeDraws = ComputeMatchResultHelper.GetNumberOfHomeDrawsForCat(matchList);

            Assert.Equal(4, numberOfHomeDraws);
        }

        [Fact]
        public void Should_OK_ComputesNumberOfAwayDraws()
        {
            var matchList = GetAwayMatchs();

            var numberOfAwayDraws = ComputeMatchResultHelper.GetNumberOfAwayDrawsForCat(matchList);

            Assert.Equal(2, numberOfAwayDraws);
        }


        [Fact]
        public void Should_OK_ComputesNumberOfWins()
        {
            var homeMatchList = GetHomeMatchs();

            var awayMatchList = GetAwayMatchs();

            var numberOfwins = ComputeMatchResultHelper.GetNumberOfWinsForCat(homeMatchList, awayMatchList);

            Assert.Equal(14, numberOfwins);
        }


        [Fact]
        public void Should_OK_ComputesNumberOfLooses()
        {
            var homeMatchList = GetHomeMatchs();

            var awayMatchList = GetAwayMatchs();

            var numberOfwins = ComputeMatchResultHelper.GetNumberOfLossesForCat(homeMatchList, awayMatchList);

            Assert.Equal(12, numberOfwins);
        }

        [Fact]
        public void Should_OK_ComputesNumberOfDraws()
        {
            var homeMatchList = GetHomeMatchs();

            var awayMatchList = GetAwayMatchs();

            var numberOfDraws = ComputeMatchResultHelper.GetNumberOfDrawsForCat(homeMatchList, awayMatchList);

            Assert.Equal(6, numberOfDraws);
        }

        [Fact]
        public void Should_OK_ComputesNumberOfPoints()
        {
            var homeMatchList = GetHomeMatchs();

            var awayMatchList = GetAwayMatchs();

            var numberOfDraws = ComputeMatchResultHelper.GetNumberOfPointsForCat(homeMatchList, awayMatchList);

            Assert.Equal(6 * 1 + 12 * 0 + 14 * 3, numberOfDraws);
        }

        private List<Match> GetHomeMatchs()
        {
            var homeMatchList = new List<Match>()
            {
                new Match(){ LeftCatId=96, RightCatId=2, MatchResult="1" },
                new Match(){ LeftCatId=96, RightCatId=8, MatchResult="X" },
                new Match(){ LeftCatId=96, RightCatId=5, MatchResult="2" },
                new Match(){ LeftCatId=96, RightCatId=9, MatchResult="1" },
                new Match(){ LeftCatId=96, RightCatId=4, MatchResult="X" },
                new Match(){ LeftCatId=96, RightCatId=23, MatchResult="1" },
                new Match(){ LeftCatId=96, RightCatId=27, MatchResult="1" },
                new Match(){ LeftCatId=96, RightCatId=29, MatchResult="2" },
                new Match(){ LeftCatId=96, RightCatId=32, MatchResult="2" },
                new Match(){ LeftCatId=96, RightCatId=77, MatchResult="X" },
                new Match(){ LeftCatId=96, RightCatId=11, MatchResult="1" },
                new Match(){ LeftCatId=96, RightCatId=55, MatchResult="1" },
                new Match(){ LeftCatId=96, RightCatId=78, MatchResult="2" },
                new Match(){ LeftCatId=96, RightCatId=77, MatchResult="1" },
                new Match(){ LeftCatId=96, RightCatId=22, MatchResult="X" },
                new Match(){ LeftCatId=96, RightCatId=26, MatchResult="1" },

            };

            return homeMatchList;
        }

        private List<Match> GetAwayMatchs()
        {
            var awayMatchList = new List<Match>()
            {
                 new Match(){ LeftCatId=76, RightCatId=2, MatchResult="1" },
                new Match(){ LeftCatId=6, RightCatId=2, MatchResult="X" },
                new Match(){ LeftCatId=68, RightCatId=2, MatchResult="2" },
                new Match(){ LeftCatId=57, RightCatId=2, MatchResult="1" },
                new Match(){ LeftCatId=55, RightCatId=2, MatchResult="1" },
                new Match(){ LeftCatId=51, RightCatId=2, MatchResult="1" },
                new Match(){ LeftCatId=52, RightCatId=2, MatchResult="2" },
                new Match(){ LeftCatId=52, RightCatId=2, MatchResult="2" },
                new Match(){ LeftCatId=25, RightCatId=2, MatchResult="2" },
                new Match(){ LeftCatId=25, RightCatId=2, MatchResult="2" },
                new Match(){ LeftCatId=35, RightCatId=2, MatchResult="2" },
                new Match(){ LeftCatId=85, RightCatId=2, MatchResult="X" },
                new Match(){ LeftCatId=99, RightCatId=2, MatchResult="1" },
                new Match(){ LeftCatId=22, RightCatId=2, MatchResult="1" },
                new Match(){ LeftCatId=33, RightCatId=2, MatchResult="1" },
                new Match(){ LeftCatId=44, RightCatId=2, MatchResult="1" },

            };

            return awayMatchList;
        }
    }
}
