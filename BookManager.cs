using System;
using System.Collections.Generic;
using System.Linq;
using LibraryData;

namespace LibraryBusiness
{
	public class BookManager
	{
		public Book selectedBook { get; set; }

        //Creating a book method
        public void Create(int bookId, string title, int yearPublished)
        {
            var newBook = new Book() { BookId = bookId, Title = title, YearPublished = yearPublished };
            using (var db = new LibraryManagementContext())
            {
                db.Books.Add(newBook);
                db.SaveChanges();
            }
        }

        //Updating a book 
        public void Update(int bookId, string title, int yearPublished)
        {
            using (var db = new LibraryManagementContext())
            {
                selectedBook = db.Books.Where(b => b.BookId == bookId).FirstOrDefault();
                selectedBook.Title = title;
                selectedBook.YearPublished = yearPublished;
                
                // write changes to database
                db.SaveChanges();
            }
        }

        //Delete a customer given their Id
        public void Delete(int bookId)
        {
            using (var db = new LibraryManagementContext())
            {
                var delBook = db.Customers.Where(b => b.BookId == bookId).FirstOrDefault();
                db.Books.RemoveRange(delBook);
                // write changes to database
                db.SaveChanges();
            }
        }

        //Select and retrieve all the books as a list
        public List<Book> RetrieveAll()
        {
            using (var db = new LibraryManagementContext())
            {
                return db.Books.ToList();
            }
        }

        //public void SetSelectedBook(object selectedItem)
        //{
        //    SelectedBook = (Book)selectedItem;
        //}
    }
}

