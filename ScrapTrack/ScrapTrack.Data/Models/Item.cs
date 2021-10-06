using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapTrack.Data.Models
{
    public class Item
    {
        public int ID { get; set; }
        [Required, Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Required, Display(Name = "Weight (oz)")]
        public double ItemWeight { get; set; }
        [Required, Display(Name = "Type")]
        public ItemCategoryType ItemType { get; set; }

    }
}
