using System;
using System.Collections.Generic;
using System.Linq;
using LibraryData;

namespace LibraryBusiness
{
    public class Genre
    {
        public Genre selectedGenre { get; set; }

        //Creating a genre method
        public void Create(int genreId, string genreName)
        {
            var newGenre = new Genre() { GenreId = genreId, GenreName = genreName };
            using (var db = new LibraryManagementContext())
            {
                db.Genres.Add(newGenre);
                db.SaveChanges();
            }
        }

        //Updating a genre
        public void Update(int genreId, string genreName)
        {
            using (var db = new LibraryManagementContext())
            {
                selectedGenre = db.Genres.Where(g => g.GenreId == genreId).FirstOrDefault();
                selectedGenre.Title = title;

                // write changes to database
                db.SaveChanges();
            }
        }

        //Delete a genre given their Id
        public void Delete(int genreId)
        {
            using (var db = new LibraryManagementContext())
            {
                var delGenre = db.Genres.Where(g => g.GenreId == genreId).FirstOrDefault();
                db.Genres.RemoveRange(delGenre);
                // write changes to database
                db.SaveChanges();
            }
        }

        //Select and retrieve all the genres as a list
        public List<Genre> RetrieveAll()
        {
            using (var db = new LibraryManagementContext())
            {
                return db.Genres.ToList();
            }
        }

        //public void SetSelectedBook(object selectedItem)
        //{
        //    SelectedBook = (Book)selectedItem;
        //}
    }
}
