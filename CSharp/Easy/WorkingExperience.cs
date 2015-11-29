/*
Score:      100
Time:       191
Memory:     5013504
Points:     30.482
*/

using System.IO;
using System;

class Program
{
	static string[] monthsShort = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

	static void Main(string[] args)
	{
		using (StreamReader reader = File.OpenText(args[0]))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] inputData = line.Split(new char[] { ';', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
				byte[,] years = new byte[30, 12];

				for (int i = 0; i < inputData.Length; i += 4)
				{
					int monthFrom = Array.IndexOf<string>(monthsShort, inputData[i]) + 1;
					int yearFrom = Convert.ToInt32(inputData[i + 1]);
					int monthTo = Array.IndexOf<string>(monthsShort, inputData[i + 2]) + 1;
					int yearTo = Convert.ToInt32(inputData[i + 3]);
					int startYear = yearFrom - 1990;

					int yearDiff = yearTo - yearFrom + 1;
					int monthStart = 0;
					int monthEnd = 12;

					for (int x = 0; x < yearDiff; x++)
					{
						if (x == 0)
						{
							monthStart = monthFrom - 1;
						}
						else
						{
							monthStart = 0;
						}
						if (yearDiff == 1)
						{
							monthEnd = monthTo;
						}
						for (int y = monthStart; y < monthEnd; y++)
						{
							years[startYear + x, y] = 1;
						}
						if (x == yearDiff - 2)
						{
							monthEnd = monthTo;
						}
						else
						{
							monthEnd = 12;
						}
					}
				}

				int monthsWorked = 0;

				for (int i = 0; i < 30; i++)
				{
					for (int y = 0; y < 12; y++)
					{
						monthsWorked += years[i, y];
					}
				}

				int yearsWorked = monthsWorked / 12;
				Console.WriteLine(yearsWorked);
			}
		}
	}
}