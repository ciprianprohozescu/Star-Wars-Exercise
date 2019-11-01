using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess;
using PersonDB = ModelsDB.Person;
using PersonLogic = ModelsLogic.Person;

namespace ControllersLogic
{
    public class PersonController
    {
        public List<PersonLogic> GetAll()
        {
            var personsAccess = new PersonsAccess();
            var peopleDB = personsAccess.GetAllPersons();

            var peopleLogic = new List<PersonLogic>();
            peopleDB.ForEach(p => peopleLogic.Add(DBToLogic(p)));

            return peopleLogic;
        }

        public void Add(PersonLogic personLogic)
        {
            var personsAccess = new PersonsAccess();
            var personDB = personsAccess.FindPersonByName(personLogic.Name);

            if (personDB == null)
            {
                personDB = LogicToDB(personLogic);
                personsAccess.AddPerson(personDB);
            }
        }

        public void AddAllFromAPI()
        {
            var personAPIController = new PersonAPIController();

            var people = personAPIController.Get();
            people.ForEach(person => Add(person));
        }

        private PersonLogic DBToLogic(PersonDB personDB)
        {
            var personLogic = new PersonLogic();

            personLogic.Name = personDB.Name;
            personLogic.Height = personDB.Height;
            personLogic.Mass = personDB.Mass;
            personLogic.HairColor = personDB.HairColor;
            personLogic.SkinColor = personDB.SkinColor;
            personLogic.EyeColor = personDB.EyeColor;
            personLogic.BirthYear = personDB.BirthYear;
            personLogic.Gender = personDB.Gender;
            personLogic.Homeworld = personDB.Homeworld;

            return personLogic;
        }

        private PersonDB LogicToDB(PersonLogic personLogic)
        {
            var personDB = new PersonDB();

            personDB.Name = personLogic.Name;
            personDB.Height = personLogic.Height;
            personDB.Mass = personLogic.Mass;
            personDB.HairColor = personLogic.HairColor;
            personDB.SkinColor = personLogic.SkinColor;
            personDB.EyeColor = personLogic.EyeColor;
            personDB.BirthYear = personLogic.BirthYear;
            personDB.Gender = personLogic.Gender;
            personDB.Homeworld = personLogic.Homeworld;

            return personDB;
        }
    }
}
