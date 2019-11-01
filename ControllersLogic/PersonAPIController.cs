using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelsLogic;
using Newtonsoft.Json;
using RestSharp;

namespace ControllersLogic
{
    public class PersonAPIController
    {
        public List<Person> Get()
        {
            var client = new RestClient("https://swapi.co/api/");
            var content = client.Execute(new RestRequest("people", Method.GET)).Content;

            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(content);

            List<Person> people = new List<Person>();
            foreach (var personAPI in rootObject.results)
            {
                people.Add(APIToLogic(personAPI));
            }
            return people;
        }

        private Person APIToLogic(Result personAPI)
        {
            var person = new Person();

            person.Name = personAPI.name;
            person.Height = personAPI.height;
            person.Mass = personAPI.mass;
            person.HairColor = personAPI.hair_color;
            person.SkinColor = personAPI.skin_color;
            person.EyeColor = personAPI.eye_color;
            person.BirthYear = personAPI.birth_year;
            person.Gender = personAPI.gender;
            person.Homeworld = personAPI.homeworld;

            return person;
        }
    }

    public class Result
    {
        public string name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }
    }

    public class RootObject
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }
    }
}
