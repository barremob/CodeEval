﻿using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText("MultiplesOfANumber.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                {
                    continue;
                }

                string[] input = line.Split(',');
                int valX = Convert.ToInt32(input[0]);
                int valN = Convert.ToInt32(input[1]);

                int fact = 2;
                while (true)
                {
                    if (valN * fact >= valX)
                    {
                        Console.WriteLine(valN * fact);
                        break;
                    }
                    fact++;
                }
            }
        }

        Console.ReadKey();
    }
}