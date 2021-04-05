using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData;

namespace LibraryBusiness
{
    public class AuthorBookManager
    {
        public AuthorBook selectedABRef { get; set; }
        

        //Creating a Author Book Reference method
        public void Create(int aId, int bId)
        {
            var newABRef = new AuthorBook() {AuthorId = aId, BookId = bId};
            using (var db = new LibraryManagementContext())
            {
                db.AuthorBooks.Add(newABRef);
                db.SaveChanges();
            }
        }

        //Updating a Author Book  Reference 
        public void Update(int aId, int bId, int newaId)
        {
            using (var db = new LibraryManagementContext())
            {
               
                selectedABRef = db.AuthorBooks.Where(a => a.AuthorId == aId &&  a.BookId == bId).FirstOrDefault();
                if(selectedABRef != null)
                {
                    db.AuthorBooks.Remove(selectedABRef);
                    AuthorBook updatedAuthorBook = new AuthorBook()
                    {
                        BookId = bId,
                        AuthorId = newaId
                    };
                    db.AuthorBooks.Add(updatedAuthorBook);
                    // write changes to database
                    db.SaveChanges();
                }
                
            }
        }

        //Delete a Author Book Reference given their BookId
        public void Delete(int bId)
        {
            using (var db = new LibraryManagementContext())
            {
                var delABRef = db.AuthorBooks.Where(b => b.BookId == bId).FirstOrDefault();
                db.AuthorBooks.RemoveRange(delABRef);
                // write changes to database
                db.SaveChanges();
            }
        }

        //Select and retrieve all the author books  as a list
        public List<AuthorBook> RetrieveAll()
        {
            using (var db = new LibraryManagementContext())
            {
                return db.AuthorBooks.ToList();
            }
        }

    }
}
