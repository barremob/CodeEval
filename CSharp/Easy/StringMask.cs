/*
Score:      100
Time:       156
Memory:     4677632
Points:     30.824
*/

using System;
using System.IO;


class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		
		using (StreamReader reader = File.OpenText(@"Easy\StringMask.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}
				string[] inputData = line.Split(' ');
				string masked = StringMask(inputData[0], inputData[1]);
				Console.WriteLine(masked);
			}
		}

		Console.ReadKey();
	}

	static string StringMask(string data, string mask)
	{
		char[] _data = data.ToCharArray();
		char[] _mask = mask.ToCharArray();

		for (int i = 0; i < _data.Length; i++)
		{
			if (_mask[i] == 49)
			{
				_data[i] = CappChar(_data[i]);
			}
		}

		return new string(_data);
	}

	static char CappChar(char character)
	{
		if (character > 96 && character < 123)
		{
			return Convert.ToChar(character - 32);
		}

		return character;
	}
}

