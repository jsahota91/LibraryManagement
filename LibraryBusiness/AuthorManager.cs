using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData;

namespace LibraryBusiness
{
    public class AuthorManager
    {
        public Author selectedAuthor { get; set; }

        //Creating a author method
        public bool Create(string firstName, string lastName)
        {
            var newAuthor= new Author() { FirstName = firstName, LastName = lastName };
            using (var db = new LibraryManagementContext())
            {
                bool exists = db.Authors.Any(x => x.FirstName == firstName && x.LastName == lastName);
                if (exists == false)
                {
                    db.Authors.Add(newAuthor);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        //Updating an author
        public void Update(string oldFirstName, string oldLastName, string firstName, string lastName)
        {
            using (var db = new LibraryManagementContext())
            {
                selectedAuthor = db.Authors.Where(a => a.FirstName == oldFirstName && a.LastName == oldLastName).FirstOrDefault();
                selectedAuthor.FirstName = firstName;
                selectedAuthor.LastName = lastName;
                // write changes to database
                db.SaveChanges();
            }
        }

        //Delete an author given their Id
        public void Delete(int authorId)
        {
            using (var db = new LibraryManagementContext())
            {
                var delAuthor = db.Authors.Where(a => a.AuthorId == authorId).FirstOrDefault();
                db.Authors.RemoveRange(delAuthor);
                // write changes to database
                db.SaveChanges();
            }
        }

        //Select and retrieve all the authors as a list
        //public List<Author> RetrieveAll()
        //{
        //    List<Author> displayA = new List<Author>();
        //    using (var db = new LibraryManagementContext())
        //    {
        //        var getAuthors =
        //            from a in db.Authors
        //            select a;
        //        foreach (var item in getAuthors)
        //        {
        //            displayA.Add(item);
        //        }
        //        return displayA;
        //    }
        //}

        //Select and retrieve all the genres as a LISTBOX
        public List<string> GetAll()
        {
            using (var db = new LibraryManagementContext())
            {
                var aGetAllQuery = db.Authors.ToList();
                List<string> authorList = new List<string>();
                foreach (var item in aGetAllQuery)
                {
                    authorList.Add($"{item.AuthorId} {item.FirstName} {item.LastName}");
                }
                return authorList;
            }
        }

        public void SetSelectedAuthor(string selectedItem)
        {
            using (var db = new LibraryManagementContext())
            {
                selectedAuthor = db.Authors.Where(a => a.AuthorId + " " + a.FirstName + " " + a.LastName == selectedItem).FirstOrDefault();
            }
        }

    }
}
