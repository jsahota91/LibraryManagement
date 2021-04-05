using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryData
{
    public partial class AuthorBook
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
