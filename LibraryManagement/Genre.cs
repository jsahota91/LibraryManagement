using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryData
{
    public partial class Genre
    {
        public Genre()
        {
            BookGenres = new HashSet<BookGenre>();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<BookGenre> BookGenres { get; set; }
    }
}
