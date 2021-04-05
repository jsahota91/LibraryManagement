using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData;

namespace LibraryBusiness
{
    public class LocationManager
    {
        public Location selectedLocation { get; set; }
        public List<string> displayB = new List<string>();

        //Creating a location method
        public bool Create(string aisle, int bookId)
        {
            var newLocation = new Location() {AisleName = aisle, BookId = bookId };
            using (var db = new LibraryManagementContext())
            {
                bool exists = db.Locations.Any(x => x.AisleName == aisle);
                if (exists == false)
                {
                    db.Locations.Add(newLocation);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            
        }

        //Updating a location 
        public void Update(string oldAisle, string aisle)
        {
            using (var db = new LibraryManagementContext())
            {
                selectedLocation = db.Locations.Where(l => l.AisleName == oldAisle).FirstOrDefault();
                selectedLocation.AisleName = aisle;
                //selectedLocation.BookId = bookId;

                // write changes to database
                db.SaveChanges();
            }
        }

        //Delete a location given their Id
        public void Delete(int locId)
        {
            using (var db = new LibraryManagementContext())
            {
                var delLocation = db.Locations.Where(l => l.LocationId == locId).FirstOrDefault();
                db.Locations.RemoveRange(delLocation);
                // write changes to database
                db.SaveChanges();
            }
        }

        public List<string> RetrieveAll()
        {
            using (var db = new LibraryManagementContext())
            {
                var locationQuery = db.Locations.ToList();
                List<string> locationList = new List<string>();
                foreach (var item in locationQuery)
                {
                    locationList.Add($"{item.LocationId} {item.AisleName}");
                }
                return locationList;
            }
        }

        public void SetSelectedLocation(string selectedItem)
        {
            displayB.Clear();
            using (var db = new LibraryManagementContext())
            {
                selectedLocation = db.Locations.Where(l => l.LocationId + " " + l.AisleName == selectedItem).FirstOrDefault();
                var displayBQuery =
                   from l in db.Locations
                   join b in db.Books on l.BookId equals b.BookId
                   where b.BookId == selectedLocation.BookId
                   select new { Title = b.Title };

                foreach (var item in displayBQuery)
                {
                    displayB.Add(item.Title);
                }
    
            }
        }

    }
}
