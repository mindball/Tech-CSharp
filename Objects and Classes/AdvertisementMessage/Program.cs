using System;
class AdvertisementMessage
{
    static void Main()
    {
        Cities coutryBulgaria = new Cities(new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" });
        Authors authors = new Authors(new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" });
        Events events = new Events(new string[]
            {"Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"});
        Phrases phrase = new Phrases(new string[] { "Excellent product.", "Such a great product.", "I always use that product.",
            "Best product of its category.", "Exceptional product.", "I can’t live without this product." });  
        

        int input = int.Parse(Console.ReadLine());
        Random generator = new Random();

        while (input > 0)
        {
            Console.Write(phrase.SpokenPhrases[generator.Next(phrase.GetCountOfPhrases)]);
            Console.Write(" ");
            Console.Write(events.CurrentEvents[generator.Next(events.GetCountOfEvents)]);
            Console.Write(" ");
            Console.Write(authors.Names[generator.Next(authors.GetCountOfAuthors)]);
            Console.Write(" - " +
                coutryBulgaria.CitiesOfCountry[generator.Next(coutryBulgaria.GetCountOfCity)]);
            input--;
            Console.WriteLine();
        }

       


    }
}



