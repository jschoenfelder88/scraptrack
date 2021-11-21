using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScrapTrack.Data.Models
{
    public class Transaction_Details
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
    }
}
