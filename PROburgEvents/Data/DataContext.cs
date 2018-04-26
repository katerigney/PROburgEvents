using PROburgEvents.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PROburgEvents.Data
{
    public class DataContext : DbContext
    {
        public DataContext(): base("name=DefaultConnection")
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Event> Events { get; set; }


    }
}