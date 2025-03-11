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


public class Pizza
{
	public string Name { get; set; }
	public string Category { get; set;}
	public double Price { get; set; } 
	public int Quantity { get; set; }
    public string Size { get; set; }
}


public class Standard: Pizza
{
    public string ExpirationDate { get; set; }
    public string Ingredients { get; set; }
}

public class Custom : Pizza
{
    public string Clientname { get; set; }
    public string ExpirationDate { get; set; }
    public string Ingredients { get; set; }
}
