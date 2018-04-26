using PROburgEvents.Data;
using PROburgEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace PROburgEvents.Controllers
{
    public class EventsController : ApiController
    {
        public IEnumerable<Event> GetAllEvents()
        {

            //use ViewModel
            var db = new DataContext();
            var query = db.Events
                .Include(i => i.Attendees);
            return query.ToList();
        }
    }
}
