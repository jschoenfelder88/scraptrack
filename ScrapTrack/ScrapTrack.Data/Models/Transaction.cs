using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScrapTrack.Data.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeFK { get; set; }
        public Volunteer Volunteer { get; set; }
        public int VolunteerFK { get; set; }
        public Item Item { get; set; }
        public int ItemFK { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
