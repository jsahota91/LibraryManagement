using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData;

namespace LibraryBusiness
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new LibraryManagementContext())
            {
                //delete
                //var Authors = db.AuthorBooks;
                //db.AuthorBooks.RemoveRange(Authors);
                //db.SaveChanges();

                //var GenreBooks = db.BooksGenres;
                //db.BookGenres.RemoveRange(GenreBooks);
                //db.SaveChanges();

                //var authors = db.Authors;
                //db.Authors.RemoveRange(authors);
                //db.SaveChanges();

                //var genres = db.Genres;
                //db.Genres.RemoveRange(genres);
                //db.SaveChanges();

                //var locations = db.Locations;
                //db.Locations.RemoveRange(locations);
                //db.SaveChanges();

                //var books = db.Books;
                //db.Books.RemoveRange(books);
                //db.SaveChanges();

                //var genres = new Genre[]
                //{
                //    new Genre{ GenreName = "Thriller" },
                //    new Genre{ GenreName = "Adventure" },
                //    new Genre{ GenreName = "Comedy" },
                //    new Genre{ GenreName = "Mystery" },
                //    new Genre{ GenreName = "Horror" },
                //    new Genre{ GenreName = "Sci-fi" },
                //    new Genre{ GenreName = "Biography" }
                //};

                //db.Genres.AddRange(genres);
                //db.SaveChanges();

                //var authors = new Author[]
                //{
                //    new Author{ FirstName = "Suzanne", LastName = "Collins" },
                //    new Author{ FirstName = "J.K", LastName = "Rowling" },
                //    new Author{ FirstName = "Philip", LastName = "Pullman" },
                //    new Author{ FirstName = "J.R.R", LastName = "Tolkien" },
                //    new Author{ FirstName = "Stephen", LastName = "King" },
                //    new Author{ FirstName = "Barack", LastName = "Obama" },
                //    new Author{ FirstName = "Jeff", LastName = "Kinney" }
                //};

                //db.Authors.AddRange(authors);
                //db.SaveChanges();

                //var books = new Book[]
                //{
                //    new Book{ Title = "Harry Potter and the Chamber of Secrets", YearPublished = 1998  },
                //    new Book{ Title = "Harry Potter and the Prisoner of Azkaban", YearPublished = 1999 },
                //    new Book{ Title = "The Lord Of the Rings", YearPublished = 1954 },
                //    new Book{ Title = "The Fall of The Gondolin", YearPublished = 2018},
                //    new Book{ Title = "The Promised Land", YearPublished = 2020},
                //    new Book{ Title = "The Diary of a Wimpy Kid", YearPublished = 2010 },
                //    new Book{ Title = "The Book of Dust", YearPublished = 2019 },
                //    new Book{ Title = "Demon Voices", YearPublished = 2019 },
                //    new Book{ Title = "Dream Catcher", YearPublished = 2001 }

                //};

                //db.Books.AddRange(books);
                //db.SaveChanges();

                //var bookGenres = new BookGenre[]
                //{
                //    new BookGenre() { GenreId = 2, BookId = 1 },
                //    new BookGenre() { GenreId = 4, BookId = 1 },
                //    new BookGenre() { GenreId = 5, BookId = 3 },
                //    new BookGenre() { GenreId = 1, BookId = 1 },
                //    new BookGenre() { GenreId = 2, BookId = 6 },
                //    new BookGenre() { GenreId = 3, BookId = 6 },
                //};
                //db.BookGenres.AddRange(bookGenres);
                //db.SaveChanges();

                //var authorBooks = new AuthorBook[]
                //{
                //    new AuthorBook {AuthorId = 2, BookId = 1},
                //    new AuthorBook {AuthorId = 2, BookId = 7},
                //    new AuthorBook {AuthorId = 2, BookId = 8},
                //    new AuthorBook {AuthorId = 3, BookId = 2},
                //    new AuthorBook {AuthorId = 4, BookId = 6}
                //};

                //db.AuthorBooks.AddRange(authorBooks);
                //db.SaveChanges();

                //var locations = new Location[]
                //{
                //    new Location{AisleName = "Co1", BookId = 1},
                //    new Location{AisleName = "Ro2", BookId = 2},
                //    new Location{AisleName = "Pu3", BookId = 3},
                //    new Location{AisleName = "Ki14", BookId = 4},
                //    new Location{AisleName = "Ob6", BookId = 5},
                //    new Location{AisleName = "To4", BookId = 6}
                //};

                //db.Locations.AddRange(locations);
                //db.SaveChanges();
            }

        }
    }
}
