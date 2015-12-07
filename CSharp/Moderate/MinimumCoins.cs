/*
Score:      100
Time:       174
Memory:     4890624
Points:     56.854
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Moderate\MinimumCoins.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				int targetValue = Convert.ToInt32(line);

				int count1 = 0;
				int count3 = 0;
				int count5 = 0;

				count5 = targetValue / 5;
				targetValue -= count5 * 5;
				count3 = targetValue / 3;
				targetValue -= count3 * 3;
				count1 = targetValue;
				Console.WriteLine(count5 + count3 + count1);
			}
		}

		Console.ReadKey();
	}
}