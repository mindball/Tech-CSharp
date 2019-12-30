using System;

namespace GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int iteration = int.Parse(input);
            

            while(iteration > 0 )
            {
                input = Console.ReadLine();                

                CallMyBoxClass(input);
                
                iteration--;
            }
        }

        private static void CallMyBoxClass(string input)
        {
            if(int.TryParse(input, out _))
            {
                Box<int> box = new Box<int>(int.Parse(input));
                Console.WriteLine(box);
            }           
            else
            {
                Box<string> box = new Box<string>(input);
                Console.WriteLine(box);
            }

        }
    }
}
