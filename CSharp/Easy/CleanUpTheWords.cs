/*
Score:      100
Time:       158
Memory:     4853760
Points:     30.673
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\CleanUpTheWords.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				char[] inputData = line.ToCharArray();
				string rtnData = "";

				bool prevWasValid = false;

				for (int i = 0; i < inputData.Length; i++)
				{
					if (inputData[i] >= 65 && inputData[i] <= 90)
					{
						if (prevWasValid || rtnData == "")
						{
							rtnData += (char)(inputData[i] + 32);
						}
						else
						{
							rtnData += " " + (char)(inputData[i] + 32);
						}

						prevWasValid = true;
					}
					else if (inputData[i] >= 97 && inputData[i] <= 122)
					{
						if (prevWasValid || rtnData == "")
						{
							rtnData += inputData[i];
						}
						else
						{
							rtnData += " " + inputData[i];
						}

						prevWasValid = true;
					}
					else
					{
						prevWasValid = false;
					}
				}

				Console.WriteLine(rtnData);
			}

			Console.ReadKey();
		}
	}
}