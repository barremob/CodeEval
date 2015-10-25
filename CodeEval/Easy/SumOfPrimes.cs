using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        int currentPrime = 0;
        int sumPrime = 0;


        for (int i = 2; ; i++)
        {
            if (currentPrime >= 1000)
                break;
            
            if (!isPrime(i))
            {
                continue;
            }

            currentPrime++;
            sumPrime += i;

        }

        Console.WriteLine(sumPrime);

        Console.ReadKey();
    }

    static bool isPrime(int input)
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
}