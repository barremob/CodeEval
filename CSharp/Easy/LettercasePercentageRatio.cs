/*
Score:      100
Time:       197
Memory:     4902912
Points:     30.564
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\LettercasePercentageRatio.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				int lowerCase = 0;
				int upperCase = 0;

				char[] data = line.ToCharArray();
				byte charNbr;
				for (int i = 0; i < data.Length; i++)
				{
					charNbr = (byte)data[i];
					if (charNbr >= 65 && charNbr <= 90)
					{
						upperCase++;
					}
					else
					{
						lowerCase++;
					}
				}

				double lower = ((double)lowerCase / data.Length)*100;
				double upp = ((double)upperCase / data.Length)*100;

				Console.WriteLine("lowercase: " + lower.ToString("0.00") + " uppercase: " + upp.ToString("0.00"));
			}
		}

		Console.ReadKey();
	}
}