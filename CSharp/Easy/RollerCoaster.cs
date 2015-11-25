/*
Score:      100
Time:       153
Memory:     4710400
Points:     30.802
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\RollerCoaster.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				char[] inputData = line.ToCharArray();
				bool capital = true;

				for (int i = 0; i < inputData.Length; i++)
				{
					if (inputData[i] >= 65 && inputData[i] <= 90)
					{
						if (!capital)
						{
							inputData[i] = (char)(inputData[i] + 32);
						}
						capital = !capital;
					}
					else if (inputData[i] >= 97 && inputData[i] <= 122)
					{
						if (capital)
						{
							inputData[i] = (char)(inputData[i] - 32);
						}
						capital = !capital;
					}
				}

				Console.WriteLine(new string(inputData));
			}
		}
		Console.ReadKey();
	}
}