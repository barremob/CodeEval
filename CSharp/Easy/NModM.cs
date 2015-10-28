/*
Score:      100
Time:       174
Memory:     4878336
Points:     30.624
*/

using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText(@"Easy\NModM.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                {
                    continue;
                }

                string[] inputData = line.Split(',');
                
                Console.WriteLine(GetRemainder(Convert.ToInt32(inputData[0]), Convert.ToInt32(inputData[1])));
            }
        }
        Console.ReadKey();
    }

    static int GetRemainder(int nbr, int divider)
    {
        double nbrDivided = nbr / divider;
        return nbr - (divider * (int)Math.Floor(nbrDivided));
    }
}