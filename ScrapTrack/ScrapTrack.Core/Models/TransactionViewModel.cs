using ScrapTrack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrapTrack.Core.Models
{
    public class TransactionViewModel
    {
        public Volunteer volunteer { get; set; }
        public IList<Item> items { get; set; }
    }
}
