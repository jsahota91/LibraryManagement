using NUnit.Framework;
using LibraryBusiness;
using LibraryData;
using System.Linq;

namespace LibraryManagementTests
{
    public class LocationTests
    {
        LocationManager _locationManager;
        [SetUp]
        public void Setup()
        {
            _locationManager = new LocationManager();
            //remove test entry in DB if present
            using (var db = new LibraryManagementContext())
            {
                var selectedLocation =
                from l in db.Locations
                where l.AisleName == "testLoc"
                select l;

                db.Locations.RemoveRange(selectedLocation);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewLocationIsAdded_TheNumberOfLocationIncreasesBy1()
        {
            using (var db = new LibraryManagementContext())
            {
                var numberOfLocationsBefore = db.Locations.Count();
                _locationManager.Create("testLoc", 6);
                var numberOfLocationsAfter = db.Locations.Count();

                Assert.AreEqual(numberOfLocationsBefore + 1, numberOfLocationsAfter);
            }
        }

        [Test]
        public void WhenALocationsDetailsAreChanged_TheDatabaseIsUpdated()
        {
            using (var db = new LibraryManagementContext())
            {
                _locationManager.Create("locOld", 6);
                _locationManager.Update("locOld", "Test Loc 2");

                var updatedLocation = db.Locations.Where(l => l.AisleName == "Test Loc 2").FirstOrDefault();
                Assert.AreEqual("Test Loc 2", updatedLocation.AisleName);
                //Assert.AreEqual(7, updatedLocation.BookId);
            }
        }

        [Test]
        public void WhenALocationIdIsPassedInTheLocationIsDeleted()
        {
            using (var db = new LibraryManagementContext())
            {
                var chosenLocation =
                from l in db.Locations
                where l.AisleName == "Test Loc 2"
                select l;

                db.Locations.RemoveRange(chosenLocation);
                db.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new LibraryManagementContext())
            {
                var selectedLocation =
                from l in db.Locations
                where l.AisleName == "Test Loc 2"
                select l;

                db.Locations.RemoveRange(selectedLocation);
                db.SaveChanges();
            }
        }
    }
}