/*
Score:      100
Time:       150
Memory:     4710400
Points:     30.806
*/

using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		int previousIndex = -1;

		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\RacingChars.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				int indexGate = line.IndexOf('_');
				int indexCheck = line.IndexOf('C');
				int indexTo = 0;

				if (previousIndex == -1)
				{
					line = line.Replace('_', '|');
					previousIndex = indexGate;
					Console.WriteLine(line);
					continue;
				}
				else if (indexCheck >= 0)
				{
					indexTo = indexCheck;
					if (indexTo > previousIndex)
					{
						line = line.Replace('C', '\\');
					}
					else if (indexTo < previousIndex)
					{
						line = line.Replace('C', '/');
					}
					else
					{
						line = line.Replace('C', '|');
					}
				}
				else
				{
					indexTo = indexGate;
					if (indexTo > previousIndex)
					{
						line = line.Replace('_', '\\');
					}
					else if (indexTo < previousIndex)
					{
						line = line.Replace('_', '/');
					}
					else
					{
						line = line.Replace('_', '|');
					}
				}

				Console.WriteLine(line);

				previousIndex = indexTo;
			}
		}

		Console.ReadKey();
	}
}