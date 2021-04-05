using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryData
{
    public partial class Location
    {
        public int LocationId { get; set; }
        public string AisleName { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
