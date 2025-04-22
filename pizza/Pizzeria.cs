using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pizza
{
    internal class Pizzeria
    {
        List<Pizza> pizzas = new();

        public void AddPizza()
        {
            var newItem = new Pizza();


            Console.Write("Enter pizza name: ");
            newItem.Name = Console.ReadLine();
            Console.Write("Enter pizza category: ");
            newItem.Category = Console.ReadLine();
            Console.Write("Enter pizza price: ");
            newItem.Price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter pizza quantity: ");
            newItem.Quantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter pizza manufacture: ");
            newItem.Size = Console.ReadLine();

            pizzas.Add(newItem);
        }
        public void RemovePizza()
        {
            string jsonToSave = JsonSerializer.Serialize(pizzas);
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/pizza_db.json", jsonToSave);

        }
        public void LoadPizza()
        {
            string jsonToLoad = File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/pizza_db.json");
            pizzas = JsonSerializer.Deserialize<List<Pizza>>(jsonToLoad);
        }
        public void SavePiza()
        {
            foreach (var item in pizzas)
            {
                Console.WriteLine("------- Pizza ---------");
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Category: {item.Category}");
                Console.WriteLine($"Price: {item.Price}");
                Console.WriteLine($"Quantity: {item.Quantity}");
                Console.WriteLine($"Size: {item.Size}");
            }
        }

        public void Show()
        {
            for (int i = 0; i < pizzas.Count; ++i)
                Console.WriteLine($"[{i}] Service: " + pizzas[i].Name);
        }

        public void Find()
        {
            Console.WriteLine("Enter number to delate:");
            int numToDelete = Convert.ToInt32(Console.ReadLine());

            if (numToDelete < 0 || numToDelete >= pizzas.Count)
            {
                Console.WriteLine("Number out of range!");
                return;
            }
            pizzas.RemoveAt(numToDelete);
            Console.WriteLine("Service deleted successfully!");
        }
    }
}
