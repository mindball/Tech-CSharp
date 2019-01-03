using System;

class PalindromeIntegers
{
    static void Main()
    {
        string command;

        while (true)
        {
            uint number;
            command = Console.ReadLine();

            if (command.Equals("END"))
                break;

            uint.TryParse(command, out number);
            //number = uint.MaxValue;
            Console.WriteLine(isTheNumberPalindrome1(number).ToString().ToLower());
        }

        //while (true)
        //{
        //    command = Console.ReadLine();
        //    if (command.Equals("END"))
        //        break;
        //    Console.WriteLine(isTheNumberPalindrome2(command).ToString().ToLower());
        //}
    }

    //this method may not work with when check  uint.Max -> reverse number is not correct;
    public static bool isTheNumberPalindrome1(uint number)
    {
        bool isPalindrome = false;
        uint workNumber = number;
        uint remainer = 0;
        uint reverseNumber = 0;

        try
        {
            while (workNumber > 0)
            {
                remainer = workNumber % 10;
                //number = 343 = (3 * 1) + (4 * 10) + (3 * 100) 
                reverseNumber = reverseNumber * 10 + remainer;
                workNumber /= 10;
            }

            if (number == reverseNumber)
                isPalindrome = true;
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
       

        return isPalindrome;
    }

    //Readable code
    //public static bool isTheNumberPalindrome2(string number)
    //{
    //    char[] array = number.ToCharArray();
    //    Array.Reverse(array);        
    //    return number.Equals(new string(array));
    //}
}

