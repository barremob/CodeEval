/*
Score:      100
Time:       328
Memory:     5062656
Points:     30.200
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\OneZeroTwoZero.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
				{
					continue;
				}

				string[] inputData = line.Split(' ');
				int nbrZero = Convert.ToInt32(inputData[0]);
				int upToNbr = Convert.ToInt32(inputData[1]);
				int countResult = 0;

				string[] data = new string[upToNbr];

                for (int i = 1; i <= upToNbr; i++)
				{
					data[i-1] = Convert.ToString(i, 2);
				}

				for (int i = 0; i < upToNbr; i++)
				{
					int count = data[i].Length - data[i].Replace("0", "").Length;
					if (count == nbrZero)
					{
						countResult++;
					}
				}

				Console.WriteLine(countResult);
			}
		}
		Console.ReadKey();
	}
}