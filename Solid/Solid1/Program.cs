using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid1
{
    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Order
    {
        private readonly List<Item> itemList = new List<Item>();

        public IReadOnlyList<Item> GetItems() => itemList;
        public int GetItemCount() => itemList.Count;
        public double CalculateTotalSum() => itemList.Sum(i => i.Price);

        public void AddItem(Item item) => itemList.Add(item);
        public void DeleteItem(Item item) => itemList.Remove(item);
    }

    class OrderPrinter
    {
        public void PrintOrder(Order order) { /* ... */ }
        public void ShowOrder(Order order)
        {
            foreach (var item in order.GetItems())
                Console.WriteLine($"{item.Name} - {item.Price} hrn");

            Console.WriteLine($"Sum: {order.CalculateTotalSum()} hrn");
        }
    }

    class OrderRepository
    {
        public Order Load(int id) { /* ... */ return new Order(); }
        public void Save(Order order) { /* ... */ }
        public void Update(Order order) { /* ... */ }
        public void Delete(Order order) { /* ... */ }
    }

    class Program
    {
        static void Main()
        {
            var order = new Order();
            order.AddItem(new Item { Name = "Book", Price = 250 });
            order.AddItem(new Item { Name = "Pen", Price = 20 });

            var printer = new OrderPrinter();
            printer.ShowOrder(order);

            var repository = new OrderRepository();
            repository.Save(order);
            Console.ReadKey();
        }
    }
}
