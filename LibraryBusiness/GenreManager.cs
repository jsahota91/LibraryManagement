using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData;

namespace LibraryBusiness
{
    public class GenreManager
    {
        public Genre selectedGenre { get; set; }

        //Creating a genre method
        public bool Create(string genreName)
        {
            var newGenre = new Genre() {GenreName = genreName };
            using (var db = new LibraryManagementContext())
            {
                bool exists = db.Genres.Any(x => x.GenreName == genreName);
                if (exists == false)
                {
                    // record doesn't exist, add the record
                    db.Genres.Add(newGenre);
                    db.SaveChanges(); 
                    return true;
                }
                return false;
            } 
        }

        //Updating a genre
        public void Update(string oldGenre, string genreName)
        {
            using (var db = new LibraryManagementContext())
            {
                selectedGenre = db.Genres.Where(g => g.GenreName == oldGenre).FirstOrDefault();
                selectedGenre.GenreName = genreName;

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

        //Select and retrieve all the genres as a listview
        //public List<Genre> RetrieveAll()
        //{
        //    List<Genre> displayG = new List<Genre>();
        //    using (var db = new LibraryManagementContext())
        //    {
        //        var getGenres =
        //            from a in db.Genres
        //            select a;
        //        foreach (var item in getGenres)
        //        {
        //            displayG.Add(item);
        //        }
        //        return displayG;
        //    }
        //}
        //Select and retrieve all the genres as a LISTBOX
        public List<string> GetAll()
        {
            using (var db = new LibraryManagementContext())
            {
                var gGetAllQuery = db.Genres.ToList();
                List<string> genreList = new List<string>();
                foreach (var item in gGetAllQuery)
                {
                    genreList.Add($"{item.GenreId} {item.GenreName}");
                }
                return genreList;
            }
        }

        public void SetSelectedGenre(string selectedItem)
        {
            using (var db = new LibraryManagementContext())
            {
                selectedGenre = db.Genres.Where(b => b.GenreId + " " + b.GenreName == selectedItem).FirstOrDefault();
            }
        }

    }
}
