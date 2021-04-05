using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData;

namespace LibraryBusiness
{
    public class BookManager
    {
        public Book selectedBook { get; set; }
        public List<string> displayG = new List<string>();
        public List<string> displayA = new List<string>();
        public List<string> displayNewG = new List<string>();
        public List<string> displayNewA = new List<string>();
        public List<string> displayL = new List<string>();
        //Creating a book method
        public bool Create(string title, int yearPublished)
        {
            var newBook = new Book() {Title = title, YearPublished = yearPublished };
            using (var db = new LibraryManagementContext())
            {
                bool exists = db.Books.Any(x => x.Title == title);
                if(exists == false)
                {
                    db.Books.Add(newBook);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        //public void Create(string title, int yearPublished)
        //{
        //    var newBook = new Book() { Title = title, YearPublished = yearPublished };
        //    using (var db = new LibraryManagementContext())
        //    {
        //        db.Books.Add(newBook);
        //        db.SaveChanges();
        //    }
        //}

        //Updating a book 
        public void Update(string oldTitle, string title, int yearPublished)
        {
            using (var db = new LibraryManagementContext())
            {
                selectedBook = db.Books.Where(b => b.Title == oldTitle).FirstOrDefault();
                selectedBook.Title = title;
                selectedBook.YearPublished = yearPublished;
                // write changes to database
                db.SaveChanges();
            }
        }

        //Delete a book given their Id
        public void Delete(int bookId)
        {
            using (var db = new LibraryManagementContext())
            {
                var delBook = db.Books.Where(b => b.BookId == bookId).FirstOrDefault();
                db.Books.RemoveRange(delBook);
                // write changes to database
                db.SaveChanges();
            }
        }

        //Select and retrieve all the books as a list
        public List<string> RetrieveAll()
        {
            using (var db = new LibraryManagementContext())
            {
                var bookTitleQuery = db.Books.ToList();
                List<string> bookTitleList = new List<string>();
                foreach(var item in bookTitleQuery)
                {
                    bookTitleList.Add($"{item.Title} {item.YearPublished}");
                }
                return bookTitleList;
            }
        }

         
        public List<Book> Get()
        {
            List<Book> displayB = new List<Book>();
            using (var db = new LibraryManagementContext())
            {
                var bookquery =
                    from b in db.Books
                    select b;
                foreach (var item in bookquery)
                {
                    displayB.Add(item);
                }
            }
            return displayB;
        }

        //Select and retrieve all the genres as a LISTBOX
        public List<string> GetAll()
        {
            using (var db = new LibraryManagementContext())
            {
                var bGetAllQuery = db.Books.ToList();
                List<string> bookList = new List<string>();
                foreach (var item in bGetAllQuery)
                {
                    bookList.Add($"{item.BookId} {item.Title} {item.YearPublished}");
                }
                return bookList;
            }
        }

        public void SetBookRecord(string selectedItem)
        {
            using (var db = new LibraryManagementContext())
            {
                selectedBook = db.Books.Where(b => b.BookId + " " + b.Title + " " + b.YearPublished == selectedItem).FirstOrDefault();
            }
        }
        public void SetSelectedBook(string selectedItem)
        {
            displayG.Clear();
            displayA.Clear();
            using (var db= new LibraryManagementContext())
            {
                selectedBook = db.Books.Where(b => b.Title + " " + b.YearPublished == selectedItem).FirstOrDefault();
                var displayGQuery =
                    from b in db.Books
                    join bg in db.BookGenres on b.BookId equals bg.BookId
                    join g in db.Genres on bg.GenreId equals g.GenreId
                    where bg.BookId == selectedBook.BookId
                    select new { GenreName = g.GenreName};

                foreach(var item in displayGQuery)
                {
                    displayG.Add(item.GenreName);
                }

                var displayNewGQuery = db.Genres;
                var displayNewAQuery = db.Authors;
                foreach (var item in displayNewAQuery)
                {
                    displayNewA.Add(item.FirstName + " " + item.LastName);
                }
                foreach (var item in displayNewGQuery)
                {
                    displayNewG.Add(item.GenreName);
                }

                var displayAQuery =
                    from b in db.Books
                    join ab in db.AuthorBooks on b.BookId equals ab.BookId
                    join a in db.Authors on ab.AuthorId equals a.AuthorId
                    where ab.BookId == selectedBook.BookId
                    select new { FirstName = a.FirstName, LastName = a.LastName };

                foreach (var item in displayAQuery)
                {
                    displayA.Add(item.FirstName + " " + item.LastName);
                }

                var displayLQuery =
                    from b in db.Books
                    join l in db.Locations on b.BookId equals l.BookId
                    where l.BookId == selectedBook.BookId
                    select new { AisleName = l.AisleName };

                foreach (var item in displayLQuery)
                {
                    displayL.Add(item.AisleName);
                }
            }
            
        }
    }
}
