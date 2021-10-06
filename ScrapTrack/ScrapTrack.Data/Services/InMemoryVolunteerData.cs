using ScrapTrack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapTrack.Data.Services
{
    public class InMemoryVolunteerData : IVolunteerData
    {
        List<Volunteer> volunteers;

        public InMemoryVolunteerData()
        {
            volunteers = new List<Volunteer>()
            {
                new Volunteer { ID = 1, FirstName = "Juan", LastName = "Aguilar"},
                new Volunteer { ID = 2, FirstName = "Ann", LastName = "Pearce"},
                new Volunteer { ID = 3, FirstName = "Sami", LastName = "Cordova"},
                new Volunteer { ID = 4, FirstName = "Graham", LastName = "Cartwright"},
                new Volunteer { ID = 5, FirstName = "Lauren", LastName = "Lowry"},
                new Volunteer { ID = 6, FirstName = "Keisha", LastName = "Mackie"}
            };
        }

        public IEnumerable<Volunteer> GetAll()
        {
            return volunteers.OrderBy(v => v.FirstName);
        }

        public Volunteer Get(int id)
        {
            return volunteers.FirstOrDefault(v => v.ID == id);
        }

        public void Add(Volunteer volunteer)
        {
            volunteers.Add(volunteer);
            volunteer.ID = volunteers.Max(r => r.ID) + 1;
        }

        public void Update(Volunteer volunteer)
        {
            var existing = Get(volunteer.ID);
            if (existing != null)
            {
                existing.FirstName = volunteer.FirstName;
                existing.LastName = volunteer.LastName;
            }
        }
    }
}
