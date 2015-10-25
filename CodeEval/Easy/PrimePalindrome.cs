/*
Score:      100
Time:       130
Memory:     2777088
Points:     32.454
*/

using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        for (uint i = 1000; i > 0; i--)
        {
            if (IsPalindrome(i))
            {
                if (isPrime(i))
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
        
        Console.ReadKey();
    }

    static bool isPrime(uint input)
    {
        if (input > 2 && input % 2 == 0)
        {
            return false;
        }

        for (int x = 2; x * x <= input; x++)
        {
            if (input % x == 0)
                return false;
        }

        return true;
    }

    static bool IsPalindrome(uint number)
    {
        string forward = number.ToString();
        char[] charArray = forward.ToCharArray();
        Array.Reverse(charArray);
        string reverse = new String(charArray);

        if (forward == reverse)
        {
            return true;
        }

        return false;
    }
}