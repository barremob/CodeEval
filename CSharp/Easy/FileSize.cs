/*
Score:      100
Time:       153
Memory:     4788224
Points:     30.736
*/

using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText(@"Easy\MultiplesOfANumber.txt"))
        {
            Console.WriteLine(reader.BaseStream.Length);
        }

        Console.ReadKey();
    }
}