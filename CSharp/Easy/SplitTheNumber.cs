/*
Score:      100
Time:       180
Memory:     4878336
Points:     30.613
*/

using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText(@"Easy\SplitTheNumber.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line || line == "")
                {
                    continue;
                }

                string[] input = line.Split(' ');

                int posMin = input[1].IndexOf('-');
                int posAdd = input[1].IndexOf('+');

                int left = 0;
                int right = 0;

                if (posAdd > posMin)
                {
                    left = Convert.ToInt32(input[0].Substring(0, posAdd));
                    right = Convert.ToInt32(input[0].Substring(posAdd, input[0].Length - posAdd));
                    Console.WriteLine(left + right);
                }
                else
                {
                    left = Convert.ToInt32(input[0].Substring(0, posMin));
                    right = Convert.ToInt32(input[0].Substring(posMin, input[0].Length - posMin));
                    Console.WriteLine(left - right);
                }
            }
        }
        Console.ReadKey();
    }
}