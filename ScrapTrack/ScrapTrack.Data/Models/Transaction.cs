using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ScrapTrack.Data.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [ForeignKey("User_ID")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
