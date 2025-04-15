/*------------------- Піцерія 
Створити ієрархію класів для подання інформації про  піцу. 
Піцу клієнт може замовляти 
	стандартну(яку пропонує піцерія),
	складену за смаком клієнта(клієн сам складає піцу) 
Створити програму для роботи піцерії
	Додавання(вилучення. редагування)  піци у(з)  базу
	Додавання(вилучення. редагування)  продуктів у(з)  базу
	Збереження бази піц у файлі
	Завантаження бази піц з файлу
	Перегляд  готових піц(складників, ціни)
	Пошук піц по складникам 
	Замовлення піци клієнтом(ами), враховуючи можливе складання піци клієнтом
	Розрахунок клієнта(друк чеку, прийом оплати)
загальний клас піца який ділеться на стандартну та кастомну
*/
using System.Text.Json;

Console.WriteLine("------Welcome in a pizzeria------"); 

Console.WriteLine("\tMENU:");
Console.WriteLine("\t1. Add new pizza");
Console.WriteLine("\t2. Save to file");
Console.WriteLine("\t3. Load from file");
Console.WriteLine("\t4. Show all piza");
Console.WriteLine("\t5. DeLete pizza");
Console.WriteLine("\t6. Sell pizza");
Console.WriteLine("\t7.Pizza order by customer(s)");
Console.WriteLine("\t8. Client calculation");


List<Pizza> pizzas = new();


while (true)
{
    Console.Write("Your choice: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
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
            break;
     
        case 2:
            string jsonToSave = JsonSerializer.Serialize(pizzas);
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/pizza_db.json", jsonToSave);
            break;
        case 3:
            string jsonToLoad = File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/products_db.json");
            pizzas = JsonSerializer.Deserialize<List<Pizza>>(jsonToLoad);
            break;
        case 4:
            foreach (var item in pizzas)
            {
                Console.WriteLine("------- Pizza ---------");
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Category: {item.Category}");
                Console.WriteLine($"Price: {item.Price}");
                Console.WriteLine($"Quantity: {item.Quantity}");
                Console.WriteLine($"Size: {item.Size}");
            }
                break;
        case 5:
            for (int i = 0; i < pizzas.Count; ++i)
                Console.WriteLine($"[{i}] Service: " + pizzas[i].Name);

            Console.WriteLine("Enter number to delate:");
            int numToDelete = Convert.ToInt32(Console.ReadLine());

            if (numToDelete < 0 || numToDelete >= pizzas.Count)
            {
                Console.WriteLine("Number out of range!");
                break;
            }
            pizzas.RemoveAt(numToDelete);
            Console.WriteLine("Service deleted successfully!");
            break;

    }
}
