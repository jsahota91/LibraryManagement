using NUnit.Framework;
using LibraryBusiness;
using LibraryData;
using System.Linq;

namespace LibraryManagementTests
{
    public class BookGenreTests
    {
        BookGenreManager _bookGenreManager;
        [SetUp]
        public void Setup()
        {
            _bookGenreManager = new BookGenreManager();
            //remove test entry in DB if present
            using (var db = new LibraryManagementContext())
                {
                    var selectedBookGenre =
                    from b in db.BookGenres
                    where b.BookId == 5
                    select b;

                    db.BookGenres.RemoveRange(selectedBookGenre);
                    db.SaveChanges();
                }
        }

        [Test]
        public void WhenANewBookIsAdded_TheNumberOfBooksIncreasesBy1()
        {
            using (var db = new LibraryManagementContext())
            {
                var numberOfBookGenresBefore = db.BookGenres.Count();
                _bookGenreManager.Create(5, 7);
                var numberOfBookGenresAfter = db.BookGenres.Count();

                Assert.AreEqual(numberOfBookGenresBefore + 1, numberOfBookGenresAfter);
            }
        }

        [Test]
        public void WhenABooksDetailsAreChanged_TheDatabaseIsUpdated()
        {
            using (var db = new LibraryManagementContext())
            {
                _bookGenreManager.Create(9, 6);
                _bookGenreManager.Update(9, 6, 1);

                var updatedBookGenre = db.BookGenres.Where(bg => bg.BookId == 9 && bg.GenreId == 1).FirstOrDefault();
                Assert.AreEqual(1, updatedBookGenre.GenreId);
            }
        }

        [Test]
        public void WhenAnTitleIsPassedInTheBookIsDeleted()
        {
            using (var db = new LibraryManagementContext())
            {
                var selectedGenre =
                from b in db.BookGenres
                where b.BookId == 9
                select b;

                db.BookGenres.RemoveRange(selectedGenre);
                db.SaveChanges();

            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new LibraryManagementContext())
            {
                var selectedGenre =
                from b in db.BookGenres
                where b.BookId == 9
                select b;

                db.BookGenres.RemoveRange(selectedGenre);
                db.SaveChanges();
            }
        }
    }
}