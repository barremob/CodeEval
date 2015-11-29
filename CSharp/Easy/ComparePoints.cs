/*
Score:      100
Time:       156
Memory:     4763648
Points:     30.751
*/

using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\ComparePoints.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}
				int[] coords = Array.ConvertAll<string, int>(line.Split(' '), int.Parse);
				coords[2] -= coords[0];
				coords[3] -= coords[1];
				coords[0] = 0;
				coords[1] = 0;

				// N NE E SE S SW W NW

				if (coords[2] == 0 && coords[3] == 0)
				{
					Console.WriteLine("here");
				}
				else
				{
					if (coords[2] == 0 || coords[3] == 0)
					{
						if (coords[2] == 0 && coords[3] > 0)
						{
							Console.WriteLine("N");
						}
						else if (coords[3] == 0 && coords[2] > 0)
						{
							Console.WriteLine("E");
						}
						else if (coords[2] == 0 && coords[3] < 0)
						{
							Console.WriteLine("S");
						}
						else if (coords[3] == 0 && coords[2] < 0)
						{
							Console.WriteLine("W");
						}
					}
					else
					{
						if (coords[2] > 0 && coords[3] > 0)
						{
							Console.WriteLine("NE");
						}
						else if (coords[2] > 0 && coords[3] < 0)
						{
							Console.WriteLine("SE");
						}
						else if (coords[2] < 0 && coords[3] < 0)
						{
							Console.WriteLine("SW");
						}
						else if (coords[2] < 0 && coords[3] > 0)
						{
							Console.WriteLine("NW");
						}
					}
				}
			}
		}

		Console.ReadKey();
	}
}