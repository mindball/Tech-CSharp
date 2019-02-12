using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Orders
{
    static void Main()
    {
        string[] splitInput;
        Dictionary<string, Products> orders = new Dictionary<string, Products>();

        while (true)
        {
            splitInput = Console.ReadLine().Split(new char[] { ' ' });
            if (splitInput[0].Equals("buy"))
                break;

            if(orders.ContainsKey(splitInput[0]))
            {
                orders[splitInput[0]].Quantity += int.Parse(splitInput[2]);
                if (orders[splitInput[0]].Price != decimal.Parse(splitInput[1]))
                    orders[splitInput[0]].Price = decimal.Parse(splitInput[1]);
            }
            else
                orders.Add(splitInput[0], new Products(splitInput[0],
                            decimal.Parse(splitInput[1]), int.Parse(splitInput[2]))); 
        }

        foreach (var item in orders)
        {
            Console.WriteLine($"{item.Key} -> {item.Value.Price * item.Value.Quantity:f2}");
        } 
    }
}

class Products
{
    public Products(string name, decimal price, int quantity)
    {
        this.Name = name;
        this.Price = price;
        this.Quantity = quantity;
    }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}

