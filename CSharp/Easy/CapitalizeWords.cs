/*
Score:      100
Time:       155
Memory:     4775936
Points:     30.743
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\CapitalizeWords.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				
				
				Console.WriteLine(ToCamelCase(line));
			}
		}

		Console.ReadKey();
	}

	static string ToCamelCase(string input)
	{
		char[] data = input.ToCharArray();
		for (int i = 0; i < data.Length; i++)
		{
			if (i == 0)
			{
				data[i] = ConvertCharCamel(data[i]);
			}else if (data[i - 1] == 32)
			{
				data[i] = ConvertCharCamel(data[i]);
			}
		}

		return new string(data);
	}

	static char ConvertCharCamel(char character)
	{
		if(character > 96 && character < 123)
		{
			return Convert.ToChar( character - 32);
		}

		return character;
	}
}