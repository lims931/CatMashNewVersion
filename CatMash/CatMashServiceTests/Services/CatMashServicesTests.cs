using CatMashService.DataAccess;
using CatMashService.Services;
using Microsoft.EntityFrameworkCore;
using CatMashService.Exceptions;
using models = CatMashService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CatMashService.Repositories;

namespace CatMashServiceTests.Services
{
    public class CatMashServicesTests
    {
        [Fact]
        public void Should_Exception_AddMatch_When_Null_Param()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB1")
                .Options;

            using (var context = new CatMashDBContext(options))
            {
                var catMashRepository = new CatMashRepository(context);

                var catMashService = new CatMashServices(catMashRepository);

                Assert.Throws<ElementNotFoundException>(() => catMashService.AddMatch(null));
            }
        }

        [Fact]
        public void Should_Exception_AddMatch_When_invalid_LeftCatId()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB2")
                .Options;

            using (var context = new CatMashDBContext(options))
            {
                var catMashRepository = new CatMashRepository(context);

                var catMashService = new CatMashServices(catMashRepository);

                var match = new models.Match() { LeftCatId = -1, MatchResult = "X", RightCatId = 2 };

                Assert.Throws<InvalidMatchParametersException>(() => catMashService.AddMatch(match));
            }
        }

        [Fact]
        public void Should_Exception_AddMatch_When_invalid_RightCatId()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB3")
                .Options;

            using (var context = new CatMashDBContext(options))
            {
                var catMashRepository = new CatMashRepository(context);

                var catMashService = new CatMashServices(catMashRepository);

                var match = new models.Match() { LeftCatId = 1, MatchResult = "X", RightCatId = -2 };

                Assert.Throws<InvalidMatchParametersException>(() => catMashService.AddMatch(match));
            }
        }

        [Fact]
        public void Should_Exception_AddMatch_When_Same_Ids()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB4")
                .Options;

            using (var context = new CatMashDBContext(options))
            {
                var catMashRepository = new CatMashRepository(context);

                var catMashService = new CatMashServices(catMashRepository);

                var match = new models.Match() { LeftCatId = 82, MatchResult = "X", RightCatId = 82 };

                Assert.Throws<InvalidMatchParametersException>(() => catMashService.AddMatch(match));
            }
        }


        [Fact]
        public void Should_OK_GetAwayMatchCat_When_Full_DataBase()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB5")
                .Options;

            // Run the test against one instance of the context
            using (var context = new CatMashDBContext(options))
            {
                context.TMatch.Add(new TMatch { LeftCatId = 2, RightCatId = 1, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 1, RightCatId = 2, MatchResult = "X" });
                context.TMatch.Add(new TMatch { LeftCatId = 5, RightCatId = 2, MatchResult = "2" });
                context.TMatch.Add(new TMatch { LeftCatId = 2, RightCatId = 3, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 3, RightCatId = 2, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 4, RightCatId = 3, MatchResult = "1" });
                var addmatchCount = context.SaveChanges();

                Assert.Equal(6, addmatchCount);

                var catMashRepository = new CatMashRepository(context);

                var catMashService = new CatMashServices(catMashRepository);

                var result = catMashService.GetAwayMatchCat(2);

                Assert.NotNull(result);
                Assert.NotEmpty(result);
                Assert.Equal(3, result.Count);
                Assert.Equal("1", result[2].MatchResult);
            }
        }

        [Fact]
        public void Should_Null_GetAwayMatchCat_When_No_Matches()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB6")
                .Options;

            // Run the test against one instance of the context
            using (var context = new CatMashDBContext(options))
            {
                context.TMatch.Add(new TMatch { LeftCatId = 2, RightCatId = 1, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 1, RightCatId = 2, MatchResult = "X" });
                context.TMatch.Add(new TMatch { LeftCatId = 5, RightCatId = 2, MatchResult = "2" });
                context.TMatch.Add(new TMatch { LeftCatId = 2, RightCatId = 3, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 3, RightCatId = 2, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 4, RightCatId = 3, MatchResult = "1" });
                var addmatchCount = context.SaveChanges();

                Assert.Equal(6, addmatchCount);

                var catMashRepository = new CatMashRepository(context);

                var catMashService = new CatMashServices(catMashRepository);

                var result = catMashService.GetAwayMatchCat(88);

                Assert.NotNull(result);
                Assert.Empty(result);
            }
        }

        [Fact]
        public void Should_OK_GetHomeMatchCat_When_Full_DataBase()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB7")
                .Options;

            // Run the test against one instance of the context
            using (var context = new CatMashDBContext(options))
            {
                context.TMatch.Add(new TMatch { LeftCatId = 2, RightCatId = 1, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 1, RightCatId = 2, MatchResult = "X" });
                context.TMatch.Add(new TMatch { LeftCatId = 5, RightCatId = 2, MatchResult = "2" });
                context.TMatch.Add(new TMatch { LeftCatId = 2, RightCatId = 3, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 3, RightCatId = 2, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 4, RightCatId = 3, MatchResult = "1" });
                var addmatchCount = context.SaveChanges();

                Assert.Equal(6, addmatchCount);

                var catMashRepository = new CatMashRepository(context);

                var catMashService = new CatMashServices(catMashRepository);

                var result = catMashService.GetHomeMatchCat(2);

                Assert.NotNull(result);
                Assert.NotEmpty(result);
                Assert.Equal(2, result.Count);
                Assert.Equal("1", result[1].MatchResult);
            }
        }

        [Fact]
        public void Should_Null_GetHomeMatchCat_When_No_Matches()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB8")
                .Options;

            // Run the test against one instance of the context
            using (var context = new CatMashDBContext(options))
            {
                context.TMatch.Add(new TMatch { LeftCatId = 2, RightCatId = 1, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 1, RightCatId = 2, MatchResult = "X" });
                context.TMatch.Add(new TMatch { LeftCatId = 5, RightCatId = 2, MatchResult = "2" });
                context.TMatch.Add(new TMatch { LeftCatId = 2, RightCatId = 3, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 3, RightCatId = 2, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 4, RightCatId = 3, MatchResult = "1" });
                var addmatchCount = context.SaveChanges();

                Assert.Equal(6, addmatchCount);

                var catMashRepository = new CatMashRepository(context);

                var catMashService = new CatMashServices(catMashRepository);

                var result = catMashService.GetHomeMatchCat(88);

                Assert.NotNull(result);
                Assert.Empty(result);
            }
        }

        [Fact]
        public void Should_OK_GetCatWithsResults_When_Full_DataBase()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB9")
                .Options;

            // Run the test against one instance of the context
            using (var context = new CatMashDBContext(options))
            {
                context.TCat.Add(new TCat { CatId = 1, CatUrl = "img1" });
                context.TCat.Add(new TCat { CatId = 2, CatUrl = "img2" });
                context.TCat.Add(new TCat { CatId = 3, CatUrl = "img3" });
                context.TCat.Add(new TCat { CatId = 4, CatUrl = "img3" });
                context.TCat.Add(new TCat { CatId = 5, CatUrl = "img3" });

                var addCatCount = context.SaveChanges();

                Assert.Equal(5, addCatCount);

                context.TMatch.Add(new TMatch { LeftCatId = 2, RightCatId = 1, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 1, RightCatId = 2, MatchResult = "X" });
                context.TMatch.Add(new TMatch { LeftCatId = 5, RightCatId = 2, MatchResult = "2" });
                context.TMatch.Add(new TMatch { LeftCatId = 2, RightCatId = 3, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 3, RightCatId = 2, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 4, RightCatId = 3, MatchResult = "1" });
                var addmatchCount = context.SaveChanges();

                Assert.Equal(6, addmatchCount);

                var catMashRepository = new CatMashRepository(context);

                var catMashService = new CatMashServices(catMashRepository);

                var result = catMashService.GetCatWithsResults(2);

                Assert.NotNull(result);
                Assert.Equal(2, result.CatId);
                Assert.Equal(3, result.CatResult.NumbreOfWins);
                Assert.Equal(1, result.CatResult.NumberOfLosses);
                Assert.Equal(1, result.CatResult.NumberOfDraws);
                Assert.Equal(10, result.CatResult.Points);
            }
        }

        [Fact]
        public void Should_OK_GetCatWithsResults_When_No_Matches()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB10")
                .Options;

            // Run the test against one instance of the context
            using (var context = new CatMashDBContext(options))
            {
                context.TCat.Add(new TCat { CatId = 1, CatUrl = "img1" });
                context.TCat.Add(new TCat { CatId = 2, CatUrl = "img2" });
                context.TCat.Add(new TCat { CatId = 3, CatUrl = "img3" });
                context.TCat.Add(new TCat { CatId = 4, CatUrl = "img3" });
                context.TCat.Add(new TCat { CatId = 5, CatUrl = "img3" });
                context.TCat.Add(new TCat { CatId = 88, CatUrl = "img3" });

                var addCatCount = context.SaveChanges();

                Assert.Equal(6, addCatCount);

                context.TMatch.Add(new TMatch { LeftCatId = 2, RightCatId = 1, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 1, RightCatId = 2, MatchResult = "X" });
                context.TMatch.Add(new TMatch { LeftCatId = 5, RightCatId = 2, MatchResult = "2" });
                context.TMatch.Add(new TMatch { LeftCatId = 2, RightCatId = 3, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 3, RightCatId = 2, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 4, RightCatId = 3, MatchResult = "1" });
                var addmatchCount = context.SaveChanges();

                Assert.Equal(6, addmatchCount);

                var catMashRepository = new CatMashRepository(context);

                var catMashService = new CatMashServices(catMashRepository);

                var result = catMashService.GetCatWithsResults(88);

                Assert.NotNull(result);
                Assert.Equal(0, result.CatResult.Points);
            }
        }

        [Fact]
        public void Should_OK_GetAllCatsWithResults_When_Full_DataBase()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB11")
                .Options;

            // Run the test against one instance of the context
            using (var context = new CatMashDBContext(options))
            {
                context.TCat.Add(new TCat { CatId = 1, CatUrl = "img1" });
                context.TCat.Add(new TCat { CatId = 2, CatUrl = "img2" });
                context.TCat.Add(new TCat { CatId = 3, CatUrl = "img3" });
                context.TCat.Add(new TCat { CatId = 4, CatUrl = "img3" });
                context.TCat.Add(new TCat { CatId = 5, CatUrl = "img3" });
                context.TCat.Add(new TCat { CatId = 88, CatUrl = "img3" });

                var addCatCount = context.SaveChanges();

                Assert.Equal(6, addCatCount);

                context.TMatch.Add(new TMatch { LeftCatId = 2, RightCatId = 1, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 1, RightCatId = 2, MatchResult = "X" });
                context.TMatch.Add(new TMatch { LeftCatId = 5, RightCatId = 2, MatchResult = "2" });
                context.TMatch.Add(new TMatch { LeftCatId = 2, RightCatId = 3, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 3, RightCatId = 2, MatchResult = "1" });
                context.TMatch.Add(new TMatch { LeftCatId = 4, RightCatId = 3, MatchResult = "1" });
                var addmatchCount = context.SaveChanges();

                Assert.Equal(6, addmatchCount);

                var catMashRepository = new CatMashRepository(context);

                var catMashService = new CatMashServices(catMashRepository);

                var result = catMashService.GetAllCatsWithResults();

                Assert.NotNull(result);
                Assert.NotEmpty(result);
                Assert.Equal(0, result.Find(x => x.CatId == 88).CatResult.Points);

                Assert.Equal(3, result.Find(x => x.CatId == 2).CatResult.NumbreOfWins);
                Assert.Equal(1, result.Find(x => x.CatId == 2).CatResult.NumberOfLosses);
                Assert.Equal(1, result.Find(x => x.CatId == 2).CatResult.NumberOfDraws);
                Assert.Equal(10, result.Find(x => x.CatId == 2).CatResult.Points);

                Assert.Equal(0, result.Find(x => x.CatId == 5).CatResult.NumbreOfWins);
                Assert.Equal(1, result.Find(x => x.CatId == 5).CatResult.NumberOfLosses);
                Assert.Equal(0, result.Find(x => x.CatId == 5).CatResult.NumberOfDraws);
                Assert.Equal(0, result.Find(x => x.CatId == 5).CatResult.Points);
            }
        }
    }
}
