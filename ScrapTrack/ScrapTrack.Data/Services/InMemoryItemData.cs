using ScrapTrack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapTrack.Data.Services
{
    public class InMemoryItemData : IItemData
    {
        List<Item> items;

        public InMemoryItemData()
        {
            items = new List<Item>()
            {
                new Item {ID = 1, ItemName = "T-Shirt", ItemWeight = 5.5, ItemType = ItemCategoryType.Clothing },
                new Item {ID = 2, ItemName = "Boots", ItemWeight = 55, ItemType = ItemCategoryType.Survival },
                new Item {ID = 3, ItemName = "Tote Bag", ItemWeight = 24, ItemType = ItemCategoryType.Survival },
                new Item {ID = 4, ItemName = "Hoodie", ItemWeight = 20, ItemType = ItemCategoryType.Clothing },
                new Item {ID = 5, ItemName = "Socks", ItemWeight = 1.25, ItemType = ItemCategoryType.Clothing }
            };
        }
        public IEnumerable<Item> GetAll()
        {
            return items.OrderBy(i => i.ItemName);
        }

        public Item Get(int id)
        {
            return items.FirstOrDefault(i => i.ID == id);
        }

        public void Add(Item item)
        {
            items.Add(item);
            item.ID = items.Max(i => i.ID) + 1;
        }

        public void Update(Item item)
        {
            var existing = Get(item.ID);
            if (existing != null)
            {
                existing.ItemName = item.ItemName;
                existing.ItemWeight = item.ItemWeight;
                existing.ItemType = item.ItemType;
            }
        }
    }
}
