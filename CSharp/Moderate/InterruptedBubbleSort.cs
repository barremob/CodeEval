/*
Score:      100
Time:       184
Memory:     4915200
Points:     56.785
*/

using System.IO;
using System;

class Program
{
	static int[] inputData;
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Moderate\InterruptedBubbleSort.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] data = line.Split('|');
				inputData = Array.ConvertAll<string, int>(data[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);

				BubbleSort(Convert.ToInt64(data[1]));

				Console.WriteLine(PrintArray());
			}
		}

		Console.ReadKey();
	}

	static void BubbleSort(Int64 itterations)
	{
		int keep;
		itterations = itterations > inputData.Length ? inputData.Length : itterations;
		for (Int64 i = itterations; i > 0; i--)
		{
			for (int x = 0; x < inputData.Length-1; x++)
			{
				if (inputData[x] > inputData[x + 1])
				{
					keep = inputData[x];
					inputData[x] = inputData[x + 1];
					inputData[x + 1] = keep;
				}
			}
		}
	}
	static string PrintArray()
	{
		string rtn = "";
		for (int i = 0; i < inputData.Length; i++)
		{
			rtn += inputData[i] + " ";
		}

		return rtn;
	}
}