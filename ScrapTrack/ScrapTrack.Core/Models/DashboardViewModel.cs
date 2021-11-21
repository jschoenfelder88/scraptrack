using Microsoft.AspNetCore.Mvc.Rendering;
using ScrapTrack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrapTrack.Core.Models
{
    public class DashboardViewModel
    {
        public List<Transaction> TransactionList { get; set; }
        public List<Volunteer> VolunteerList { get; set; }
        public List<Item> ItemList { get; set; }
        public Volunteer TempVolunteer { get; set; }
        public Item TempItem { get; set; }
        public SelectList CategoryId { get; set; }
    }
}
