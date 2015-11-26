/*
Score:      100
Time:       171
Memory:     4857856
Points:     30.647
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\StringsAndArrows.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				int arrowCounter = 0;

				char[] inputData = line.ToCharArray();

				if (inputData.Length < 5)
				{
					Console.WriteLine(0);
					continue;
				}

				for (int i = 0; i < inputData.Length - 4; i++)
				{
					if (inputData[i] == 60)
					{
						bool second = inputData[i + 1] == 45;
						bool third = inputData[i + 2] == 45;
						bool fourth = inputData[i + 3] == 60;
						bool fifth = inputData[i + 4] == 60;

						if (second && third && fourth && fifth)
						{
							arrowCounter++;
						}
					}
					else if (inputData[i] == 62)
					{
						bool second = inputData[i + 1] == 62;
						bool third = inputData[i + 2] == 45;
						bool fourth = inputData[i + 3] == 45;
						bool fifth = inputData[i + 4] == 62;

						if (second && third && fourth && fifth)
						{
							arrowCounter++;
						}
					}
				}

				Console.WriteLine(arrowCounter);
			}

			Console.ReadKey();
		}
	}
}