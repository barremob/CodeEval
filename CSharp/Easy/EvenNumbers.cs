/*
Score:      100
Time:       174
Memory:     4784128
Points:     30.703
*/

using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\EvenNumbers.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}
				
				Console.WriteLine(IsEven(line) ? 1 : 0);
			}
		}

		Console.ReadKey();
	}

	static bool IsEven(string data)
	{
		int nbr = Convert.ToInt32(data);
        if ((nbr & 1) == 0)
		{
			return true;
		}
		return false;
	}
}

