/*
Score:      100
Time:       191
Memory:     5070848
Points:     30.434
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
				string add = line.Substring(line.IndexOf(' ') + 1, line.Length - line.IndexOf(' ') - 1);
				int[] addresses = Array.ConvertAll<string, int>(add.Split(' '), int.Parse);

				Array.Sort<int>(addresses);
				int median;
				int nbrValues = addresses.Length;

				if (nbrValues % 2 == 0)
				{
					int a = addresses[nbrValues / 2 - 1];
					int b = addresses[nbrValues / 2];
					median = (a + b) / 2;
				}
				else
				{
					median = addresses[nbrValues / 2];
				}

				int sumOfDistance = 0;

				for (int i = 0; i < nbrValues; i++)
				{
					sumOfDistance += Math.Abs(median - addresses[i]);
				}

				Console.WriteLine(sumOfDistance);
			}
		}

		Console.ReadKey();
	}
}