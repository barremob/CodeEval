/*
Score:      100
Time:       170
Memory:     4841472
Points:     30.662
*/

using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\LowestUniqueNumber.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] data = line.Split(' ');
				int[] numbers = Array.ConvertAll<string, int>(data, int.Parse);
				int[] nbrCheck = new int[9];

				int winner = 0;

				for (int i = 0; i < numbers.Length; i++)
				{
					nbrCheck[numbers[i] - 1]++;
				}

				for (int i = 0; i < nbrCheck.Length; i++)
				{
					if (nbrCheck[i] == 1)
					{
						winner = i + 1;
						break;
					}
				}

				for (int i = 0; i < numbers.Length; i++)
				{
					if (numbers[i] == winner)
					{
						Console.WriteLine(i+ 1);
						break;
					}
				}
			}
		}

		Console.ReadKey();
	}
}