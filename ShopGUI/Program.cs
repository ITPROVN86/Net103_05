using ShopBussiness.DAO;
using ShopLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Manage Items");
                Console.WriteLine("2. Manage Categories");
                Console.WriteLine("3. Manage Suppliers");
                Console.WriteLine("4. Exit");
                Console.Write("Input number to choice: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        ManageItems();
                        break;
                    case "2":
                        //ManageCategories();
                        break;
                    case "3":
                        //ManageSuppliers();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }

        }

        static void ManageItems()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\nItem Management:");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Update Item");
                Console.WriteLine("3. Delete Item");
                Console.WriteLine("4. List All Items");
                Console.WriteLine("5. Return to Main Menu");
                Console.Write("Input number to choice: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        AddItem();
                        break;
                    case "2":
                        UpdateItem();
                        break;
                    case "3":
                        DeleteItem();
                        break;
                    case "4":
                        ListAllItems();
                        break;
                    case "5":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }

        static void AddItem()
        {
            Console.Write("Enter item name: ");
            string name = Console.ReadLine();
            Console.Write("Enter category ID: ");
            int categoryId = int.Parse(Console.ReadLine());
            Console.Write("Enter supplier ID: ");
            int supplierId = int.Parse(Console.ReadLine());

            Item newItem = new Item()
            {
                Name = name,
                CategoryId = categoryId,
                SupplierId = supplierId
            };

            ItemDao.Instance.AddItem(newItem);
            Console.WriteLine("Item added successfully!");
        }

        static void ListAllItems()
        {
            var items = ItemDao.Instance.GetAllItems();
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.ItemId}, Name: {item.Name}, Category ID: {item.CategoryId}, Supplier ID: {item.SupplierId}");
            }
        }
        static void UpdateItem()
        {
            Console.Write("Enter the ID of the item to update: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter the new item name: ");
            string newName = Console.ReadLine();
            Console.Write("Enter the new category ID: ");
            int newCategoryId = int.Parse(Console.ReadLine());
            Console.Write("Enter the new supplier ID: ");
            int newSupplierId = int.Parse(Console.ReadLine());
            ItemDao.Instance.UpdateItem(new Item { ItemId = id, Name = newName, CategoryId = newCategoryId, SupplierId = newSupplierId });
            Console.WriteLine("Item updated successfully!");
        }

        static void DeleteItem()
        {
            Console.Write("Enter the ID of the item to delete: ");
            int id = int.Parse(Console.ReadLine());

            // Assuming that ItemDao has a method named DeleteItem that takes an item ID
            ItemDao.Instance.DeleteItem(id);
            Console.WriteLine("Item deleted successfully!");
        }

    }
}
