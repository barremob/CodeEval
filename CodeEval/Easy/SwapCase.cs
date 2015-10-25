/*
Score:      100
Time:       147
Memory:     4710400
Points:     30.810
*/

using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText("SwapCase.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line || line == "")
                {
                    continue;
                }

                char[] input = line.ToCharArray();

                for (int i = 0; i < input.Length; i++)
                {
                    int charVal = input[i];
                    if (charVal > 64 && charVal < 91)
                    {
                        input[i] += (char)32;
                    }
                    else if(charVal > 96 && charVal < 123)
                    {
                        input[i] -= (char)32;
                    }
                }

                Console.WriteLine(input);
            }
        }

        Console.ReadKey();
    }
}