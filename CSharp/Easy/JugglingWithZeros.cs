/*
Score:      100
Time:       191
Memory:     5160960
Points:     30.358
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\JugglingWithZeros.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string workData = line;

				string binaryData = "";
				bool stillZero = true;
				string flag = "";
				string zeroes = "";

				int spaceIndex = 0;
				while (workData.Length > 0)
				{
					// Get flag
					spaceIndex = workData.IndexOf(' ');
					flag = workData.Substring(0, spaceIndex);
					workData = workData.Substring(spaceIndex + 1, workData.Length - spaceIndex - 1);
					// Get zeroes
					spaceIndex = workData.IndexOf(' ');
					if (spaceIndex == -1)
					{
						zeroes = workData.Substring(0);
						workData = "";
					}
					else
					{
						zeroes = workData.Substring(0, spaceIndex);
						workData = workData.Substring(spaceIndex + 1, workData.Length - spaceIndex - 1);
					}

					if (flag.Length == 1)
					{
						if (!stillZero)
						{
							binaryData += zeroes;
						}
					}
					else
					{
						stillZero = false;
						for (int i = 0; i < zeroes.Length; i++)
						{
							binaryData += '1';
						}
					}
				}

				Console.WriteLine(Convert.ToInt64(binaryData, 2));
			}
		}
		Console.ReadKey();
	}
}