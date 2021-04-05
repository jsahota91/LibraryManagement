using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData;

namespace LibraryBusiness
{
    public class BookGenreManager
    {
        public BookGenre selectedBGRef { get; set; }
        

        //Creating a Book Genre Reference method
        public void Create(int bId, int gId)
        {
            var newBGRef = new BookGenre() {BookId = bId, GenreId = gId};
            using (var db = new LibraryManagementContext())
            {
                db.BookGenres.Add(newBGRef);
                db.SaveChanges();
            }
        }

        //Updating a Book Genre Reference 
        public void Update(int bId, int gId, int newgId)
        {
            using (var db = new LibraryManagementContext())
            {
                selectedBGRef = db.BookGenres.Where(g => g.GenreId == gId &&  g.BookId == bId).FirstOrDefault();
                db.BookGenres.Remove(selectedBGRef);
                BookGenre updatedBookGenre = new BookGenre()
                {
                    BookId = bId,
                    GenreId = newgId
                };
                db.BookGenres.Add(updatedBookGenre);
                // write changes to database
                db.SaveChanges();
            }
        }

        //Delete a Book Genre Referencegiven their BookId
        public void Delete(int bgId)
        {
            using (var db = new LibraryManagementContext())
            {
                var delBGRef = db.BookGenres.Where(b => b.BookId == bgId).FirstOrDefault();
                db.BookGenres.RemoveRange(delBGRef);
                // write changes to database
                db.SaveChanges();
            }
        }

        //Select and retrieve all the book genres as a list
        public List<BookGenre> RetrieveAll()
        {
            using (var db = new LibraryManagementContext())
            {
                return db.BookGenres.ToList();
            }
        }

        //public void SetSelectedBook(object selectedItem)
        //{
        //    SelectedBook = (Book)selectedItem;
        //}
    }
}
