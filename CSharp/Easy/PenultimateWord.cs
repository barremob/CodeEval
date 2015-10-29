/*
Score:      100
Time:       149
Memory:     4657152
Points:     30.853
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\PenultimateWord.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
				{
					continue;
				}

				string[] data = line.Split(' ');


				int index = data.Length > 1 ? data.Length - 2 : 0;
				Console.WriteLine(data[index]);
			}
		}

		Console.ReadKey();
	}
}