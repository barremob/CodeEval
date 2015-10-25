/*
Score:      100
Time:       125
Memory:     4743168
Points:     30.823
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 1; i <= 12; i++)
        {
            for (int x = 1; x <= 12; x++)
            {
                Console.Write((i*x).ToString().PadLeft(4));
            }

            Console.WriteLine();

        }
        Console.ReadKey();
    }
}