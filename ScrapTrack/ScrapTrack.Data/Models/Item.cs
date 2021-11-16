using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ScrapTrack.Data.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(140)]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Range(0, 99.9)]
        [Column(TypeName = "decimal(3, 1)")]
        [Display(Name = "Weight (lbs)")]
        [DisplayFormat(DataFormatString = "{0:0.#}")]
        public decimal Weight { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
    