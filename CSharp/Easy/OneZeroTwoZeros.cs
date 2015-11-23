/*
Lower memory footprint by removing the string data array.

Score:      100
Time:       180
Memory:     4792320
Points:     30.685
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

				for (int i = 1; i <= upToNbr; i++)
				{
					int nbr = i;
					int countZeros = 0;

					while (nbr != 0)
					{
						if ((nbr & 1) == 0)
						{
							countZeros++;
						}
						nbr >>= 1;
					}

					if (countZeros == nbrZero)
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