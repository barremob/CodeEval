﻿/*
Score:      100
Time:       187
Memory:     5046272
Points:     56.569
*/

using System.IO;
using System;

class Program
{
    static int[] numbers;
    static int index;

    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText(@"Moderate\StackImplementation.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line || line == "")
                {
                    continue;
                }

                string[] input = line.Split(' ');

                numbers = new int[input.Length];
                index = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    Push(Convert.ToInt32(input[i]));
                }
				string rtnData = "";
                for (int i = 0; i < numbers.Length; i++)
                {
                    int poper = Pop();

                    if(i%2 == 0)
                        rtnData += poper + " ";
                }
                Console.WriteLine(rtnData);
            }
        }

        Console.ReadKey();
    }

    static void Push(int nbr)
    {
        numbers[index] = nbr;
		index++;
	}

    static int Pop()
    {
        index--;
        return numbers[index];
    }
}