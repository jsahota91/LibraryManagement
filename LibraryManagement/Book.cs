using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryData
{
    public partial class Book
    {
        public Book()
        {
            AuthorBooks = new HashSet<AuthorBook>();
            BookGenres = new HashSet<BookGenre>();
            Locations = new HashSet<Location>();
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public int YearPublished { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
