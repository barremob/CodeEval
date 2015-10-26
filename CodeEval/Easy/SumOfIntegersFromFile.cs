/*
Score:      100
Time:       173
Memory:     4861952
Points:     30.639
*/

using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText(@"Easy\SumOfIntegersFromFile.txt"))
        {
            int returnVal = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null != line)
                {
                    returnVal += Convert.ToInt32(line);
                    
                }
            }

            Console.WriteLine(returnVal);
        }

        Console.ReadKey();
    }
}