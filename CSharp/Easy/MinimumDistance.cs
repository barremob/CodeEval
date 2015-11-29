/*
Score:      100
Time:       190
Memory:     5046272
Points:     30.455
*/

using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\MinimumDistance.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}
				int[] addresses = Array.ConvertAll<string, int>(line.Split(' '), int.Parse);
				addresses[0] = 0;
				Array.Sort<int>(addresses);
				int median;
				int nbrValues = addresses.Length - 1;

				if (nbrValues % 2 == 0)
				{
					int a = addresses[nbrValues / 2];
					int b = addresses[(nbrValues / 2) + 1];
					median = (a + b) / 2;
				}
				else
				{
					median = addresses[(nbrValues / 2) + 1];
				}

				int sumOfDistance = 0;
				nbrValues++;

				for (int i = 1; i < nbrValues; i++)
				{
					sumOfDistance += Math.Abs(median - addresses[i]);
				}

				Console.WriteLine(sumOfDistance);
			}
		}

		Console.ReadKey();
	}
}