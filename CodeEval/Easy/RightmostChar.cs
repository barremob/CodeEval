/*
Score:      100
Time:       167
Memory:     4808704
Points:     30.694
*/

using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText("RightmostChar.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line || line == "")
                {
                    continue;
                }

                string[] input = line.Split(',');

                Console.WriteLine(FindCharReverse(input[0], input[1]));
            }
        }

        Console.ReadKey();
    }

    static int FindCharReverse(string input, string find)
    {
        char[] characters = input.ToCharArray();
        char lookup = find[0];

        for (int i = characters.Length-1; i >= 0; i--)
        {
            if(characters[i] == lookup)
            {
                return i;
            }
        }

        return -1;
    }
}