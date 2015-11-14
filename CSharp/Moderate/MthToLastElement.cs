/*
Score:      100
Time:       156
Memory:     4718592
Points:     57.178
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Moderate\MthToLastElement.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] data = line.Split(' ');
				int mthNbr = Convert.ToInt32(data[data.Length - 1]);
				if (mthNbr > data.Length - 1)
				{
					continue;
				}

				int rtnIndex = (data.Length - 1) - mthNbr;

				Console.WriteLine(data[rtnIndex]);
			}
		}

		Console.ReadKey();
	}
}