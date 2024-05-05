using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBussiness.Repository
{
    public interface IItemRepository
    {
        IEnumerable<dynamic> GetAllItems();
        dynamic GetItemById(int id);
        void AddItem(dynamic item);
        void UpdateItem(dynamic item);
        void DeleteItem(int id);
    }

}
