/*
Score:      100
Time:       157
Memory:     4702208
Points:     30.801
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\HappyNumbers.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
				{
					continue;
				}

				int[] returnData;
				int lastTestNumber = Convert.ToInt32(line);
				bool isHappyNumber = false;

				for (int i = 0; i < 25; i++)
				{
					returnData = GetSingleNumbers(lastTestNumber);
					SetAllSquared(returnData);
					lastTestNumber = ArraySum(returnData);
					if (lastTestNumber == 1)
					{
						isHappyNumber = true;
						break;
					}
				}

				Console.WriteLine(isHappyNumber ? "1" : "0");
			}
		}
		Console.ReadKey();
	}

	static void SetAllSquared(int[] returnData)
	{
		for (int i = 0; i < returnData.Length; i++)
		{
			returnData[i] = GetSquare(returnData[i]);
		}
	}

	static int ArraySum(int[] input)
	{
		int ret = 0;
		foreach (var item in input)
		{
			ret += item;
		}
		return ret;
	}

	static int GetSquare(int nbr)
	{
		return nbr * nbr;
	}

	static int[] GetSingleNumbers(int data)
	{
		int[] rtnData = new int[10];
		int remaining = data;
		byte offset = 0;

		while (remaining > 0)
		{
			var r = remaining % 10;
			rtnData[offset] = r;
			remaining /= 10;
			offset++;
		}

		return rtnData;
	}
}