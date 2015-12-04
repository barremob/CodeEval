/*
Score:      100
Time:       180
Memory:     4919296
Points:     56.789
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Moderate\NumberOfOnes.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}
				
				string binary = Convert.ToString(Convert.ToInt32(line), 2);
				int count = binary.Length - binary.Replace("1", "").Length;

				Console.WriteLine(count);
			}
		}

		Console.ReadKey();
	}
}