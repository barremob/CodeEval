/*
Score:      100
Time:       157
Memory:     4800512
Points:     30.718
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\StepwiseWord.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] inputData = line.Split(' ');

				string outputData = "";
				string longestWord = "";

				for (int i = 0; i < inputData.Length; i++)
				{
					if (inputData[i].Length> longestWord.Length)
					{
						longestWord = inputData[i];
					}
				}

				for (int i = 0; i < longestWord.Length; i++)
				{
					if (i > 0)
					{
						outputData += " ".PadRight(i + 1, '*') + longestWord[i];
					}
					else
					{
						outputData += longestWord[i];
					}
				}

				Console.WriteLine(outputData);
			}
		}
		Console.ReadKey();
	}
}