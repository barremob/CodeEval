/*
Score:      100
Time:       174
Memory:     4739072
Points:     30.741
*/

using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText(@"Easy\SumOfDigits.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                {
                    continue;
                }

                int[] numbers = SplitNumbers(line);
                int sumNums = 0;

                for (int i = 0; i < numbers.Length; i++)
                {
                    sumNums += numbers[i];
                }

                Console.WriteLine(sumNums);
            }
        }

        Console.ReadKey();
    }

    static int[] SplitNumbers(string number)
    {
        int[] rtnNumbers = new int[number.Length];
        int remaining = Convert.ToInt32(number);

        for (int i = 0; i < rtnNumbers.Length; i++)
        {
            var r = remaining % 10;
            rtnNumbers[i] = r;
            remaining /= 10;
        }

        return rtnNumbers;

    }
}