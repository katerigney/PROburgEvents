using PROburgEvents.Data;
using PROburgEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using PROburgEvents.ViewModels;

namespace PROburgEvents.Controllers
{
    public class EventsController : ApiController
    {
        public IHttpActionResult Get(string title = null)
        {
            try
            {
                var db = new DataContext();
                var query = db.Events.Include(i => i.Attendees).Include(i => i.City);

                if (!String.IsNullOrEmpty(title))
                {
                    query = query.Where(w => w.Title.Contains(title));
                }

                var results = query.ToList();

                if (results.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(results);
                }

            }
            catch (ArgumentNullException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetOneEvent(int id)
        {
            using (var db = new DataContext())
            {
                var query = db.Events
                    .Include(i => i.Attendees)
                    .Include(i => i.City)
                    .SingleOrDefault(s => s.ID == id);
                if (query == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(query);
                }
            }
        }
    }
}
