/*
Score:      100
Time:       208
Memory:     5259264
Points:     30.246
*/

using System.IO;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText(@"Easy\FindTheHighestScore.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line || line == "")
                {
                    continue;
                }

                string[] inputData = line.Split('|');
                List<string[]> wData = new List<string[]>();
                int[] returnData;

                for (int i = 0; i < inputData.Length; i++)
                {
                    string[] items = inputData[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    wData.Add(items);
                }

                returnData = new int[wData[0].Length];

                for (int i = 0; i < wData.Count; i++)
                {
                    for (int x = 0; x < wData[i].Length; x++)
                    {
                        int tmpData = Convert.ToInt32(wData[i][x]);
                        if (i == 0 || returnData[x] < tmpData)
                        {
                            returnData[x] = tmpData;
                        }
                    }
                }

                for (int i = 0; i < returnData.Length; i++)
                {
                    if (i > 0)
                    {
                        Console.Write(" ");
                    }

                    Console.Write(returnData[i]);
                }

                Console.WriteLine();
            }
        }

        Console.ReadKey();
    }
}