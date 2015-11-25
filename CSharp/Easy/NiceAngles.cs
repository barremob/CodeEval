/*
Score:      100
Time:       222
Memory:     4812800
Points:     30.594
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		int whole;
		int min;
		int sec;
		decimal intermediat;
		decimal inputValue;

		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\NiceAngles.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				inputValue = Convert.ToDecimal(line);

				whole = (int)inputValue;
				intermediat = (inputValue - whole) * 60;
				min = (int)(intermediat);
				sec = (int)((intermediat - min) * 60);
				Console.WriteLine("{0}.{1:00}'{2:00}\"", whole, min, sec);
			}
		}
	}
}
