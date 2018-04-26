namespace PROburgEvents.Migrations
{
    using PROburgEvents.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PROburgEvents.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PROburgEvents.Data.DataContext db)
        {
            var cities = new List<City>
            {
                new City {Name = "St. Petersburg"},
                new City {Name = "Tampa"},
                new City {Name = "Clearwater"}
            };

            cities.ForEach(city =>
            {
                db.Cities.AddOrUpdate(a => a.Name, city);
            });

            var people = new List<Attendee>
            {
                new Attendee {Email= "ethyl@test.com"},
                new Attendee {Email= "harry@test.com"},
                new Attendee {Email= "dolphins4eva@test.com"},

            };

            var events = new List<Event>
            {
                new Event {Title ="intro to Knitting", Tagline="Knit it up!", Date = new DateTime(2018, 8, 9), CityID = 1, AgeLimit=65 },
                new Event {Title ="Skateball Tournament", Tagline="Watch Solarbabies, you'll get it!", Date = new DateTime(2018, 5, 14), CityID = 2, AgeLimit=18 },
                new Event {Title ="Urban Farming 101", Tagline="Food not lawns", Date = new DateTime(2018, 4, 9), CityID = 1 },
                new Event {Title ="Winter's Bday Bash", Tagline="Dolphins are cool", Date = new DateTime(2018, 4, 28), CityID = 3 },
            };

            events.ForEach(item =>
            {
                foreach(var person in people)
                {
                    item.Attendees.Add(person);
                }
                db.Events.AddOrUpdate(a => a.Title, item);
            });

            db.SaveChanges();
        }
    }
}
