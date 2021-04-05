using NUnit.Framework;
using LibraryBusiness;
using LibraryData;
using System.Linq;

namespace LibraryManagementTests
{
    public class BookTests
    {
        BookManager _bookManager;
        [SetUp]
        public void Setup()
        {
            _bookManager = new BookManager();
            //remove test entry in DB if present
            using (var db = new LibraryManagementContext())
            {
                var selectedBooks =
                from b in db.Books
                where b.Title == "testBook"
                select b;

                db.Books.RemoveRange(selectedBooks);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewBookIsAdded_TheNumberOfBooksIncreasesBy1()
        {
            using (var db = new LibraryManagementContext())
            {
                var numberOfBooksBefore = db.Books.Count();
                _bookManager.Create("testBook", 2000);
                var numberOfBooksAfter = db.Books.Count();

                Assert.AreEqual(numberOfBooksBefore + 1, numberOfBooksAfter);
            }
        }

        [Test]
        public void WhenABooksDetailsAreChanged_TheDatabaseIsUpdated()
        {
            using (var db = new LibraryManagementContext())
            {
                _bookManager.Create("oldTest", 2000);
                _bookManager.Update("oldTest", "Test Book 2", 1299);

                var updatedBook = db.Books.Where(b => b.Title== "Test Book 2").FirstOrDefault();
                Assert.AreEqual(1299, updatedBook.YearPublished);
                Assert.AreEqual("Test Book 2", updatedBook.Title);
            }
        }

        [Test]
        public void WhenAnTitleIsPassedInTheBookIsDeleted()
        {
            using (var db = new LibraryManagementContext())
            {
                var chosenBook =
                from b in db.Books
                where b.Title == "Test Book 2"
                select b;

                db.Books.RemoveRange(chosenBook);
                db.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new LibraryManagementContext())
            {
                var selectedBooks =
                from b in db.Books
                where b.Title == "Test Book 2"
                select b;

                db.Books.RemoveRange(selectedBooks);
                db.SaveChanges();
            }
        }
    }
}