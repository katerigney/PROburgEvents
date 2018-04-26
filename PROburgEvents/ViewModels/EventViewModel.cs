using PROburgEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROburgEvents.ViewModels
{
    public class EventViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string ZIP { get; set; }
        public int? AgeLimit { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string CityName { get; set; }

        public ICollection<Attendee> Attendees { get; set; } = new HashSet<Attendee>();
    }
}