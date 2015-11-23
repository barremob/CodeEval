/*
Score:      100
Time:       171
Memory:     4853760
Points:     30.650
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\Details.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] input = line.Split(',');

				int minSpace = 11;
				int x = 0;
				int y = 0;

				for (int i = 0; i < input.Length; i++)
				{
					x = LastX(input[i]);
					y = input[i].IndexOf('Y');
					if (y - x < minSpace)
					{
						minSpace = y - x;
					}
				}

				Console.WriteLine(minSpace - 1);
			}
		}
		Console.ReadKey();
	}

	static int LastX(string input)
	{
		for (int i = (input.Length - 1); i > 0; i--)
		{
			if (input[i] == 'X')
			{
				return i;
			}
		}

		return 0;
	}
}