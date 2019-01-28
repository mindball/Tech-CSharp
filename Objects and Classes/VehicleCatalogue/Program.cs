using System;
using System.Collections.Generic;
using System.Linq;

class VehicleCatalogue
{
    static void Main(string[] args)
    {

        Dictionary<string, Car> carObj = new Dictionary<string, Car>();
        Dictionary<string, Truck> truckObj = new Dictionary<string, Truck>();
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
                carObj.Add(arr[1], new Car(arr[1], arr[2], int.Parse(arr[3])));
            }
            else
            {
                truckObj.Add(arr[1], new Truck(arr[1], arr[2], int.Parse(arr[3])));
            }
        }

        while (true)
        {
            string input2 = Console.ReadLine();
            if (input.Equals("Close the Catalogue"))
            {
                Console.WriteLine($"Car have average horsepower of: {Car.AverageHorsePower:F2}.");
                Console.WriteLine($"Truck have average horsepower of: {Truck.AverageHorsePower:F2}.");
                break;
            }
            else
            {
                
                if (carObj[input].GetType().ToString() == "Car")
                    PrintVehicleDetails(typeof(Car).ToString(), carObj[input].Model,
                                carObj[input].Color, carObj[input].HorsePower);
                else if ((carObj[input].GetType().ToString() == "Truck"))
                    PrintVehicleDetails(typeof(Truck).ToString(), truckObj[input].Model,
                                truckObj[input].Color, truckObj[input].HorsePower);
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

class Car
{
    private static int averageHorsePower = 0;
    private static int countOfCars = 0;

    public Car(string model, string color, int horsePower)
    {
        this.Model = model;
        this.Color = color;
        this.HorsePower = horsePower;
        averageHorsePower += horsePower;
        countOfCars++;
    }

    public int HorsePower { get; set; }

    public string Model { get; set; }

    public string Color { get; set; }

    public static double AverageHorsePower
    {
        get
        {
            return (double)averageHorsePower / (double)countOfCars;
        }
    }
}

class Truck
{
    private static double averageHorsePower = 0;
    private static double countOfTrucks = 0;
    public Truck(string model, string color, int horsePower)
    {
        this.Model = model;
        this.Color = color;
        this.HorsePower = horsePower;
        averageHorsePower += horsePower;
        countOfTrucks++;
    }

    public int HorsePower { get; set; }

    public string Model { get; set; }

    public string Color { get; set; }

    public static double AverageHorsePower
    {   get
        {
            return (double)averageHorsePower / (double)countOfTrucks;
        }
    }
}


/*
 truck Man red 200
truck Mercedes blue 300
car Ford green 120
car Ferrari red 550
car Lamborghini orange 570
End
Ferrari
Ford
Man
Close the Catalogue



