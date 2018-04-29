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
    public class AddAttendeeController : ApiController
    {
        [HttpPut]
        [Route("api/events/{eventID}/addattendee")]
        public string AddAttendee([FromUri] int eventID, [FromBody] AddEmailViewModel userEmail)
        {
            var db = new DataContext();
            var message = "";

            //find the event the attendee wants to go to
            var thisEvent = db.Events.Include(i => i.Attendees).First(e => e.ID == eventID);

            //add the user email to the the list of attendees on this event
            if (!String.IsNullOrEmpty(userEmail.Email))
            {
                var newAttendee = new Attendee
                {
                    Email = userEmail.Email
                };
                thisEvent.Attendees.Add(newAttendee);
                db.SaveChanges();
                message = $"You have registered for {thisEvent.Title} taking place on {thisEvent.Date.ToString("MM/dd/yyyy")}.";
            } else
            {
                message = $"Cannot register {userEmail} for {thisEvent}. Please try again.";
            }
            //return resp message
            return message;
        }
    }
}
