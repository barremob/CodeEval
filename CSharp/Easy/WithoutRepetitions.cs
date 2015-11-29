/*
Score:      100
Time:       171
Memory:     5148672
Points:     30.403
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\WithoutRepetitions.txt"))
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
				int loopLenght = inputData.Length - 1;

				rtnData += inputData[0];

				for (int i = 1; i < inputData.Length; i++)
				{

					if (inputData[i] != inputData[i - 1])
					{
						rtnData += inputData[i];
					}
				}

				Console.WriteLine(rtnData);
			}

			Console.ReadKey();
		}
	}
}