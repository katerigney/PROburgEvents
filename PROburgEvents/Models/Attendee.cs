using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROburgEvents.Models
{
    public class Attendee
    {
        public int ID { get; set; }
        [Required]
        public string Email { get; set; }

        public ICollection<Event> Events { get; set; } = new HashSet<Event>();
    }
}