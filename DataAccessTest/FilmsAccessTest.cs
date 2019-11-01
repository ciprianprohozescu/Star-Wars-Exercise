using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using ModelsDB;
using System.Linq;

namespace DataAccessTest
{
    [TestClass]
    public class FilmsAccessTest
    {
        static FilmsAccess filmsAccess;
        static StarWarsEntities db;

        [ClassInitialize]
        public static void setupFilms(TestContext context)
        {
            filmsAccess = new FilmsAccess();
            db = new StarWarsEntities();

            var film1 = new Film();
            film1.Title = "Test Film 1";

            var film2 = new Film();
            film2.Title = "Test Film 2";

            db.Films.Add(film1);
            db.Films.Add(film2);
            db.SaveChanges();
        }

        [TestMethod]
        public void GetAllFilmsTest()
        {
            var films = filmsAccess.GetAllFilms();
            var dbFilms = db.Films.ToList<Film>();

            Console.WriteLine(films[0].Title);
            Console.WriteLine(films[0].ReleaseDate);

            Assert.AreEqual(null, films[0].ReleaseDate);
        }

        [ClassCleanup]
        public static void deleteFilms()
        {
            db = new StarWarsEntities();
            //db.Films.RemoveRange(db.Films.ToList<Film>());
            //db.SaveChanges();
        }
    }
}
