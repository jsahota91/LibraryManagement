using NUnit.Framework;
using LibraryBusiness;
using LibraryData;
using System.Linq;

namespace LibraryManagementTests
{
    public class AuthorTests
    {
        AuthorManager _authorManager;
        [SetUp]
        public void Setup()
        {
            _authorManager = new AuthorManager();
            //remove test entry in DB if present
            using (var db = new LibraryManagementContext())
            {
                var selectedAuthor =
                from a in db.Authors
                where a.FirstName == "testF" && a.LastName == "testL"
                select a;

                db.Authors.RemoveRange(selectedAuthor);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewAuthorIsAdded_TheNumberOfAuthorsIncreasesBy1()
        {
            using (var db = new LibraryManagementContext())
            {
                var numberOfAuthorsBefore = db.Authors.Count();
                _authorManager.Create("testF", "testL");
                var numberOfAuthorsAfter = db.Authors.Count();

                Assert.AreEqual(numberOfAuthorsBefore + 1, numberOfAuthorsAfter);
            }
        }

        [Test]
        public void WhenAnAuthorsDetailsAreChanged_TheDatabaseIsUpdated()
        {
            using (var db = new LibraryManagementContext())
            {
                _authorManager.Create("oldFName", "oldLName");
                _authorManager.Update("oldFName", "oldLName", "FNameNew", "LNameNew");

                var updatedAuthor = db.Authors.Where(a => a.FirstName == "FNameNew" && a.LastName == "LNameNew").FirstOrDefault();
                Assert.AreEqual("FNameNew", updatedAuthor.FirstName);
                Assert.AreEqual("LNameNew", updatedAuthor.LastName);
            }
        }

        [Test]
        public void WhenAnIdIsPassedInTheAuthorIsDeleted()
        {
            using (var db = new LibraryManagementContext())
            {
                var chosenAuthor =
                from a in db.Authors
                where a.FirstName == "FNameNew" && a.LastName == "LNameNew"
                select a;

                db.Authors.RemoveRange(chosenAuthor);
                db.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new LibraryManagementContext())
            {
                var selectedAuthors =
                from a in db.Authors
                where a.FirstName == "FNameNew" && a.LastName == "LNameNew"
                select a;

                db.Authors.RemoveRange(selectedAuthors);
                db.SaveChanges();
            }
        }
    }
}