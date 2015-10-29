/*
Score:      100
Time:       170
Memory:     4874240
Points:     30.634
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\CalculateDistance.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
				{
					continue;
				}

				string[] data = line.Split(new char[]{ '(', ',', ')', ' '}, StringSplitOptions.RemoveEmptyEntries);
				int[] dataInt = Array.ConvertAll<string, int>(data, int.Parse);
				//Coords A = new Coords(data[0], data[1]);
				//Coords B = new Coords(data[2], data[3]);
				
				Console.WriteLine(DistanceBetween(dataInt[0], dataInt[1], dataInt[2], dataInt[3]));
			}
		}

		Console.ReadKey();
	}

	static int DistanceBetween(int aX, int aY, int bX, int bY)//Coords A, Coords B)
	{
		return (int)Math.Sqrt(Math.Pow(aX - bX, 2) + Math.Pow(aY - bY, 2));//Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
	}

	/*public struct Coords
	{
		public int X;
		public int Y;
		public Coords(string x, string y)
		{
			X = Convert.ToInt32(x);
			Y = Convert.ToInt32(y);
		}
	}*/
}