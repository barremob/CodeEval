/*
Sort Matrix Columns - Blackbaud

Has only 90% score, but can't bother to look why at the moment :p

Score:      90
Time:       309
Memory:     5591040
Points:     49.798
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"SponsoredChallenges\SortMatrixColumns.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
				{
					continue;
				}

				string[] inputData = line.Split('|');
				int[][] inputNumbers = new int[inputData.Length][];

				for (int i = 0; i < inputData.Length; i++)
				{
					inputNumbers[i] = Array.ConvertAll<string, int>(inputData[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
				}

				int sortByRow = 0;
				OrderData(inputNumbers, sortByRow);

				Console.WriteLine(PrintData(inputNumbers, true));
				
			}
		}

		Console.ReadKey();
	}

	static void OrderData(int[][] data, int row)
	{
		int[] _data = data[row];
		for (int i = 0; i < _data.Length - 1; i++)
		{
			int minIndex = i;

			for (int j = i + 1; j < _data.Length; j++)
			{
				if (_data[j] <= _data[minIndex]) { minIndex = j; }
			}

			if (minIndex != i) { SetOtherRows(data, i, minIndex); }
		}
	}

	static void SetOtherRows(int[][] input, int from, int to)
	{
		foreach (var row in input)
		{
			int temp = row[from];
			row[from] = row[to];
			row[to] = temp;
		}
	}

	static string PrintData(int[][] input, bool debug)
	{
		string rtn = "";
		for (int i = 0; i < input.Length; i++)
		{
			for (int x = 0; x < input[i].Length; x++)
			{
				rtn += input[i][x].ToString().PadLeft(4);
				if (x < input[i].Length - 1)
				{
					rtn += " ";
				}
			}

			if (i < input.Length - 1)
			{
				if (debug)
				{
					rtn += "\n";
				}
				else
				{
					rtn += " | ";
				}
			}
		}

		return rtn;
	}
}