/*
Score:      100
Time:       206
Memory:     5062656
Points:     30.415

I hate globalization, is it so hard to just use the same number notations everywhere!!

Copy below is needed for local pc, the one in comments below is needed on CodeEval server
*/

using System.IO;
using System;
using System.Globalization;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\SimpleSorting.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}
				line = line.Replace(".", ",");
				string[] data = line.Split(' ');

				double[] rtn = Array.ConvertAll<string, double>(data, double.Parse);

				Array.Sort<double>(rtn);

				string print = "";

				for (int i = 0; i < rtn.Length; i++)
				{
					if (i > 0)
					{
						print += " ";
					}
					print += rtn[i].ToString("N3", new CultureInfo("en-US"));
				}

				Console.WriteLine(print);
			}
		}

		Console.ReadKey();
	}
}

/*
using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		using (StreamReader reader = File.OpenText(args[0]))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
				{
					continue;
				}
				string[] data = line.Split(' ');

				double[] rtn = Array.ConvertAll<string, double>(data, double.Parse);

				Array.Sort<double>(rtn);

				string print = "";

				for (int i = 0; i < rtn.Length; i++)
				{
					if (i > 0)
					{
						print += " ";
					}
					print += rtn[i].ToString("N3");
				}

				Console.WriteLine(print);
			}
		}
	}
}
*/