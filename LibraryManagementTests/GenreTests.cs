using NUnit.Framework;
using LibraryBusiness;
using LibraryData;
using System.Linq;

namespace LibraryManagementTests
{
    public class GenreTests
    {
        GenreManager _genreManager;
        [SetUp]
        public void Setup()
        {
            _genreManager = new GenreManager();
            //remove test entry in DB if present
            using (var db = new LibraryManagementContext())
            {
                var selectedGenre =
                from g in db.Genres
                where g.GenreName == "testGenre"
                select g;

                db.Genres.RemoveRange(selectedGenre);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewGenreIsAdded_TheNumberOfGenresIncreasesBy1()
        {
            using (var db = new LibraryManagementContext())
            {
                var numberOfGenresBefore = db.Genres.Count();
                _genreManager.Create("testGenre");
                var numberOfGenresAfter = db.Genres.Count();

                Assert.AreEqual(numberOfGenresBefore + 1, numberOfGenresAfter);
            }
        }

        [Test]
        public void WhenAGenresDetailsAreChanged_TheDatabaseIsUpdated()
        {
            using (var db = new LibraryManagementContext())
            {
                _genreManager.Create("oldGenre");
                _genreManager.Update("oldGenre", "Test Genre 2");

                var updatedGenre = db.Genres.Where(g => g.GenreName == "Test Genre 2").FirstOrDefault();
                Assert.AreEqual("Test Genre 2", updatedGenre.GenreName);
            }
        }

        [Test]
        public void WhenAnIdIsPassedInTheGenreIsDeleted()
        {
            using (var db = new LibraryManagementContext())
            {
                var chosenGenre =
                from g in db.Genres
                where g.GenreName == "Test Genre 2"
                select g;

                db.Genres.RemoveRange(chosenGenre);
                db.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new LibraryManagementContext())
            {
                var selectedGenres =
                from g in db.Genres
                where g.GenreName == "Test Genre 2"
                select g;

                db.Genres.RemoveRange(selectedGenres);
                db.SaveChanges();
            }
        }
    }
}