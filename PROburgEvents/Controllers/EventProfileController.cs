using PROburgEvents.Data;
using PROburgEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PROburgEvents.Controllers
{
    public class EventProfileController : ApiController
    {
        [HttpGet]
        public Event GetOneEvent(int eventID)
        {
            var db = new DataContext();
            var query = db.Events.SingleOrDefault(w => w.ID == eventID);

            return query;
        }
    }
}
