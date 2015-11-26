/*
Score:      100
Time:       153
Memory:     4755456
Points:     30.763
*/

using System.IO;
using System;

class Program
{
	static char[] inputData;
	static int firstNumberIndex = 0;
	static int secondNumberIndex = 0;

	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\SwapNumbers.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				inputData = line.ToCharArray();
				firstNumberIndex = 0;
				secondNumberIndex = 0;
				
				for (int i = 0; i < inputData.Length; i++)
				{
					if (inputData[i] == ' ')
					{
						secondNumberIndex = i - 1;
						SwapChars();
					}
					else if (i == inputData.Length -1)
					{
						secondNumberIndex = i;
						SwapChars();
					}
				}

				Console.WriteLine(new string(inputData));
			}

			Console.ReadKey();
		}
	}

	static void SwapChars()
	{
		char retain = inputData[secondNumberIndex];
		inputData[secondNumberIndex] = inputData[firstNumberIndex];
		inputData[firstNumberIndex] = retain;

		firstNumberIndex = secondNumberIndex + 2;
	}
}