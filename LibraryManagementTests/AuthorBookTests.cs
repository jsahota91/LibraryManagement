using NUnit.Framework;
using LibraryBusiness;
using LibraryData;
using System.Linq;

namespace LibraryManagementTests
{
    public class AuthorBookTests
    {
        AuthorBookManager _authorBookManager;
        [SetUp]
        public void Setup()
        {
            _authorBookManager = new AuthorBookManager();
            //remove test entry in DB if present
            using (var db = new LibraryManagementContext())
            {
                var selectedAuthorBook =
                from b in db.AuthorBooks
                where b.BookId == 4
                select b;

                db.AuthorBooks.RemoveRange(selectedAuthorBook);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewAuthorBookIsAdded_TheNumberOfAuthorBooksIncreasesBy1()
        {
            using (var db = new LibraryManagementContext())
            {
                var numberOfAuthorBooksBefore = db.AuthorBooks.Count();
                _authorBookManager.Create(5, 4);
                var numberOfAuthorBooksAfter = db.AuthorBooks.Count();

                Assert.AreEqual(numberOfAuthorBooksBefore + 1, numberOfAuthorBooksAfter);
            }
        }

        [Test]
        public void WhenAnAuthorBooksDetailsAreChanged_TheDatabaseIsUpdated()
        {
            using (var db = new LibraryManagementContext())
            {
                _authorBookManager.Create(3, 3);
                _authorBookManager.Update(3, 3, 6);

                var updatedAuthorBook = db.AuthorBooks.Where(ab => ab.BookId == 3 && ab.AuthorId == 6).FirstOrDefault();
                Assert.AreEqual(6, updatedAuthorBook.AuthorId);
            }
        }

        [Test]
        public void WhenABookIdIsPassedInTheAuthorBookReferenceIsDeleted()
        {
            using (var db = new LibraryManagementContext())
            {
                var selectedAuthor =
                from b in db.AuthorBooks
                where b.BookId == 3
                select b;

                db.AuthorBooks.RemoveRange(selectedAuthor);
                db.SaveChanges();

            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new LibraryManagementContext())
            {
                var selectedAuthor =
                from b in db.AuthorBooks
                where b.BookId == 3
                select b;

                db.AuthorBooks.RemoveRange(selectedAuthor);
                db.SaveChanges();
            }
        }
    }
}