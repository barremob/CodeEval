/*
Score:      100
Time:       158
Memory:     4702208
Points:     30.798
*/

using System.IO;
using System;

class Program
{
	static string[] _thousends = { "", "M", "MM", "MMM" };
	static string[] _hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
	static string[] _tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
	static string[] _singles = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\RomanNumerals.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
				{
					continue;
				}

				int inputNumber = Convert.ToInt32(line);
				int thousend = inputNumber / 1000;
				inputNumber %= 1000;
				int hundred = inputNumber / 100;
				inputNumber %= 100;
				int tens = inputNumber / 10;
				inputNumber %= 10;
				int single = inputNumber;

				string rtnData = "";
				rtnData += _thousends[thousend];
				rtnData += _hundreds[hundred];
				rtnData += _tens[tens];
				rtnData += _singles[single];

				Console.WriteLine(rtnData);
			}
		}
		Console.ReadKey();
	}
}