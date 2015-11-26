/*
Score:      100
Time:       176
Memory:     4902912
Points:     30.599
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\MaxRangeSum.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				int[] inputData = Array.ConvertAll<string, int>(line.Split(';', ' '), int.Parse);

				int days = inputData[0];
				int highestValue = 0;
				int calculatedValue = 0;
				int arrIndex = 1;

				while (arrIndex - 1 + days < inputData.Length)
				{
					calculatedValue = 0;
					for (int i = 0; i < days; i++)
					{
						calculatedValue += inputData[arrIndex + i];
					}

					if (calculatedValue > highestValue)
					{
						highestValue = calculatedValue;
					}

					arrIndex++;
				}

				Console.WriteLine(highestValue);
			}

			Console.ReadKey();
		}
	}
}