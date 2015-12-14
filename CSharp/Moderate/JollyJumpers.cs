/*
Score:      100
Time:       165
Memory:     4952064
Points:     56.787
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Moderate\JollyJumpers.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				int[] inputNumbers = Array.ConvertAll<string, int>(line.Split(' '), int.Parse);
				int n = inputNumbers[0];
				bool jolly = true;
				bool countUp = true;
				int lastValue = Math.Abs(inputNumbers[1] - inputNumbers[2]);

				if (lastValue == 0 || inputNumbers.Length < n)
				{
					jolly = false;
				}
				else
				{
					for (int i = 2; i < n; i++)
					{
						int currentValue = Math.Abs(inputNumbers[i] - inputNumbers[i + 1]);
						if (i == 2)
						{
							if (lastValue - currentValue == 1)
							{
								countUp = true;
							}
							else if (lastValue - currentValue == -1)
							{
								countUp = false;
							}
							else
							{
								jolly = false;
								break;
							}
						}

						if (countUp)
						{
							if (!(lastValue - currentValue == 1))
							{
								jolly = false;
								break;
							}
						}
						else
						{
							if (!(lastValue - currentValue == -1))
							{
								jolly = false;
								break;
							}
						}

						lastValue = currentValue;
					}
				}

				Console.WriteLine(jolly ? "Jolly" : "Not jolly");
			}
		}

		Console.ReadKey();
	}
}