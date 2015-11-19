/*
Score:      100
Time:       178
Memory:     4952064
Points:     30.555
*/

using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\BeautifulStrings.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
				{
					continue;
				}

				int[] alpha = new int[26];


				char[] inputData = line.ToCharArray();

				for (int i = 0; i < inputData.Length; i++)
				{
					char currChar = inputData[i];
					if (currChar > 96 && currChar < 123)
					{
						alpha[currChar - 97]++;
					}
					else if (currChar > 64 && currChar < 91)
					{
						alpha[currChar - 65]++;
					}
				}

				Array.Sort<int>(alpha);
				int totalNbr = 0;

				for (int i = 0; i < 26; i++)
				{
					totalNbr += alpha[i] * (i + 1);
				}

				Console.WriteLine(totalNbr);
			}
		}

		Console.ReadKey();
	}
}