using ShopLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBussiness.DAO
{
    public class ItemDao : SingletonBase<ItemDao>
    {
        //private ShopContext _context = new ShopContext();
        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items.ToList().Select(item => new Item(){
                ItemId = item.ItemId,
                Name= item.Name,
                CategoryId = item.CategoryId,
                SupplierId = item.SupplierId
            });
        }
        public Item GetItemById(int id)
        {
            var item = _context.Items.Find(id);
            if (item == null) return null;

            return new Item()
            {
                ItemId = item.ItemId,
                Name = item.Name,
                CategoryId = item.CategoryId,
                SupplierId = item.SupplierId
            };
        }
        public void AddItem(dynamic item)
        {
            _context.Items.Add(new Item
            {
                Name = item.Name,
                CategoryId = item.CategoryId,
                SupplierId = item.SupplierId
            });
            _context.SaveChanges();
        }
        public void UpdateItem(dynamic item)
        {
            var existingItem = _context.Items.Find(item.ItemId);
            if (existingItem == null) return;

            existingItem.Name = item.Name;
            existingItem.CategoryId = item.CategoryId;
            existingItem.SupplierId = item.SupplierId;
            _context.SaveChanges();
        }
        public void DeleteItem(int id)
        {
            var item = _context.Items.Find(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }
    }

}
