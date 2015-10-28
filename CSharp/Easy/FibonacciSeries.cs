/*
Score:      100
Time:       174
Memory:     4866048
Points:     30.635
*/

using System;

class Program
{

    /*
    Doing a test with different way of receiving data see Steve Hemond
    https://github.com/stevehemond/
    */

    static void Main()
    {
        var input = Console.ReadLine();

        while (!string.IsNullOrEmpty(input))
        {

            Console.WriteLine(GetNthFibonacciNumber(Convert.ToInt32(input)));

            input = Console.ReadLine();
        }
    }


    /*
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText("FibonacciSeries.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line || line == "")
                {
                    continue;
                }
                
                Console.WriteLine(GetNthFibonacciNumber(Convert.ToInt32(line)));
            }
        }

        Console.ReadKey();
    }
    */
    private static int GetNthFibonacciNumber(int nbr)
    {
        int first = 0;
        int second = 1;
        for (int i = 1; i <= nbr; i++)
        {
            int holder = first;
            first = second;
            second = holder + second;
        }

        return first;
    }
}