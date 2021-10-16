using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ScrapTrack.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Description { get; set; }
        [ForeignKey("CategoryFK")]
        public ICollection<Item> Items { get; set; }
    }
}
