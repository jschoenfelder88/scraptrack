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
        public Category Category { get; set; }
        public int CategoryFK { get; set; }
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.99)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Weight { get; set; }
        [Required]
        [HiddenInput(DisplayValue = false)]
        public bool TempItem { get; set; } = false;
        [ForeignKey("ItemFK")]
        public ICollection<Transaction> Transactions { get; set; }
    }
}
