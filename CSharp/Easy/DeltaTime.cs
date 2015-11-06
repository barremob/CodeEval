/*
Score:      100
Time:       373
Memory:     5582848
Points:     29.688
*/

using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\DeltaTime.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] inputData = line.Split(' ');
				DateTime[] Times = new DateTime[2];

				for (int i = 0; i < inputData.Length; i++)
				{
					Times[i] = Convert.ToDateTime(inputData[i]);
				}

				if (Times[0] > Times[1])
				{
					Console.WriteLine(Times[0] - Times[1]);
				}
				else
				{
					Console.WriteLine(Times[1] - Times[0]);
				}
			}
		}

		Console.ReadKey();
	}
}

