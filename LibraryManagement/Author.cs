using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryData
{
    public partial class Author
    {
        public Author()
        {
            AuthorBooks = new HashSet<AuthorBook>();
        }

        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
    }
}
