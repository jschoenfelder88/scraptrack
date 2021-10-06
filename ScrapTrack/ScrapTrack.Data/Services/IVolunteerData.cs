using ScrapTrack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapTrack.Data.Services
{
    public interface IVolunteerData
    {
        IEnumerable<Volunteer> GetAll();
        Volunteer Get(int id);
        void Add(Volunteer volunteer);
        void Update(Volunteer volunteer);
    }
}
