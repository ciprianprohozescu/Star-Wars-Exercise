using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelsDB;

namespace DataAccess
{
    public class FilmsAccess
    {
        StarWarsEntities db = new StarWarsEntities();
        public List<Film> GetAllFilms()
        {
            var filmsQuery = from film in db.Films
                        orderby film.ID descending
                        select film;
            return filmsQuery.ToList<Film>();
        }
        public Film FindFilmByTitle(string title)
        {
            var film = db.Films
                .Where(f => f.Title == title)
                .FirstOrDefault<Film>();

            return film;
        }

        public void AddFilm(Film film)
        {
            db.Films.Add(film);
            db.SaveChanges();
        }
    }
}
