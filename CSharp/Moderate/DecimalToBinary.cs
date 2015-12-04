/*
Score:      100
Time:       160
Memory:     4788224
Points:     57.058
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Moderate\DecimalToBinary.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}
				
				string binary = Convert.ToString(Convert.ToInt32(line), 2);
				Console.WriteLine(binary);
			}
		}

		Console.ReadKey();
	}
}