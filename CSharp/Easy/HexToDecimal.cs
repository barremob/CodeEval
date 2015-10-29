/*
Score:      100
Time:       174
Memory:     4882432
Points:     30.620
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\HexToDecimal.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
				{
					continue;
				}

				int t = Convert.ToInt32(line, 16);
				
				Console.WriteLine(t);
			}
		}
		Console.ReadKey();
	}
}
