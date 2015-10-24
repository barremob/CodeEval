﻿using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText("BitPositions.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                {
                    continue;
                }

                string[] input = line.Split(',');
                int value = Convert.ToInt32(input[0]);
                int pos1 = Convert.ToInt32(input[1]) - 1;
                int pos2 = Convert.ToInt32(input[2]) - 1;

                bool p1 = ((value & (1 << pos1)) != 0);
                bool p2 = ((value & (1 << pos2)) != 0);
                
                // For some reason p1 && p2 didn't work at CodeEval
                Console.WriteLine((p1 == p2) ? "true" : "false");
            }
        }

        Console.ReadKey();
    }
}