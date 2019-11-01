using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PersonMVC = ClientMVC.Models.Person;
using PersonLogic = ModelsLogic.Person;
using RestSharp;
using Newtonsoft.Json;

namespace ClientMVC.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            var client = new RestClient(ConfigurationManager.AppSettings.Get("APIURL"));
            client.Execute(new RestRequest("people", Method.POST));

            ViewBag.Title = "Characters";

            var peopleMVC = new List<PersonMVC>();

            var content = client.Execute(new RestRequest("people", Method.GET)).Content;

            ViewBag.Content = content;

            List<PersonLogic> peopleLogic = JsonConvert.DeserializeObject<List<PersonLogic>>(content);

            foreach (var personLogic in peopleLogic)
            {
                var personMVC = LogicToMVC(personLogic);
                peopleMVC.Add(personMVC);
            }

            return View(peopleMVC);
        }

        private PersonMVC LogicToMVC(PersonLogic personLogic)
        {
            var personMVC = new PersonMVC();

            personMVC.Name = personLogic.Name;
            personMVC.Height = personLogic.Height;
            personMVC.Mass = personLogic.Mass;
            personMVC.HairColor = personLogic.HairColor;
            personMVC.SkinColor = personLogic.SkinColor;
            personMVC.EyeColor = personLogic.EyeColor;
            personMVC.BirthYear = personLogic.BirthYear;
            personMVC.Gender = personLogic.Gender;

            return personMVC;
        }
    }
}