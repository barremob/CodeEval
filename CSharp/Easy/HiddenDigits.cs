/*
Score:      100
Time:       151
Memory:     4657152
Points:     30.754
*/

using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\HiddenDigits.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				char[] inputData = line.ToCharArray();
				string returnData = "";

				for (int i = 0; i < inputData.Length; i++)
				{
					char currChar = inputData[i];
					if (currChar > 47 && currChar < 58)
					{
						returnData += currChar;
					}
					else if (currChar > 96 && currChar < 107)
					{
						returnData += (char)(currChar - 49);
					}
				}

				Console.WriteLine(returnData == "" ? "NONE" : returnData);
			}
		}

		Console.ReadKey();
	}
}