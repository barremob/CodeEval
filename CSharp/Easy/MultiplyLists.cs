/*
Score:      100
Time:       244
Memory:     5115904
Points:     30.303
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\MultiplyLists.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] inputData = line.Split(new string[] { " ", "|" }, StringSplitOptions.RemoveEmptyEntries);
				int[] numbers = Array.ConvertAll<string, int>(inputData, int.Parse);
				int startSecond = numbers.Length / 2;

				for (int i = 0; i < startSecond; i++)
				{
					if (i > 0)
					{
						Console.Write(" " + (numbers[i] * numbers[i + startSecond]));
					}
					else
					{
						Console.Write(numbers[i] * numbers[i + startSecond]);
					}
				}

				Console.WriteLine();
			}
		}
		Console.ReadKey();
	}
}