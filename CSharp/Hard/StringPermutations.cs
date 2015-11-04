/*
Score:      100
Time:       160
Memory:     4788224
Points:     57.059
*/

using System.IO;
using System;

class Program
{
	static int printLines = 0;
	static int index = 0;
	static string[] inputLines = new string[50];
	static string[] rtnLines;

    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText(@"Moderate\StringPermutations.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line || line == "")
                {
                    continue;
                }
				

            }
        }
		
        Console.ReadKey();
    }


}