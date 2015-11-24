/*
Column Names - Blackbaud

Score:      100
Time:       159
Memory:     4755456
Points:     57.111
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"SponsoredChallenges\ColumnNames.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}
				
				int columnNumber = Convert.ToInt32(line);
				string rtn = "";

				while (columnNumber>0)
				{
					columnNumber--;
					rtn = (char)(65 + columnNumber % 26)+ rtn;
					columnNumber /= 26;
				}

				Console.WriteLine(rtn);
			}
		}

		Console.ReadKey();
	}
}