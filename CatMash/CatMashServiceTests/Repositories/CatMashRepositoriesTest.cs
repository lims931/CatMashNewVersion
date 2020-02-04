using CatMashService.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using CatMashService.Exceptions;
using CatMashService.Repositories;

namespace CatMashServiceTests.Repositories
{
    public class CatMashRepositoriesTest
    {
        [Fact]
        public void Should_OK_GetAllCats_When_Full_DataBase()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB1")
                .Options;

            // Run the test against one instance of the context
            using (var context = new CatMashDBContext(options))
            {
                context.TCat.Add(new TCat { CatUrl = "img1" });
                context.TCat.Add(new TCat { CatUrl = "img2" });
                context.TCat.Add(new TCat { CatUrl = "img3" });
                var updateCount = context.SaveChanges();

                Assert.Equal(3, updateCount);

                var catMashRepository = new CatMashRepository(context);
                var result = catMashRepository.GetAllCats();

                Assert.NotNull(result);
                Assert.NotEmpty(result);
                Assert.Equal(3, result.Count());
            }
        }

        [Fact]
        public void Should_OK_GetAllCats_When_Emty_DataBase()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB2")
                .Options;

            // Run the test against one instance of the context
            using (var context = new CatMashDBContext(options))
            {
                var catMashRepository = new CatMashRepository(context);
                var result = catMashRepository.GetAllCats();

                Assert.NotNull(result);
                Assert.Empty(result);
            }
        }

        [Fact]
        public void Should_NullReferenceException_GetCatById_When_Emty_DataBase()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB3")
                .Options;

            // Run the test against one instance of the context
            using (var context = new CatMashDBContext(options))
            {
                var catId = 1;
                var catMashRepository = new CatMashRepository(context);

                Assert.Throws<ElementNotFoundException>(() => catMashRepository.GetCatById(catId));
            }
        }

        [Fact]
        public void Should_OK_GetCatById_When_Exist_Element()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB4")
                .Options;

            // Run the test against one instance of the context
            using (var context = new CatMashDBContext(options))
            {
                context.TCat.Add(new TCat { CatId = 78, CatUrl = "img1" });
                context.TCat.Add(new TCat { CatUrl = "img2" });
                context.TCat.Add(new TCat { CatUrl = "img3" });
                var updateCount = context.SaveChanges();

                Assert.Equal(3, updateCount);

                var catId = 78;
                var catMashRepository = new CatMashRepository(context);

                var result = catMashRepository.GetCatById(catId);

                Assert.NotNull(result);
                Assert.Equal(78, result.CatId);
            }
        }

        [Fact]
        public void Should_OK_GetRandomCat_When_Full_DataBase()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB5")
                .Options;

            // Run the test against one instance of the context
            using (var context = new CatMashDBContext(options))
            {
                context.TCat.Add(new TCat { CatUrl = "img1" });
                context.TCat.Add(new TCat { CatUrl = "img2" });
                context.TCat.Add(new TCat { CatUrl = "img3" });
                context.TCat.Add(new TCat { CatUrl = "img4" });
                context.TCat.Add(new TCat { CatUrl = "img5" });
                context.TCat.Add(new TCat { CatUrl = "img6" });
                var updateCount = context.SaveChanges();

                Assert.Equal(6, updateCount);

                var catMashRepository = new CatMashRepository(context);
                var result = catMashRepository.GetRandomCat();

                Assert.NotNull(result);
                Assert.NotNull(result.CatUrl);
            }
        }

        [Fact]
        public void Should_Exception_AddMatche_When_LeftCatId_NotFound()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB6")
                .Options;

            // Run the test against one instance of the context
            using (var context = new CatMashDBContext(options))
            {
                context.TCat.Add(new TCat { CatId = 55, CatUrl = "img1" });
                context.TCat.Add(new TCat { CatId = 56, CatUrl = "img2" });
                context.TCat.Add(new TCat { CatId = 57, CatUrl = "img3" });
                var updateCountTCat = context.SaveChanges();

                Assert.Equal(3, updateCountTCat);

                var matche = new TMatch() { LeftCatId = 11, RightCatId = 56, MatchResult = "x" };

                var catMashRepository = new CatMashRepository(context);

                Assert.Throws<ElementNotFoundException>(() => catMashRepository.AddMatch(matche));
            }
        }

        [Fact]
        public void Should_Exception_AddMatche_When_RightCatId_NotFound()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB7")
                .Options;

            // Run the test against one instance of the context
            using (var context = new CatMashDBContext(options))
            {
                context.TCat.Add(new TCat { CatId = 55, CatUrl = "img1" });
                context.TCat.Add(new TCat { CatId = 56, CatUrl = "img2" });
                context.TCat.Add(new TCat { CatId = 57, CatUrl = "img3" });
                var updateCountTCat = context.SaveChanges();

                Assert.Equal(3, updateCountTCat);

                var matche = new TMatch() { LeftCatId = 55, RightCatId = 20, MatchResult = "1" };

                var catMashRepository = new CatMashRepository(context);

                Assert.Throws<ElementNotFoundException>(() => catMashRepository.AddMatch(matche));
            }
        }

        [Fact]
        public void Should_Exception_AddMatche_When_MatchResult_Invalid()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB8")
                .Options;

            // Run the test against one instance of the context
            using (var context = new CatMashDBContext(options))
            {
                context.TCat.Add(new TCat { CatId = 55, CatUrl = "img1" });
                context.TCat.Add(new TCat { CatId = 56, CatUrl = "img2" });
                context.TCat.Add(new TCat { CatId = 57, CatUrl = "img3" });
                var updateCountTCat = context.SaveChanges();

                Assert.Equal(3, updateCountTCat);

                var matche = new TMatch() { LeftCatId = 55, RightCatId = 56, MatchResult = "UnknownResult" };

                var catMashRepository = new CatMashRepository(context);

                Assert.Throws<UnknownMatcheResultException>(() => catMashRepository.AddMatch(matche));
            }
        }

        [Fact]
        public void Should_OK_AddMatche_When_Valid_Params()
        {
            var options = new DbContextOptionsBuilder<CatMashDBContext>()
                .UseInMemoryDatabase(databaseName: "CatMashDB9")
                .Options;

            // Run the test against one instance of the context
            using (var context = new CatMashDBContext(options))
            {
                context.TCat.Add(new TCat { CatId = 55, CatUrl = "img1" });
                context.TCat.Add(new TCat { CatId = 56, CatUrl = "img2" });
                context.TCat.Add(new TCat { CatId = 57, CatUrl = "img3" });
                var updateCountTCat = context.SaveChanges();

                Assert.Equal(3, updateCountTCat);

                var matche = new TMatch() { LeftCatId = 55, RightCatId = 56, MatchResult = "X" };

                var catMashRepository = new CatMashRepository(context);
                var result = catMashRepository.AddMatch(matche);

                Assert.True(result);
            }
        }
    }
}
