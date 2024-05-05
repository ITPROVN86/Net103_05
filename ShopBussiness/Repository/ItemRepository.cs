using ShopBussiness.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBussiness.Repository
{
    public class ItemRepository : IItemRepository
    {

        public IEnumerable<dynamic> GetAllItems()
        {
            return ItemDao.Instance.GetAllItems();
        }

        public dynamic GetItemById(int id)
        {
            return ItemDao.Instance.GetItemById(id);
        }

        public void AddItem(dynamic item)
        {
            ItemDao.Instance.AddItem(item);
        }

        public void UpdateItem(dynamic item)
        {
            ItemDao.Instance.UpdateItem(item);
        }

        public void DeleteItem(int id)
        {
            ItemDao.Instance.DeleteItem(id);
        }
    }

}
