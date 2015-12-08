/*
Score:      100
Time:       168
Memory:     5410816
Points:     56.069
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Moderate\TrailingString.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] inputData = line.Split(',');

				if (inputData[1].Length > inputData[0].Length)
				{
					Console.WriteLine(0);
					continue;
				}

				string checkPart = inputData[0].Substring(inputData[0].Length - inputData[1].Length, inputData[1].Length);

				if (checkPart == inputData[1])
				{
					Console.WriteLine(1);
				}
				else
				{
					Console.WriteLine(0);
				}
			}
		}

		Console.ReadKey();
	}
}