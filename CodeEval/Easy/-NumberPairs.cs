using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText("NumberPairs.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                {
                    continue;
                }

                List<int> data = line.Split(',', ';').Select(Int32.Parse).ToList();

                var sum = data[data.Count - 1];
                data.RemoveAt(data.Count - 1);

                int firstNbr = 0;
                int secondNbr = 0;
                bool hasMatch = false;
                int index = 0;


            }
        }

        Console.ReadKey();
    }
}