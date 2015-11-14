/*
Score:      100
Time:       167
Memory:     4825088
Points:     30.680
*/

using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\ShortestRepetition.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
				{
					continue;
				}
				string[] inputData = line.Split(';');

				Console.WriteLine(CountOccurences(line));
			}
		}

		Console.ReadKey();
	}

	static int CountOccurences(string input)
	{
		int length = 1;
		bool searching = true;

		while (searching)
		{
			string match = input.Substring(0, length);
			for (int i = length; i <= input.Length; i += length)
			{
				if (length * 2 > input.Length)
				{
					return input.Length;
				}
				string test = input.Substring(i, length);
				if (test != match)
				{
					length++;
					break;
				}
				else if (i + length == input.Length)
				{
					return length;
				}
			}
		}

		return length;
	}
}