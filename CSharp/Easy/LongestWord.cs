/*
Score:      100
Time:       150
Memory:     4571136
Points:     30.923
*/

using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText(@"Easy\LongestWord.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line || line == "")
                {
                    continue;
                }

				string[] words = line.Split(' ');

				string longestWord = "";

				for (int i = 0; i < words.Length; i++)
				{
					if (words[i].Length > longestWord.Length)
					{
						longestWord = words[i];
					}
				}

				Console.WriteLine(longestWord);
            }
        }

        Console.ReadKey();
    }
}