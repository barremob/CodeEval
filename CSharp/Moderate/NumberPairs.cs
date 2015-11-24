/*
Score:      100
Time:       237
Memory:     5156864
Points:     56.236
*/

using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText(@"Moderate\NumberPairs.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line || line == "")
                {
                    continue;
                }

                List<int> data = line.Split(',', ';').Select(Int32.Parse).ToList();

                var sum = data[data.Count - 1];
                data.RemoveAt(data.Count - 1);

                int firstNbr = 0;
                int secondNbr = 0;
                bool hasMatch = false;

                while (data.Count > 1)
                {
                    firstNbr = data[0];
                    //hasMatch = false;

                    for (int i = 1; i < data.Count; i++)
                    {
                        if(firstNbr + data[i] == sum)
                        {
                            if (hasMatch)
                            {
                                Console.Write(";");
                            }
                            hasMatch = true;
                            secondNbr = data[i];
                            Console.Write(firstNbr + "," + secondNbr);
                            
                            data.Remove(secondNbr);

                            continue;
                        }
                    }

                    data.Remove(firstNbr);
                }

                if (!hasMatch)
                {
                    Console.WriteLine("NULL");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        Console.ReadKey();
    }
}