using System;
using System.Collections.Generic;
using System.Linq;


class VehicleCataloge20
{
    static void Main(string[] args)
    {
        Dictionary<string, Vehicle> test = new Dictionary<string, Vehicle>();

        string input;
        string[] arr;

        while (true)
        {
            input = Console.ReadLine();
            if (input.Equals("End"))
                break;

            arr = input.Split(' ');
            if (arr[0].Equals("car"))
            {
                //I  did not remove the model from a constructor not to break the integrity of the class. 
                test.Add(arr[1], new Car(arr[1], arr[2], int.Parse(arr[3])));
            }
            else
            {
                test.Add(arr[1], new Truck(arr[1], arr[2], int.Parse(arr[3])));
            }
        }

        string input2;
        while (true)
        {
            input2 = Console.ReadLine();
            if (input2.Equals("Close the Catalogue"))
            {
                Console.WriteLine($"Cars have average horsepower of: {Car.GetHorsePower:F2}.");
                Console.WriteLine($"Trucks have average horsepower of: {Truck.GetHorsePower:F2}.");
                break;
            }            
            else if (test.ContainsKey(input2) && test[input2] is Car)
            {
                Car carObj = (Car)test[input2];

                PrintVehicleDetails(typeof(Car).ToString(), carObj.Model,
                                    carObj.Color, carObj.HorsePower);
            }          
            else if (test.ContainsKey(input2) && test[input2] is Truck)
            {
                Truck truckObj = (Truck)test[input2];
                PrintVehicleDetails(typeof(Truck).ToString(), truckObj.Model,
                                    truckObj.Color, truckObj.HorsePower);
            }
        }
    }

    public static void PrintVehicleDetails(string type, string model, string color, int hp)
    {
        Console.WriteLine($"Type: {type}");
        Console.WriteLine($"Model: {model}");
        Console.WriteLine($"Color: {color}");
        Console.WriteLine($"Horsepower: {hp}");
    }
}

class Vehicle
{
    public Vehicle(string color, int hp)
    {
        this.Color = color;
        this.HorsePower = hp;
    }
    public string Color { get; set; }
    public int HorsePower { get; set; }
}

class Car : Vehicle
{
    private static int averageHorsePower = 0;
    private static int countOfCars = 0;

    public Car(string model, string color, int hp) : base (color, hp)
    {
        this.Model = model;
        averageHorsePower += hp;
        countOfCars++;
    }

    public string Model { get; set; }

    public static double GetHorsePower
    {
        get
        {
            if (countOfCars == 0)
                return 0;
            else
                return (double)averageHorsePower / (double)countOfCars;
        }
    }
}

class Truck : Vehicle
{
    private static int averageHorsePower = 0;
    private static int countOfTruck = 0;
    public Truck(string model, string color, int hp) : base(color, hp)
    {
        this.Model = model;
        averageHorsePower += hp;
        countOfTruck++;
    }

    public string Model { get; set; }

    public static double GetHorsePower
    { get
        {
            if (countOfTruck == 0)
                return 0;
            else
                return (double)averageHorsePower / (double)countOfTruck;
        }
    }
}

