/*
Score:      100
Time:       173
Memory:     4866048
Points:     56.894
*/

using System.IO;
using System;

class Program
{
	static int[] numbers;
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Moderate\ReverseGroup.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				numbers = Array.ConvertAll<string, int>(line.Split(',', ';'), int.Parse);
				int groupNbr = numbers[numbers.Length - 1];
				int nbrGroups = (numbers.Length - 1) / groupNbr;

				for (int i = 0; i < nbrGroups; i++)
				{
					ReverseGroup(i * groupNbr, groupNbr);
				}

				PrintResult();
			}
		}

		Console.ReadKey();
	}

	static void ReverseGroup(int from, int groupSize)
	{
		int remainder = groupSize % 2;

		int fromIndex = from;
		int toIndex = from + groupSize - 1;

		int itterations = (groupSize - remainder) / 2;

		for (int i = 0; i < itterations; i++)
		{
			int save = numbers[fromIndex];
			numbers[fromIndex] = numbers[toIndex];
			numbers[toIndex] = save;
			fromIndex++;
			toIndex--;
		}
	}

	static void PrintResult()
	{
		string rtn = "";
		for (int i = 0; i < numbers.Length - 1; i++)
		{
			if (i > 0)
			{
				rtn += "," + numbers[i];
			}
			else
			{
				rtn += numbers[i];
			}
		}

		Console.WriteLine(rtn);
	}
}