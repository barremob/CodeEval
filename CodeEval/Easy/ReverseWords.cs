/*
Score:      100
Time:       149
Memory:     4694016
Points:     30.821
*/

using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText("ReverseWords.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                {
                    continue;
                }

                string[] input = line.Split(' ');

                for (int i = input.Length-1; i >=0; i--)
                {
                    Console.Write(input[i]);
                    if (i > 0)
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        Console.ReadKey();
    }
}