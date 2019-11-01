using ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PersonsAccess
    {
        StarWarsEntities db = new StarWarsEntities();
        public List<Person> GetAllPersons()
        {
            var filmsQuery = from person in db.Persons
                             orderby person.ID descending
                             select person;
            return filmsQuery.ToList<Person>();
        }

        public Person FindPersonByName(string name)
        {
            var person = db.Persons
                .Where(p => p.Name == name)
                .FirstOrDefault<Person>();

            return person;
        }

        public void AddPerson(Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
        }
    }
}
