﻿using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText("MultiplesOfANumber.txt"))
        {
            Console.WriteLine(reader.BaseStream.Length);
        }

        Console.ReadKey();
    }
}