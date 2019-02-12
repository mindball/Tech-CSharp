using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SoftUniParking
{
    static void Main()
    {
        int input;
        int.TryParse(Console.ReadLine(), out input);
        Dictionary<string, Customer> registeredCustomers = new Dictionary<string, Customer>();
        string[] splitInput;

        while (input > 0)
        {
            splitInput = Console.ReadLine().Split(new char[] { ' ' });
            
            if(splitInput[0].Equals("register"))
            {
                if(registeredCustomers.ContainsKey(splitInput[1]))
                {
                    Console.WriteLine($"ERROR: already registered with plate number {registeredCustomers[splitInput[1]].IdOfCar}");
                }
                else
                {
                    registeredCustomers.Add(splitInput[1], new Customer(splitInput[1], splitInput[2]));
                    Console.WriteLine($"{splitInput[1]} registered {splitInput[2]} successfully");
                }
            }
            else if(splitInput[0].Equals("unregister"))
            {
                if (registeredCustomers.ContainsKey(splitInput[1]))
                {
                    Console.WriteLine($"{splitInput[1]} unregistered successfully");
                    registeredCustomers.Remove(splitInput[1]);
                }
                else
                    Console.WriteLine($"ERROR: user {splitInput[1]} not found");
            }
            input--;
        }

        foreach (var item in registeredCustomers)
        {
            Console.WriteLine($"{item.Value.Name} => {item.Value.IdOfCar}");
        }
    }
}

class Customer
{
    public Customer(string name, string idOfCar)
    {
        this.Name = name;
        this.IdOfCar = idOfCar;
    }

    public string Name { get; set; }

    public string IdOfCar { get; set; }
}

