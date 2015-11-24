/*
Score:      100
Time:       180
Memory:     4947968
Points:     30.555
*/

using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\WordToDigit.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}
				
				Console.WriteLine(ConvertToNumber(line));
			}
		}

		Console.ReadKey();
	}

	static string ConvertToNumber(string data)
	{
		string[] numbers = data.Split(';');
		string rtnData = "";
		for (int i = 0; i < numbers.Length; i++)
		{
			rtnData += GetSingleDigit(numbers[i]);
		}
		return rtnData;	
	}

	static int GetSingleDigit(string number)
	{
		switch (number)
		{
			case "zero":
				return 0;
			case "one":
				return 1;
			case "two":
				return 2;
			case "three":
				return 3;
			case "four":
				return 4;
			case "five":
				return 5;
			case "six":
				return 6;
			case "seven":
				return 7;
			case "eight":
				return 8;
			case "nine":
				return 9;
			default:
				return -1;
		}
	}
}

