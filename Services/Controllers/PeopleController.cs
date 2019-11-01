using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ModelsLogic;
using ControllersLogic;

namespace Services.Controllers
{
    public class PeopleController : ApiController
    {
        // GET api/people
        public List<Person> Get()
        {
            var personController = new PersonController();
            return personController.GetAll();
        }

        // POST api/people
        public void Post()
        {
            var personController = new PersonController();
            personController.AddAllFromAPI();
        }
    }
}
